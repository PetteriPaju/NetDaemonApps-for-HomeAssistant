using HomeAssistantGenerated;

using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Transactions;
// Use unique namespaces for your apps if you going to share with others to avoid
// conflicting names
namespace NetDaemonApps.apps;

/// <summary>
///     Showcase the scheduling capabilities of NetDaemon
/// </summary>
/// 
[NetDaemonApp]
public class EnergyMonitor
{
    private readonly Dictionary<double, string> electiricityRanges = new Dictionary<double, string>() { { 0, "Blue" }, { 7.5, "Green" }, { 15, "Yellow" }, { 25, "Red" } };
    private ElectricityPriceInfo[] hoursToday;
    private ElectricityPriceInfo[] hoursTomorrow;
    private bool hiPeakAlertGiven = false;
    private bool loPeakAlertGiven = false;
    private bool solarChargingNotificationGiven = false;
    private bool solarChargingOffNotificationGiven = false;
    private bool apOnToday = false;
    private readonly List<double>? electricityRangeKeys;
 

    private static EnergyMonitor? _instance;
    ElectricityPriceInfo? infoForCurrentHour { get { return hoursToday[DateTime.Now.Hour]; } }

    private double marginOfErrorFix = 1.07;
    private bool skipThisHour = true;
    private static int lastCaclHour = -5;
    private DateTime timeOfLastSolarNotification = DateTime.MinValue;

    private double ecoflowCgargePriceFixHelper = 0.0;

    public EnergyMonitor()
    {
        _instance = this;
        electricityRangeKeys = electiricityRanges.Keys.ToList();
        fillToday();
        fillTomorrow();

        _0Gbl._myEntities?.InputNumber.ElectricityPriceFixer.StateChanges().Where(e => e.New.State != 0).Subscribe(e => {
            _0Gbl._myEntities.InputNumber.EnergyCostDaily.AddValue(e.New.State.Value);
            e.Entity.SetValue(0);
        });

        _0Gbl.HourlyResetFunction += () => UpdatePriceHourly(_0Gbl._myEntities?.Sensor.TotalHourlyEnergyConsumptions.State ?? 0);
        _0Gbl.HourlyResetFunction += () => UpdateNextChangeHourTime();

        _0Gbl._myScheduler.ScheduleCron("01 * * * *", () => {

            ecoflowCgargePriceFixHelper = _0Gbl._myEntities.Sensor.EcoflowAcInputHourly.AsNumeric().State ?? 0;
        });

        _0Gbl.HourlyResetFunction += () => AirPurifierOn();
        _0Gbl._myScheduler.ScheduleCron("50 * * * *", () => EnergiPriceChengeAlert());

        solarChargingNotificationGiven = _0Gbl._myEntities?.Sensor?.EcoflowSolarInPower.State >= 0;
        _0Gbl._myEntities?.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(e => e.New.IsOn() || e.New.IsOff()).Subscribe(_e =>
        {
            TTS.Instance?.SpeakTTS("Solar panels " + (_0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn() ? "on" : "off"), TTS.TTSPriority.PlayInGuestMode);

        }
        );
            _0Gbl._myEntities?.BinarySensor.SolarChargingLimit.StateChanges().Where(e => e.New.IsOn() && e.Old.IsOff()).Subscribe(_e => { 
        
        if(DateTime.Now > timeOfLastSolarNotification + TimeSpan.FromMinutes(30))
         {     
                if(_0Gbl._myEntities.Sensor.EcoflowStatus.State != "online" || _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOff())
                {
                    if (_0Gbl._myEntities.InputBoolean.NotificationEnergySolar.IsOn())
                    {
                        TTS.Instance?.SpeakTTS("Solar chargin available", TTS.TTSPriority.PlayInGuestMode);
                        timeOfLastSolarNotification = DateTime.Now;
                    }

                }
         }
             
        });

        _0Gbl._myScheduler.RunEvery(TimeSpan.FromHours(1)+TimeSpan.FromMinutes(30), DateTimeOffset.Now, () => {

            if (_0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn() && _0Gbl._myEntities.Sensor.EcoflowAcInPower.State == 0 && _0Gbl._myEntities.BinarySensor.SolarChargingLimit.IsOff() && _0Gbl._myEntities.BinarySensor.SolarChargingLimit.StateFor(TimeSpan.FromMinutes(30)))
            {
                TTS.Instance?.SpeakTTS("Solar panels are active", TTS.TTSPriority.PlayInGuestMode);
            }

        });

        skipThisHour = true;
        _0Gbl._myEntities.BinarySensor.FritzBox6660CableConnection.StateChanges().Where(e => e.New.IsOn()).Subscribe(_e => { skipThisHour = true; });

        _0Gbl._myEntities?.Sun.Sun.StateAllChanges().Where(x => (x?.New?.Attributes.Elevation <= 5 && !solarChargingOffNotificationGiven && _0Gbl._myEntities.BinarySensor.SolarChargingLimit.IsOff() && _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn())).Subscribe(x => { TTS.Instance.SpeakTTS("Solar Charging Ended", TTS.TTSPriority.PlayInGuestMode); solarChargingOffNotificationGiven = true; });

        _0Gbl._myEntities?.Sensor.NordpoolTomorrowValid.StateChanges().Where(x => x.New.State == "True" && x.Old.State == "False").Subscribe(_ => {
            fillTomorrow();
            ReadOutEnergyUpdate();
        });
        _0Gbl.DailyResetFunction += OnDayChanged;
        UpdateNextChangeHourTime();


    }

