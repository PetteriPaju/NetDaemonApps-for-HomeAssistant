using HomeAssistantGenerated;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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
    private readonly Dictionary<double, string> electiricityRanges = new Dictionary<double, string>() { { 0, "Blue" }, { 0.075, "Green" }, { 0.15, "Yellow" }, { 0.25, "Red" } };
    private bool hiPeakAlertGiven = false;
    private bool loPeakAlertGiven = false;
    private bool solarChargingNotificationGiven = false;
    private bool solarChargingOffNotificationGiven = false;

    private readonly List<double>? electricityRangeKeys;

    private static EnergyMonitor? _instance;
    ElectricityPriceInfo? infoForCurrentHour = null;

    private double marginOfErrorFix = 1.07;

    public EnergyMonitor()
    {
        _instance = this;
        electricityRangeKeys = electiricityRanges.Keys.ToList();

        infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now, _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        _0Gbl.HourlyResetFunction += () => UpdatePriceHourly(_0Gbl._myEntities?.Sensor.TotalHourlyEnergyConsumptions.State ?? 0);

        _0Gbl._myScheduler.ScheduleCron("50 * * * *", () => EnergiPriceChengeAlert());

        solarChargingNotificationGiven = _0Gbl._myEntities?.Sensor?.EcoflowSolarInPower.State >= 0;
        _0Gbl._myEntities?.Sensor.EcoflowSolarInPower.AsNumeric().StateAllChanges().Where(x => x?.New?.State > 0 && !solarChargingNotificationGiven).Subscribe(x => { TTS.Instance.SpeakTTS("Solar Charging On",TTS.TTSPriority.PlayInGuestMode); solarChargingNotificationGiven = true; });
       // _00_Globals._myEntities?.Sensor.EcoflowSolarInPower.AsNumeric().StateAllChanges().Where(x => (x?.New?.State <= 0 && !solarChargingOffNotificationGiven && _00_Globals._myEntities.Sun.Sun.Attributes.Elevation<5)).Subscribe(x => { TTS.Instance.SpeakTTS("Solar Charging Ended", TTS.TTSPriority.PlayInGuestMode); solarChargingNotificationGiven = true; });

        _0Gbl._myEntities?.Sensor.NordpoolKwhFiEur31001.StateAllChanges().Where(x => x?.New?.Attributes?.TomorrowValid == true && x.Old?.Attributes?.TomorrowValid == false).Subscribe(_ => { ReadOutEnergyUpdate(); });
        _0Gbl.DailyResetFunction += OnDayChanged;
  

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
        public bool isAllSameRange;
        public int subZeroCount;
    }


 


    public void ReadOutEnergyUpdate()
    {
        string message = "Energy update!";

        if (!_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.TomorrowValid == false)
        {
            var list = JsonSerializer.Deserialize<List<double>>(_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Tomorrow.ToString());

            EnergyForecastInfo energyForecastInfo = GetEnergyForecast(list);

            message += "Tomorrows Prices will be" + (energyForecastInfo.isAllSameRange ? " all " : " mostly ") + "in " + GetNameOfRange(energyForecastInfo.majorityRange);
            message += " and  " + PercentageDifference(_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Average ?? 0, energyForecastInfo.avarage) + "% " + (_0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Average > energyForecastInfo.avarage ? "lower" : "higher") + " than today.";

            if (energyForecastInfo.subZeroCount > 0) message += " There will also be " + energyForecastInfo.subZeroCount + " sub zero hour" + (energyForecastInfo.subZeroCount > 1 ? "s." : ".");
        }


        TTS.Speak(message,TTS.TTSPriority.PlayInGuestMode);



    }

    double PercentageDifference(double a, double b)
    {
        return Math.Round((b - a) / ((a + b) / 2) * 100);
    }
    private EnergyForecastInfo GetEnergyForecast(IList<double> list, int startFrom = 0)
    {
        EnergyForecastInfo energyForecastInfo = new EnergyForecastInfo();
        if (list == null) return energyForecastInfo;

        //Because Tomorrow values come as strings, we must make sure we convert values to doubles first
        var tmp = list.ToList();

        int FindRangeForPrice(double? price)
        {
            int range = electricityRangeKeys?.FindIndex(x => x > price) ?? -1;
            range = range == -1 ? 1 : range;

            return range - 1;
        }


        Dictionary<int, int> foundPerRange = new Dictionary<int, int>();

        double avg = tmp.Average();
        double max = tmp.Max();
        double min = tmp.Min();
        int subZeroCount = 0;

     


        for (int i = startFrom; i < tmp.Count - 1; i++)
        {

            var rangeForPrice = FindRangeForPrice(tmp.ElementAt(i));

            if (!foundPerRange.ContainsKey(rangeForPrice)) foundPerRange.Add(rangeForPrice, 1);
            else foundPerRange[rangeForPrice]++;

            if(tmp.ElementAt(i) <= 0)subZeroCount ++;

        }


        energyForecastInfo.avarage = avg;
        energyForecastInfo.max = max;
        energyForecastInfo.min = min;
        energyForecastInfo.majorityRange = foundPerRange.MaxBy(x => x.Value).Key;
        energyForecastInfo.isAllSameRange = foundPerRange.Count == 1;
        energyForecastInfo.subZeroCount = subZeroCount;

        return energyForecastInfo;

    }



    public void MorningTTS()
    {

        string TTSMessage = "Good Morning. Current Electricity Cost is " + (infoForCurrentHour.range == -1 ? "Unknown" : "at " + electiricityRanges.Values.ElementAt(infoForCurrentHour.range));



        ElectricityPriceInfo inFoForNextHour = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        PriceChangeType priceChange = infoForCurrentHour.Compare(inFoForNextHour);



        if (priceChange != PriceChangeType.NoChange)
        {

            TTSMessage += ". But it will";

            if (priceChange == PriceChangeType.Increase)
            {
                TTSMessage += " increase to ";
            }
            else
            {
                TTSMessage += " decrease to ";

            }


            TTSMessage += electiricityRanges.Values.ElementAt(inFoForNextHour.range);
            TTSMessage += " in " + (60 - DateTime.Now.Minute) + " minutes";
        }

       

        TTS.Speak(TTSMessage,TTS.TTSPriority.DoNotPlayInGuestMode);

    }
    
    private double ecoflowCacl(double hourlyUsedEnergy)
    {
        double hourlyEnergyUsed = 0;
        double hourlyEcoflowOut = _0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.AsNumeric().State ?? 0;
        double hourlySolarIn = _0Gbl._myEntities.Sensor.EcoflowSolarInputHourly.AsNumeric().State ?? 0;

        double deltaEnergy;

        deltaEnergy = hourlyUsedEnergy - hourlyEcoflowOut - hourlySolarIn;

        return deltaEnergy;

    }

    bool checkDateChanged()
    {
        DateTime dateTimeVariable = DateTime.ParseExact(_0Gbl._myEntities.InputDatetime.Lastknowndate.State ?? "", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        
        return dateTimeVariable != DateTime.Now.Date;
    }
  
    private void EnergiPriceChengeAlert()
    {

        if (_0Gbl._myEntities.InputBoolean.Isasleep.State == "on") return;
       
        bool checkTomorrow = DateTime.Now.Hour == 23;

        // No need for alert on low price days
        if (_0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001.Attributes.Max < electiricityRanges.Keys.ToArray()[1] && !checkTomorrow) return;

        ElectricityPriceInfo inFoForNextHour = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _0Gbl._myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        PriceChangeType priceChange = infoForCurrentHour.Compare(inFoForNextHour);
        string TTSMessage = null;

        if (priceChange == PriceChangeType.NoChange && inFoForNextHour.peak == 0 || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == -1 && loPeakAlertGiven) || (priceChange == PriceChangeType.NoChange && infoForCurrentHour.peak == 1 && hiPeakAlertGiven)) return;
        


            bool isWarning = priceChange == PriceChangeType.Increase || inFoForNextHour.peak == 1;


        TTSMessage = "Electricity " + (isWarning ? "Warning. " : "Notice. ") + "The Price is About ";


        if (priceChange != PriceChangeType.NoChange)
        {

            if (priceChange == PriceChangeType.Increase)
            {
                TTSMessage += "increase to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range) +".";
            }
            else if(priceChange == PriceChangeType.Descrease)
            {
                TTSMessage += "fall to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range) + ".";
            }


            var hoursTillChange = FindWhenElectricityRangeChanges(inFoForNextHour);

            var timeDiff = hoursTillChange.dateTime - inFoForNextHour.dateTime;

            PriceChangeType priceChangeType = inFoForNextHour.Compare(hoursTillChange);

            if (priceChangeType == PriceChangeType.NoChange)
            {
                TTSMessage += "And stays like that for while.";
            }
            else if (priceChange == PriceChangeType.Increase || priceChange == PriceChangeType.Descrease)
            {

                TTSMessage += "And will " + (priceChangeType == PriceChangeType.Increase ? "increase to " : "decrease to ") + GetNameOfRange(hoursTillChange.range) + " after " + GetHoursAndMinutesFromTimeSpan(timeDiff);
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
            else if (inFoForNextHour.peak == -1 && !loPeakAlertGiven)
            {
                TTSMessage += "be the lowest price of the day";
            loPeakAlertGiven = true;
            }

        

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



        public ElectricityPriceInfo(DateTime time, NumericSensorEntity? nordPoolEntity, List<double>? electricityRangeKeys)
        {
            bool isToday = time.Date.DayOfWeek == DateTime.Now.Date.DayOfWeek;

            IReadOnlyList<double>? day = isToday ? nordPoolEntity?.EntityState?.Attributes?.Today : nordPoolEntity?.EntityState?.Attributes?.TomorrowValid == true ? JsonSerializer.Deserialize<List<double>>(nordPoolEntity?.EntityState?.Attributes?.Tomorrow.ToString()).AsReadOnly() : nordPoolEntity?.EntityState?.Attributes?.Today;
            price = day?.ElementAt(time.Hour);
            range = price > 0  ? FindRangeForPrice(price, electricityRangeKeys) : 0;
            
            dateTime = time;

            peak = price == nordPoolEntity.Attributes.Max ? 1 : 0;
            peak = price == nordPoolEntity.Attributes.Min ? -1 : peak;

        }

        public PriceChangeType Compare(ElectricityPriceInfo endPoint)
        {
            if (range == endPoint.range) return PriceChangeType.NoChange;
            if (range > endPoint.range) return PriceChangeType.Descrease;
            else return PriceChangeType.Increase;
        }

        private int FindRangeForPrice(double? price, List<double>? electricityRangeKeys)
        {
            var range = electricityRangeKeys?.FindIndex(x => x >= price);
            range = range == -1 ? electricityRangeKeys.Count : range;

            return (int)range - 1;
        }

    }

    private ElectricityPriceInfo FindWhenElectricityRangeChanges(ElectricityPriceInfo startInfo)
    {

        ElectricityPriceInfo nextInfo = null;// = new ElectricityPriceInfo(currentHour, _00_Globals._myEntities.Sensor.NordpoolKwhFiEur31001, electricityRangeKeys);

        int maxSearchHours = 12;

        for (int searchCounter = 1; searchCounter < maxSearchHours; searchCounter++)
        {
            nextInfo = new ElectricityPriceInfo(startInfo.dateTime.AddHours(searchCounter), _0Gbl._myEntities.Sensor.NordpoolKwhFiEur31001, electricityRangeKeys);

            if (startInfo.Compare(nextInfo) != PriceChangeType.NoChange)
            {
                break;
            }

        }


        return nextInfo;
    }


    private int FindRangeForPrice(double? price)
    {
        var range = electricityRangeKeys?.FindIndex(x => x > price);
        range = range == -1 ? 1 : range;

        return (int)range - 1;
    }


    private void UpdatePriceHourly(double energy)
    {
        if (_0Gbl._myEntities == null) return;
        if (_0Gbl._myEntities.InputNumber.EnergyCostDaily.State == null) return;
        if (_0Gbl._myEntities.InputNumber.EnergyCostHourly.State == null) return;
        if (_0Gbl._myEntities?.Sensor.Powermeters.State == null) return;

        double calculatePrice(double inpt)
        {
            var thisHourFortum = inpt * marginOfErrorFix * infoForCurrentHour.price + inpt  * _0Gbl._myEntities.InputNumber.EnergyFortumHardCost.State;
            thisHourFortum += thisHourFortum * (_0Gbl._myEntities.InputNumber.EnergyFortumAlv.State / 100);

            var thisHourTranster = inpt * marginOfErrorFix * _0Gbl._myEntities.InputNumber.EnergyTransferCost.State;
            thisHourTranster += thisHourTranster * _0Gbl._myEntities.InputNumber.EnergyTransferAlv.State;
            var thisHourTotal = thisHourFortum + thisHourTranster;

            return (double)thisHourTotal;
        }

         
          double ecoflowAdjustedPrice = calculatePrice(ecoflowCacl(energy));

        energy -= Math.Max(0,_0Gbl._myEntities.Sensor.EcoflowAcOutputHourly.AsNumeric().State ?? 0);
        double priceForLastHout = calculatePrice(energy);

        var ecoflowAdjustedHourlycost = priceForLastHout - ecoflowAdjustedPrice;
        infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now + TimeSpan.FromMinutes(15), _0Gbl._myEntities.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);


        _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.SetValue((_0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.State ?? 0) + ecoflowAdjustedHourlycost);
        _0Gbl._myEntities.InputNumber.EnergyCostDaily.SetValue(_0Gbl._myEntities.InputNumber.EnergyCostDaily.State + priceForLastHout ?? _0Gbl._myEntities.InputNumber.EnergyCostDaily.State ?? 0);
        _0Gbl._myEntities.InputNumber.EnergyCostHourly.SetValue(priceForLastHout);

    }

    private void OnDayChanged()
    {

        hiPeakAlertGiven = false;
        loPeakAlertGiven = false;
        _0Gbl._myEntities.InputNumber.EnergyCostHourly.SetValue(0);
        _0Gbl._myEntities.InputNumber.EnergyCostDaily.SetValue(0);
        _0Gbl._myEntities.InputDatetime.Lastknowndate.SetDatetime(date: DateTime.Now.Date.ToString("yyyy-MM-dd"));
        solarChargingNotificationGiven = false;
        solarChargingOffNotificationGiven = false;
        _0Gbl._myEntities.InputNumber.DailyEnergySaveHelper.SetValue(0);
        _0Gbl._myServices.Script.ResetAllPowermeters();
    }

}