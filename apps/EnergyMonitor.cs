using HomeAssistantGenerated;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
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
    public static Dictionary<double, string> electiricityRanges;

    private List<ElectricityPriceInfo> hoursToday;

    private bool hiPeakAlertGiven = false;
    private bool loPeakAlertGiven = false;
    private bool solarChargingNotificationGiven = false;
    private bool solarChargingOffNotificationGiven = false;

    private List<double>? electricityRangeKeys;

    private double abNormalEnergyIncreaseThreshold = 0.2;

    private static EnergyMonitor? _instance;
    ElectricityPriceInfo? infoForCurrentHour { get { return hoursToday[DateTime.Now.Hour]; } }

    private double marginOfErrorFix = 1.07;
    private bool skipThisHour = true;
    private static int lastCaclHour = -5;
    private DateTime timeOfLastSolarNotification = DateTime.MinValue;

    private double ecoflowCgargePriceFixHelper = 0.0;
    private double ecoflowUsagePriceFixer = 0.0;

    protected int priceToRange(double price)
    {
        var range = electricityRangeKeys?.FindIndex(x => x > price) ?? -1;
        range = range == -1 ? electricityRangeKeys.Count : range;

        return (int)range - 1;
    }

    protected DateTime dateFromHourIndex(int index)
    {
        return DateTime.Today.AddHours(index);
    }

    protected string priceToRangeName(double price)
    {
        return electiricityRanges.Values.ElementAtOrDefault(priceToRange(price)) ?? "unknown";
    }



    private NumericSensorEntity nordPoolEntity
    {
        get { return _0Gbl._myEntities.Sensor?.Nordpool; }
    }

    public EnergyMonitor()
    {
        _instance = this;

        void ResetRanges()
        {
            electiricityRanges = new Dictionary<double, string>();
            foreach (string s in _0Gbl._myEntities.InputSelect.Electricityranges.stringsFromSelectionDropdown())
            {
                string[] stings = s.Split(';', StringSplitOptions.TrimEntries);
                electiricityRanges.TryAdd(double.Parse(stings[0].Replace(",", "."), System.Globalization.NumberStyles.Float), stings[1]);
            }

            electricityRangeKeys = electiricityRanges.Keys.ToList();
        }
        ResetRanges();

        _0Gbl._myEntities.InputSelect.Electricityranges.StateAllChanges().Subscribe(x => {
            ResetRanges();

            Console.WriteLine("Electricity Ranges Reset");
        });

        fillDays();

        _0Gbl._myEntities?.InputNumber.ElectricityPriceFixer.StateChanges().Where(e => e.New.State != 0).Subscribe(e => {
            _0Gbl._myEntities.InputNumber.EnergyCostDaily.AddValue(e.New.State.Value);
            e.Entity.SetValue(0);
        });


        _0Gbl._myEntities.Sensor.EcoflowAcInputHourly.StateChanges().Where(x => x.Old.State == 0 && x.New.State > abNormalEnergyIncreaseThreshold).Subscribe(e => {

            ecoflowCgargePriceFixHelper = _0Gbl._myEntities.Sensor.EcoflowAcInputHourly.State ?? 0;
        });
        _0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.StateChanges().Where(x => x.Old.State == 0 && x.New.State > abNormalEnergyIncreaseThreshold).Subscribe(e =>
        {

            ecoflowUsagePriceFixer = _0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.State ?? 0;
        });
        _0Gbl.HourlyResetFunction += () => UpdatePriceHourly(_0Gbl._myEntities?.Sensor.TotalHourlyEnergyConsumptions.State ?? 0);

        _0Gbl._myScheduler.ScheduleCron("50 * * * *", () => EnergiPriceChengeAlert());

        solarChargingNotificationGiven = _0Gbl._myEntities?.Sensor?.EcoflowSolarInPower.State >= 0;
        _0Gbl._myEntities?.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(e => ((e.New.IsOn() || e.New.IsOff()) && e.Old?.State != "unavailable" )).Subscribe(_e =>
        {
            TTS.Instance?.SpeakTTS("Solar panels " + (_0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn() ? "on" : "off"),null , TTS.TTSPriority.PlayInGuestMode);

        }
        );
            _0Gbl._myEntities?.BinarySensor.SolarChargingLimit.StateChanges().Where(e => e.New.IsOn() && e.Old.IsOff()).Subscribe(_e => { 
        
        if(DateTime.Now > timeOfLastSolarNotification + TimeSpan.FromMinutes(30))
         {     
                if(_0Gbl._myEntities.Sensor.EcoflowStatus.State != "online" || _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOff())
                {
                    if (_0Gbl._myEntities.InputBoolean.NotificationEnergySolar.IsOn())
                    {
                        TTS.Instance?.SpeakTTS("Solar charging available",null, TTS.TTSPriority.PlayInGuestMode);
                        timeOfLastSolarNotification = DateTime.Now;
                    }

                }
         }
             
        });

        _0Gbl._myScheduler.RunEvery(TimeSpan.FromHours(1)+TimeSpan.FromMinutes(30), DateTimeOffset.Now, () => {

            if (_0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn() && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State == 0 && _0Gbl._myEntities.BinarySensor.SolarChargingLimit.IsOff() && _0Gbl._myEntities.BinarySensor.SolarChargingLimit.StateFor(TimeSpan.FromMinutes(30)) && _0Gbl._myEntities.Sensor.EcoflowAcOutputFixed.State == 0)
            {
                TTS.Instance?.SpeakTTS("Solar panels are active",null, TTS.TTSPriority.PlayInGuestMode);
            }

        });

        skipThisHour = true;
        _0Gbl._myEntities.BinarySensor.FritzBox6660CableConnection.StateChanges().Where(e => e.New.IsOn()).Subscribe(_e => { skipThisHour = true; });

        _0Gbl._myEntities?.Sun.Sun.StateAllChanges().Where(x => (x?.New?.Attributes.Elevation <= 10 && !solarChargingOffNotificationGiven && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State ==0 && _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn())).Subscribe(x => { TTS.Instance.SpeakTTS("Solar Charging Ended",null, TTS.TTSPriority.PlayInGuestMode); solarChargingOffNotificationGiven = true; });
        _0Gbl._myEntities?.Sensor.EcoflowSolarInPower.StateChanges().Where(x => x?.New.State > 0 && !solarChargingNotificationGiven).Subscribe(_ => {
            TTS.Instance.SpeakTTS("Solar Charging On",null, TTS.TTSPriority.PlayInGuestMode); solarChargingNotificationGiven = true;
        });
        _0Gbl._myEntities?.Sensor.NordpoolTomorrowValid.StateChanges().Where(x => x.New.State == "True" && x.Old.State == "False").Subscribe(_ => {
            fillDays();
            ReadOutEnergyUpdate();
        });
        _0Gbl.DailyResetFunction += OnDayChanged;
        UpdateNextChangeHourTime();


    }



    private void fillDays()
    {
        hoursToday?.Clear();
        var tmplist = new List<ElectricityPriceInfo>();

        var todayList = nordPoolEntity?.EntityState?.Attributes?.Today;
        var tomorrowList = nordPoolEntity?.Attributes.TomorrowValid.Value == true ? JsonSerializer.Deserialize<double[]>(nordPoolEntity?.EntityState?.Attributes?.Tomorrow.ToString()) : new double[0];

       var combinelist = todayList.Concat(tomorrowList).ToArray();

        for (int i = 0; i < combinelist.Length; i++)
        {
            var price = combinelist.ElementAt(i);
            var peak = price == nordPoolEntity?.EntityState?.Attributes?.Max ? 1 : 0;
            peak = price == nordPoolEntity?.EntityState?.Attributes.Min ? -1 : peak;
            var info = new ElectricityPriceInfo(DateTime.Today + TimeSpan.FromHours(i), price, peak);
           
            if(i != 0)
            {
                tmplist.Last().nexthour = info;
            } 
            tmplist.Add (info);
        }

        hoursToday = tmplist;

    }
    /*
    private void fillToday()
    {
      
        hoursToday = new ElectricityPriceInfo[24];

        var todayList = nordPoolEntity?.EntityState?.Attributes?.Today;

        for (int i=0; i< todayList.Count; i++)
        {
            var price = todayList.ElementAt(i);
            var peak = price == nordPoolEntity?.EntityState?.Attributes?.Max ? 1 : 0;
            peak = price == nordPoolEntity?.EntityState?.Attributes.Min ? -1 : peak;
            hoursToday[i] = new ElectricityPriceInfo(DateTime.Today + TimeSpan.FromHours(i),price, peak);
        }
  
    }

    private void fillTomorrow()
    {
        hoursTomorrow = null;
        if (nordPoolEntity?.Attributes.TomorrowValid ?? false)
        {
            hoursTomorrow = new ElectricityPriceInfo[24];
            var tomorrowList = JsonSerializer.Deserialize<List<double>>(_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur3100255?.EntityState?.Attributes?.Tomorrow.ToString());

            for (int i = 0; i < tomorrowList.Count; i++)
            {
                hoursTomorrow[i] = new ElectricityPriceInfo(DateTime.Today+TimeSpan.FromDays(1) + TimeSpan.FromHours(i),tomorrowList.ElementAt(i), 0);

            }
        }
    }

    */

    private void UpdateNextChangeHourTime()
    {

        var hoursTillChange = FindWhenElectricityRangeChanges(infoForCurrentHour.nexthour);

        if (hoursTillChange != null)
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

            EnergyForecastInfo energyForecastInfo = GetEnergyForecast(nordPoolEntity?.Attributes.TomorrowValid.Value == true ? JsonSerializer.Deserialize<double[]>(nordPoolEntity?.EntityState?.Attributes?.Tomorrow.ToString()) : new double[0]);

        message += "Tomorrows Prices will be" + (energyForecastInfo.isAllSameRange ? " all " : " mostly ") + "in " + priceToRangeName(energyForecastInfo.avarage);
            message += " and  " + PercentageDifference(nordPoolEntity?.EntityState?.Attributes?.Average ?? 0, energyForecastInfo.avarage) + "% " + (nordPoolEntity?.EntityState?.Attributes?.Average > energyForecastInfo.avarage ? "lower" : "higher") + " than today.";

            if (energyForecastInfo.subZeroCount > 0) message += " There will also be " + energyForecastInfo.subZeroCount + " sub zero hour" + (energyForecastInfo.subZeroCount > 1 ? "s." : ".");
        

            TTS.Speak(message, TTS.TTSPriority.PlayInGuestMode);


    }

    double PercentageDifference(double a, double b)
    {
        return Math.Round((b - a) / ((a + b) / 2) * 100);
    }


    private EnergyForecastInfo GetEnergyForecast(double[] list, int startFrom = 0)
    {
        EnergyForecastInfo energyForecastInfo = new EnergyForecastInfo();
        if (list == null) return energyForecastInfo;

        //Because Tomorrow values come as strings, we must make sure we convert values to doubles first

        Dictionary<int, int> foundPerRange = new Dictionary<int, int>();

        double avg = list.Average();
        double max = list.Max();
        double min = list.Min();
        int subZeroCount = 0;

        int FindRangeForPrice(double? price)
        {
            var range = electricityRangeKeys?.FindIndex(x => x > price) ?? -1;
            range = range == -1 ? electricityRangeKeys.Count : range;

            return (int)range - 1;
        }


        for (int i = startFrom; i < list.Length - 1; i++)
        {

            var rangeForPrice = FindRangeForPrice(Math.Max(0, list.ElementAt(i)));

            if (!foundPerRange.ContainsKey(rangeForPrice)) foundPerRange.Add(rangeForPrice, 1);
            else foundPerRange[rangeForPrice]++;

            if(list.ElementAt(i) <= 0)subZeroCount ++;

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
        return hoursToday[hour];
    }
    public void MorningTTS()
    {
        if (_0Gbl._myEntities.InputBoolean.NotificationEnergyPriceChange.IsOff() && (_0Gbl._myEntities.InputBoolean.NotificationEnergySolar.IsOff() && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State == 0)) return;
        string TTSMessage = "Good Morning.";
  
          
        PriceChangeType priceChange = comparePrice(infoForCurrentHour.price ?? 0, _0Gbl._myEntities.Sensor.NextPrice.State ?? 0 );
        bool addAlso = false;
        if (infoForCurrentHour.range != 0 || priceChange != PriceChangeType.NoChange)
        {
            TTSMessage += " Current Electricity Cost is at " + priceToRangeName(infoForCurrentHour.price ?? 0) + ". ";
            if (priceChange != PriceChangeType.NoChange)
            {

                TTSMessage += "But it will " + (priceChange == PriceChangeType.Increase ? "increase to " : "decrease to ") + priceToRangeName(_0Gbl._myEntities.Sensor.NextPrice.State ?? 0);
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
        return hourlyUsedEnergy - (double.Max(0,_0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.AsNumeric().State ?? 0)) - (_0Gbl._myEntities.Sensor.EcoflowSolarInputHourly.AsNumeric().State ?? 0);
    }

    private PriceChangeType comparePrice(ElectricityPriceInfo priceA, ElectricityPriceInfo priceB)
    {
        int rangeOfA = priceA?.range ?? 0; 
        int rangeofB = priceB?.range ?? 0;


        if (rangeOfA < rangeofB) return PriceChangeType.Increase;
        else if (rangeOfA > rangeofB) return PriceChangeType.Descrease;
        else return PriceChangeType.NoChange;
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

        UpdateNextChangeHourTime();
        if (_0Gbl._myEntities.InputBoolean.NotificationEnergyPriceChange.IsOff()) return;
        if (_0Gbl._myEntities.InputBoolean.Isasleep.State == "on") return;

        // No need for alert on low price days
        if (nordPoolEntity.Attributes.Max < electiricityRanges.Keys.ToArray()[1]) return;

        ElectricityPriceInfo inFoForNextHour = infoForCurrentHour?.nexthour;
        PriceChangeType priceChange = comparePrice(infoForCurrentHour, inFoForNextHour);
       
        string TTSMessage = null;

        Console.WriteLine("Current Price: " + infoForCurrentHour.price);
        Console.WriteLine("Next Price: " + inFoForNextHour.price);
        Console.WriteLine("Price Range: " + inFoForNextHour.range);
        Console.WriteLine("Price Change: " + priceChange.ToString());
        
        Console.WriteLine("Range Change in: " + FindWhenElectricityRangeChanges(inFoForNextHour.nexthour)?.dateTime);

        if (priceChange == PriceChangeType.NoChange && inFoForNextHour.peak == 0 
            || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == -1 && loPeakAlertGiven) 
            || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == 1 && hiPeakAlertGiven)) return;
        

            bool isWarning = priceChange == PriceChangeType.Increase || inFoForNextHour.peak == 1;


        TTSMessage = "Electricity " + (isWarning ? "Warning. " : "Notice. ") + "The Price is About to ";
        int ttsLenght = TTSMessage.Length;


        if (priceChange != PriceChangeType.NoChange)
        {
            TTSMessage += (priceChange == PriceChangeType.Increase ? "increase to " : "fall to ") + priceToRangeName(_0Gbl._myEntities.Sensor.NextPrice.State ?? 0) + ".";

            var hoursTillChange =  FindWhenElectricityRangeChanges(inFoForNextHour.nexthour);


            PriceChangeType priceChangeType = comparePrice(inFoForNextHour, hoursTillChange);

            if (hoursTillChange == null || priceChangeType == PriceChangeType.NoChange)
            {
                TTSMessage += "And stays like that for while.";
            }
            else if (priceChange == PriceChangeType.Increase || priceChange == PriceChangeType.Descrease)
            {
                var timeDiff = hoursTillChange.dateTime - inFoForNextHour.dateTime;
                TTSMessage += "And will " + (priceChangeType == PriceChangeType.Increase ? "increase to " : "fall to ") + priceToRangeName(hoursTillChange.price ?? 0) + " after " + GetHoursAndMinutesFromTimeSpan(timeDiff);
            }

            if (inFoForNextHour.peak != 0)
            {
                TTSMessage += ". This will also ";
            }

            if(priceChange == PriceChangeType.Increase && inFoForNextHour.range > 0 && _0Gbl._myEntities.Sensor.EcoflowStatus.State.ToLower() == "online")
            {
                _0Gbl._myEntities.Switch.EcoflowAcEnabled.TurnOn();

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

        public ElectricityPriceInfo nexthour = null;

        public ElectricityPriceInfo(DateTime dateTime, double price, int peak)
        {
            this.dateTime = dateTime;
            this.price = price;
            this.peak = peak;
            this.range = FindRangeForPrice(price, EnergyMonitor.electiricityRanges.Keys.ToList());

        }

        public PriceChangeType Compare(ElectricityPriceInfo endPoint)
        {
            if (range < endPoint.range) return PriceChangeType.Increase;
            if (range > endPoint.range) return PriceChangeType.Descrease;

            return PriceChangeType.NoChange;
        }

        private int FindRangeForPrice(double? price, List<double>? electricityRangeKeys)
        {
            var range = electricityRangeKeys?.FindIndex(x => x >= Math.Max(0,price ?? 0))-1;
            range = range < 0 ? 0 : range;

            return (int)range;
        }

    }

    private ElectricityPriceInfo FindWhenElectricityRangeChanges(ElectricityPriceInfo startInfo)
    {
        if (startInfo == null) return null;

        ElectricityPriceInfo nextInfo = startInfo;
        do
        {
          nextInfo = nextInfo.nexthour;

        } while (nextInfo.range == startInfo.range && nextInfo.nexthour != null);

        return nextInfo;
    }

    private int FindRangeForPrice(double? price)
    {
        var range = electricityRangeKeys?.FindIndex(x => x >= Math.Max(0, price ?? 0)) - 1;
        range = range < 0 ? 0 : range;

        return (int)range;
    }



    private void UpdatePriceHourly(double energy)
    {
         
        if (_0Gbl._myEntities.InputNumber.EnergyCostDaily.State == null) return;
        if (_0Gbl._myEntities.InputNumber.EnergyCostHourly.State == null) return;
        if (lastCaclHour == DateTime.Now.Hour) return;
        if (_0Gbl._myEntities?.Sensor.Powermeters.State == null) return;

        double energyNow = double.Max(double.Parse(_0Gbl._myEntities.Sensor.Powermeters.State.ToString()), 0) ;
        double energyLastHour = _0Gbl._myEntities.InputNumber.EnergyAtStartOfHour.State ?? 0;
        double energyConsumedThisHour = energyNow - energyLastHour;
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
        double ecoflowChargePrice = calculatePrice(double.Max(0,_0Gbl._myEntities.Sensor.EcoflowAcInputHourly.AsNumeric().State ?? 0));

        //subscract energy consumed by EF
        energyConsumedThisHour = ecoflowCacl(energyConsumedThisHour);

        //Calculate price of energy used outside EF
        double priceForLastHout = calculatePrice(energyConsumedThisHour);

        //Calculate saving
        var ecoflowSavedMoney =  ecoflowIgnoredAdjustedPrice - priceForLastHout;

        _0Gbl._myEntities.InputNumber.EcoflowCharingCost.AddValue(ecoflowChargePrice);
        _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.AddValue(ecoflowSavedMoney - ecoflowChargePrice);

        _0Gbl._myEntities.InputNumber.EnergyCostDaily.AddValue(priceForLastHout + ecoflowChargePrice);
        _0Gbl._myEntities.InputNumber.EnergyCostHourly.SetValue(priceForLastHout + ecoflowChargePrice);
        lastCaclHour = DateTime.Now.Hour;
        ecoflowCgargePriceFixHelper = 0;
        ecoflowUsagePriceFixer= 0;
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

        // _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.SetValue(0);
        _0Gbl._myEntities.InputNumber.EcoflowCharingCost.SetValue(0);

        var x = _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(10), () => {
            _0Gbl._myEntities.Sensor.EcoflowAcInputDaily.ResetEnergy();
            _0Gbl._myEntities.Sensor.EcoflowAcInputHourly.ResetEnergy();
            fillDays();
            UpdateNextChangeHourTime();
        });
    }

  

}