    private void fillToday()
    {
      
        hoursToday = new ElectricityPriceInfo[24];
        var todayList = _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Today;

        for (int i=0; i< todayList.Count; i++)
        {
            var price = todayList.ElementAt(i);
            var peak = price == _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Max ? 1 : 0;
            peak = price == _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes.Min ? -1 : peak;
            hoursToday[i] = new ElectricityPriceInfo(DateTime.Today + TimeSpan.FromHours(i),price, peak);
        }
  
    }

    private void fillTomorrow()
    {
        hoursTomorrow = null;
        if (_0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001?.Attributes.TomorrowValid ?? false)
        {
            hoursTomorrow = new ElectricityPriceInfo[24];
            var tomorrowList = JsonSerializer.Deserialize<List<double>>(_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Tomorrow.ToString());

            for (int i = 0; i < tomorrowList.Count; i++)
            {
                hoursTomorrow[i] = new ElectricityPriceInfo(DateTime.Today+TimeSpan.FromDays(1) + TimeSpan.FromHours(i),tomorrowList.ElementAt(i), 0);

            }
        }
    }

    private void AirPurifierOn()
    {
       if (infoForCurrentHour.peak == -1 && infoForCurrentHour.range <= 0 && !apOnToday) { _0Gbl._myEntities.Switch.SwitchbotAirPurifierPower.Toggle(); apOnToday = true; }
    }

    private void UpdateNextChangeHourTime()
    {
        ElectricityPriceInfo inFoForNextHour2 = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        _0Gbl._myEntities.InputNumber.EnergyNextPrice.SetValue(GetPriceForHour(DateTime.Now.Hour + 2).price ?? 0);

        var hoursTillChange = FindWhenElectricityRangeChanges(inFoForNextHour2, 48);
        if(hoursTillChange != null)
        _0Gbl._myEntities.InputDatetime.EnergyChangeTime.SetDatetime(datetime: hoursTillChange.dateTime.ToString(@"yyyy-MM-dd HH\:00\:00"));
        else
        {
            _0Gbl._myEntities.InputDatetime.EnergyChangeTime.SetDatetime(datetime: DateTime.Now.ToString(@"yyyy-MM-dd HH\:00\:00"));
        }
    }

    private void DailyReset()
    {

    }
    public static void ReadOutGoodMorning()
    {
        _instance?.MorningTTS();
    }

    private struct EnergyForecastInfo
    {
        public double avarage;
        public double max;
        public double min;
        public int majorityRange;
        public int averageRange;
        public bool isAllSameRange;
        public int subZeroCount;

    }


 


    public void ReadOutEnergyUpdate()
    {
        if (_0Gbl._myEntities.InputBoolean.NotificationEnergyDailyUpdate.IsOff()) return;
        string message = "Energy update!";

            EnergyForecastInfo energyForecastInfo = GetEnergyForecast(hoursTomorrow);

            message += "Tomorrows Prices will be" + (energyForecastInfo.isAllSameRange ? " all " : " mostly ") + "in " +  GetNameOfRange(energyForecastInfo.averageRange);
            message += " and  " + PercentageDifference(_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Average ?? 0, energyForecastInfo.avarage) + "% " + (_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Average > energyForecastInfo.avarage ? "lower" : "higher") + " than today.";

            if (energyForecastInfo.subZeroCount > 0) message += " There will also be " + energyForecastInfo.subZeroCount + " sub zero hour" + (energyForecastInfo.subZeroCount > 1 ? "s." : ".");
        

            TTS.Speak(message, TTS.TTSPriority.PlayInGuestMode);


    }

    double PercentageDifference(double a, double b)
    {
        return Math.Round((b - a) / ((a + b) / 2) * 100);
    }


    private EnergyForecastInfo GetEnergyForecast(ElectricityPriceInfo[] list, int startFrom = 0)
    {
        EnergyForecastInfo energyForecastInfo = new EnergyForecastInfo();
        if (list == null) return energyForecastInfo;

        //Because Tomorrow values come as strings, we must make sure we convert values to doubles first
        var tmp = list.Select(x=>x.price ?? 0).ToList();

        Dictionary<int, int> foundPerRange = new Dictionary<int, int>();

        double avg = tmp.Average();
        double max = tmp.Max();
        double min = tmp.Min();
        int subZeroCount = 0;

     


        for (int i = startFrom; i < tmp.Count - 1; i++)
        {

            var rangeForPrice = FindRangeForPrice(Math.Max(0,tmp.ElementAt(i)));

            if (!foundPerRange.ContainsKey(rangeForPrice)) foundPerRange.Add(rangeForPrice, 1);
            else foundPerRange[rangeForPrice]++;

            if(tmp.ElementAt(i) <= 0)subZeroCount ++;

        }


        energyForecastInfo.avarage = avg;
        energyForecastInfo.max = max;
        energyForecastInfo.min = min;
        energyForecastInfo.averageRange = FindRangeForPrice(Math.Max(0, avg));
        energyForecastInfo.majorityRange = Math.Max(0,foundPerRange.MaxBy(x => x.Value).Key);
        energyForecastInfo.isAllSameRange = foundPerRange.Count == 1;
        energyForecastInfo.subZeroCount = subZeroCount;

        return energyForecastInfo;

    }


    private ElectricityPriceInfo GetPriceForHour(int hour)
    {
        if (hour <= 23)
        {
            return hoursToday[hour];
        }
        else if (hoursTomorrow != null)
        {
            int tmpHour = hour-24;


            Console.WriteLine(hoursTomorrow[tmpHour].price);
            return hoursTomorrow[tmpHour];
        }
        else return new ElectricityPriceInfo(DateTime.Now, 0, 0);
    }
    public void MorningTTS()
    {
        if (_0Gbl._myEntities.InputBoolean.NotificationEnergyPriceChange.IsOff() && (_0Gbl._myEntities.InputBoolean.NotificationEnergySolar.IsOff() && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State == 0)) return;
        string TTSMessage = "Good Morning.";
  
          
        PriceChangeType priceChange = comparePrice(GetPriceForHour(DateTime.Now.Hour).price ?? 0 , GetPriceForHour(DateTime.Now.Hour + 1).price ?? 0);
        bool addAlso = false;
        if (infoForCurrentHour.range != 0 || priceChange != PriceChangeType.NoChange)
        {
            TTSMessage += " Current Electricity Cost is " + (infoForCurrentHour.range == -1 ? "Unknown" : "at " + electiricityRanges.Values.ElementAt(infoForCurrentHour.range)) + ". ";
            if (priceChange != PriceChangeType.NoChange)
            {

                TTSMessage += "But it will " + (priceChange == PriceChangeType.Increase ? "increase to " : "decrease to ") + electiricityRanges.Values.ElementAt(FindRangeForPrice( GetPriceForHour(DateTime.Now.Hour+1).price) );
                TTSMessage += " in " + (60 - DateTime.Now.Minute) + " minutes.";
            }
            addAlso = true;
        }

        if (_0Gbl._myEntities.BinarySensor.SolarChargingLimit.IsOn() && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State == 0)
        {
            TTSMessage += "There is " + (addAlso ? "also" : "") + "potential for solar charging";
        }

       

        TTS.Speak(TTSMessage,TTS.TTSPriority.DoNotPlayInGuestMode);

    }
    
    private double ecoflowCacl(double hourlyUsedEnergy)
    {
        return hourlyUsedEnergy - _0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.AsNumeric().State ?? 0 - _0Gbl._myEntities.Sensor.EcoflowSolarInputHourly.AsNumeric().State ?? 0;
    }

    private PriceChangeType comparePrice(double priceA, double priceB)
    {
        int rangeOfA = FindRangeForPrice(priceA); 
        int rangeofB = FindRangeForPrice(priceB);


        if (rangeOfA < rangeofB) return PriceChangeType.Increase;
        else if (rangeOfA > rangeofB) return PriceChangeType.Descrease;
        else return PriceChangeType.NoChange;
    }

    private void EnergiPriceChengeAlert()
    {

    
        if (_0Gbl._myEntities.InputBoolean.NotificationEnergyPriceChange.IsOff()) return;
        if (_0Gbl._myEntities.InputBoolean.Isasleep.State == "on") return;

        bool checkTomorrow = DateTime.Now.Hour == 23;

        // No need for alert on low price days
        if (_0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001.Attributes.Max < electiricityRanges.Keys.ToArray()[1] && !checkTomorrow) return;

        Console.WriteLine("currentRange: " + infoForCurrentHour.range);
        ElectricityPriceInfo inFoForNextHour = GetPriceForHour(DateTime.Now.Hour + 1);
        PriceChangeType priceChange = comparePrice(GetPriceForHour(DateTime.Now.Hour).price ?? 0, inFoForNextHour.price ?? 0);
       
        string TTSMessage = null;

        if (priceChange == PriceChangeType.NoChange && inFoForNextHour.peak == 0 
            || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == -1 && loPeakAlertGiven) 
            || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == 1 && hiPeakAlertGiven)) return;
        


            bool isWarning = priceChange == PriceChangeType.Increase || inFoForNextHour.peak == 1;


        TTSMessage = "Electricity " + (isWarning ? "Warning. " : "Notice. ") + "The Price is About to ";
        int ttsLenght = TTSMessage.Length;


        if (priceChange != PriceChangeType.NoChange)
        {
            TTSMessage += (priceChange == PriceChangeType.Increase ? "increase to " : "fall to ") + electiricityRanges.Values.ElementAt(FindRangeForPrice(inFoForNextHour.price)) + ".";

            var hoursTillChange = FindWhenElectricityRangeChanges(inFoForNextHour, 12);


            PriceChangeType priceChangeType = comparePrice(inFoForNextHour.price ?? 0, hoursTillChange.price ?? 0);

            if (hoursTillChange == null || priceChangeType == PriceChangeType.NoChange)
            {
                TTSMessage += "And stays like that for while.";
            }
            else if (priceChange == PriceChangeType.Increase || priceChange == PriceChangeType.Descrease)
            {
                var timeDiff = hoursTillChange.dateTime - inFoForNextHour.dateTime;
                TTSMessage += "And will " + (priceChangeType == PriceChangeType.Increase ? "increase to " : "fall to ") + electiricityRanges.Values.ElementAt(FindRangeForPrice(hoursTillChange.price)) + " after " + GetHoursAndMinutesFromTimeSpan(timeDiff);
            }

            if (inFoForNextHour.peak != 0)
            {
                TTSMessage += ". This will also ";
            }
        }

         

            if (inFoForNextHour.peak == 1 && !hiPeakAlertGiven)
            {
                TTSMessage += "be the peak price of the day.";
            hiPeakAlertGiven = true;
            }
            if (inFoForNextHour.peak == -1 && !loPeakAlertGiven)
            {
                TTSMessage += "be the lowest price of the day";
            loPeakAlertGiven = true;

            }

            //Fix for weird bug that prevents Peak Alert from triggering
        if (ttsLenght == TTSMessage.Length) return;
        

        if(TTSMessage!= null)TTS.Speak(TTSMessage, TTS.TTSPriority.PlayInGuestMode);
    }

    private string GetNameOfRange(int rangeIndex)
    {
        return electiricityRanges.Values.ElementAtOrDefault(rangeIndex) ?? "unknown";
    }

    private string GetHoursAndMinutesFromTimeSpan(TimeSpan input)
    {

        var hour = input.Hours > 0 ? input.Hours.ToString() + " hour" + (input.Hours > 1 ? "s" : "") : "";
        var and = input.Hours > 0 && input.Minutes > 0 ? " and " : "";
        var minute = input.Minutes > 0 ? input.Minutes.ToString() + " minute" + (input.Minutes > 1 ? "s" : "") : "";


        return hour + and + minute;
    }

    private enum PriceChangeType
    {
        NoChange,
        Increase,
        Descrease,
    }
    private class ElectricityPriceInfo
    {

        public double? price;
        public DateTime dateTime;
        public int range;
        public int peak = 0;


        public ElectricityPriceInfo(DateTime dateTime, double price, int peak)
        {
            this.dateTime = dateTime;
            this.price = price;
            this.peak = peak;
        }

            public ElectricityPriceInfo(DateTime time, NumericSensorEntity? nordPoolEntity, List<double>? electricityRangeKeys)
        {
            bool isToday = time.Date.DayOfWeek == DateTime.Now.Date.DayOfWeek;

            IReadOnlyList<double>? day = isToday ? nordPoolEntity?.EntityState?.Attributes?.Today : nordPoolEntity?.EntityState?.Attributes?.TomorrowValid == true ? JsonSerializer.Deserialize<List<double>>(nordPoolEntity?.EntityState?.Attributes?.Tomorrow.ToString()).AsReadOnly() : nordPoolEntity?.EntityState?.Attributes?.Today;
            price = time.Hour < day?.Count ? day?.ElementAt(time.Hour) : day?.LastOrDefault();
            range = price >= 0  ? FindRangeForPrice(price, electricityRangeKeys) : 0;

            Console.WriteLine( "Hour" +  time.Hour + ", Price > " + price + ", Range > " + range);
            
            dateTime = time;

            peak = price == nordPoolEntity.Attributes.Max ? 1 : 0;
            peak = price == nordPoolEntity.Attributes.Min ? -1 : peak;

        }

        public PriceChangeType Compare(ElectricityPriceInfo endPoint)
        {
            if (range < endPoint.range) return PriceChangeType.Increase;
            if (range > endPoint.range) return PriceChangeType.Descrease;

            return PriceChangeType.NoChange;
        }

        private int FindRangeForPrice(double? price, List<double>? electricityRangeKeys)
        {
            var range = electricityRangeKeys?.FindIndex(x => x >= Math.Max(0,price ?? 0));
            range = range == -1 ? electricityRangeKeys.Count : range;

            return (int)range - 1;
        }

    }

    private ElectricityPriceInfo FindWhenElectricityRangeChanges(ElectricityPriceInfo startInfo, int maxhHours)
    {

        ElectricityPriceInfo nextInfo = null;// = new ElectricityPriceInfo(currentHour, _00_Globals._myEntities.Sensor.NordpoolKwhFiEur31001, electricityRangeKeys);

        int maxSearchHours = maxhHours;
        ElectricityPriceInfo[] hours = hoursToday.ToArray();
        if (hoursTomorrow != null)
        {
            hours = hours.Concat(hoursTomorrow).ToArray();
        }

        for (int searchCounter = startInfo.dateTime.Hour; searchCounter < hours.Length; searchCounter++)
        { 
            if (hours[searchCounter] == null) continue;
            if (comparePrice(startInfo.price ?? 0, hours[searchCounter].price ?? 0) != PriceChangeType.NoChange) { 

                nextInfo = hours[searchCounter];
            break;
            }

        }


        return nextInfo;
    }


    private int FindRangeForPrice(double? price)
    {
        var range = electricityRangeKeys?.FindIndex(x => x > price) ?? -1;
        range = range == -1 ? electricityRangeKeys.Count : range;

        return (int)range-1;
    }


    private void UpdatePriceHourly(double energy)
    {
         
        if (_0Gbl._myEntities.InputNumber.EnergyCostDaily.State == null) return;
        if (_0Gbl._myEntities.InputNumber.EnergyCostHourly.State == null) return;
        if (lastCaclHour == DateTime.Now.Hour) return;
        if (_0Gbl._myEntities?.Sensor.Powermeters.State == null) return;

        double energyNow = double.Parse( _0Gbl._myEntities.Sensor.Powermeters.State ?? "0") + _0Gbl._myEntities.Sensor.EcoflowAcInputDailyNet.State ?? 0 ;
        double energyLastHour = _0Gbl._myEntities.InputNumber.EnergyAtStartOfHour.State ?? 0;
        double energyConsumedThisHour = energyNow - energyLastHour - ecoflowCgargePriceFixHelper;
        _0Gbl._myEntities.InputNumber.EnergyAtStartOfHour.SetValue(energyNow);


        double calculatePrice(double inpt)
        {
            var thisHourFortum = inpt * infoForCurrentHour.price/100 + inpt  * _0Gbl._myEntities.InputNumber.EnergyFortumHardCost.State;
            thisHourFortum += thisHourFortum * (_0Gbl._myEntities.InputNumber.EnergyFortumAlv.State / 100);

            var thisHourTranster = inpt * _0Gbl._myEntities.InputNumber.EnergyTransferCost.State;
            thisHourTranster += inpt * _0Gbl._myEntities.InputNumber.EnergyTransferAlv.State;
            var thisHourTotal = thisHourFortum + thisHourTranster;

            return thisHourTotal ?? 0;
        }

        //Price of consumed energy, eevent with EF
        double ecoflowIgnoredAdjustedPrice = calculatePrice(energyConsumedThisHour);

        //Cost of EF charge
        double ecoflowChargePrice = calculatePrice(_0Gbl._myEntities.Sensor.EcoflowAcInputDailyNet.AsNumeric().State ?? 0 - ecoflowCgargePriceFixHelper);

        //subscract energy consumed by EF
        energyConsumedThisHour = ecoflowCacl(energyConsumedThisHour);

        //Calculate price of energy used outside EF
        double priceForLastHout = calculatePrice(energyConsumedThisHour);

        //Calculate saving
        var ecoflowSavedMoney =  ecoflowIgnoredAdjustedPrice - priceForLastHout;

        _0Gbl._myEntities.InputNumber.EcoflowCharingCost.AddValue(ecoflowChargePrice);
        _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.AddValue(ecoflowSavedMoney - ecoflowChargePrice);

        _0Gbl._myEntities.InputNumber.EnergyCostDaily.AddValue(priceForLastHout);
        _0Gbl._myEntities.InputNumber.EnergyCostHourly.SetValue(priceForLastHout);
        lastCaclHour = DateTime.Now.Hour;
    }

    private void OnDayChanged()
    {

        hiPeakAlertGiven = false;
        loPeakAlertGiven = false;
        _0Gbl._myEntities.InputNumber.EnergyCostHourly.SetValue(0);
        _0Gbl._myEntities.InputNumber.EnergyCostDaily.SetValue(0);
        _0Gbl._myEntities.InputNumber.EnergyAtStartOfHour.SetValue(0);
        solarChargingNotificationGiven = false;
        solarChargingOffNotificationGiven = false;
        apOnToday = false;
        // _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.SetValue(0);
        fillToday();
        fillTomorrow();
        _0Gbl._myEntities.InputNumber.EcoflowCharingCost.SetValue(0);

        var x = _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(10), () => {
            fillToday();
            fillTomorrow();
            UpdateNextChangeHourTime();
        });
    }

  

}