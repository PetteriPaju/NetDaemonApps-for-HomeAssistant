using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
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
    private Entities _myEntities;
    private readonly Dictionary<double, string> electiricityRanges = new Dictionary<double, string>() { { 0, "Blue" }, { 0.075, "Green" }, { 0.15, "Yellow" }, { 0.25, "Red" } };

    private readonly List<double>? electricityRangeKeys;

    private static EnergyMonitor? _instance;
    ElectricityPriceInfo? infoForCurrentHour = null;

    private double marginOfErrorFix = 1.07;

    public EnergyMonitor(IHaContext ha, IScheduler scheduler)
    {
        _myEntities = new Entities(ha);

        _instance = this;
        electricityRangeKeys = electiricityRanges.Keys.ToList();

        infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now, _myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);


        scheduler.ScheduleCron("59 * * * *", () => UpdatePriceHourly());
        scheduler.ScheduleCron("0 * * * *", () => { infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now, _myEntities.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys); });

        scheduler.ScheduleCron("59 23 * * *", () => UpdatePriceDaily());
        scheduler.ScheduleCron("45 * * * *", () => EnergiPriceChengeAlert(ha));

        _myEntities?.Sensor.NordpoolKwhFiEur31001.StateAllChanges().Where(x => x?.New?.Attributes?.TomorrowValid == true && x.Old?.Attributes?.TomorrowValid == false).Subscribe(_ => { ReadOutEnergyUpdate(); });

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
    }


    public void ReadOutEnergyUpdate()
    {
        string message = "Energy update for tomorrow!";

        if (!_myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.TomorrowValid == false)
        {

            EnergyForecastInfo energyForecastInfo = GetEnergyForecast(_myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Tomorrow);

            message += " Prices will be mostly in " + GetNameOfRange(energyForecastInfo.majorityRange);
            message += " with avarage of " + Math.Round(energyForecastInfo.avarage * 100, 1) + " cents.";// Ranging from: " + Math.Round(energyForecastInfo.min * 100, 1) + " to " + Math.Round(energyForecastInfo.max * 100, 1) + " cents. ";


            message += "That's " + (_myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Average < energyForecastInfo.avarage ? "more" : "less") + " than today.";
        }


        TTS.Speak(message);



    }
    private EnergyForecastInfo GetEnergyForecast<T>(IEnumerable<T>? list, int startFrom = 0)
    {
        EnergyForecastInfo energyForecastInfo = new EnergyForecastInfo();
        if (list == null) return energyForecastInfo;

        //Because Tomorrow values come as strings, we must make sure we convert values to doubles first
        var tmp = list?.Select(x => double.Parse(x.ToString())).ToList();

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


        for (int i = startFrom; i < tmp.Count - 1; i++)
        {

            var rangeForPrice = FindRangeForPrice(tmp.ElementAt(i));

            if (!foundPerRange.ContainsKey(rangeForPrice)) foundPerRange.Add(rangeForPrice, 1);
            else foundPerRange[rangeForPrice]++;
        }


        energyForecastInfo.avarage = avg;
        energyForecastInfo.max = max;
        energyForecastInfo.min = min;
        energyForecastInfo.majorityRange = foundPerRange.MaxBy(x => x.Value).Key; ;


        return energyForecastInfo;

    }



    public void MorningTTS()
    {

        string TTSMessage = "Good Morning. Current Electricity Cost is " + (infoForCurrentHour.range == -1 ? "Unknown" : "at " + electiricityRanges.Values.ElementAt(infoForCurrentHour.range));



        ElectricityPriceInfo inFoForNextHour = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

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

       

        SendTTS(TTSMessage);

    }

    public void SendTTS(string messsage)
    {
        Console.WriteLine(messsage);
        // This uses the google service you may use some other like google cloud version, google_cloud_say
        TTS.Speak(messsage);
    }

    private void EnergiPriceChengeAlert(IHaContext ha)
    {

        if (_myEntities.InputBoolean.Isasleep.State == "on") return;


        bool checkTomorrow = DateTime.Now.Hour == 23;


        ElectricityPriceInfo inFoForNextHour = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        PriceChangeType priceChange = infoForCurrentHour.Compare(inFoForNextHour);

        if (priceChange == PriceChangeType.NoChange) return;


        string TTSMessage;

        if (priceChange == PriceChangeType.Increase)
        {
            TTSMessage = "Electricity Warning.The Price is About to increase to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range);
        }
        else
        {
            TTSMessage = "Electricity Notice. The Price is About to fall to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range);
        }


        var hoursTillChange = FindWhenElectricityRangeChanges(inFoForNextHour);

        var timeDiff = hoursTillChange.dateTime - inFoForNextHour.dateTime;

        PriceChangeType priceChangeType = inFoForNextHour.Compare(hoursTillChange);

        if (priceChangeType == PriceChangeType.NoChange)
        {
            TTSMessage += ". And stays like that for while.";
        }
        else
        {

            TTSMessage += ". And will " + (priceChangeType == PriceChangeType.Increase ? "increase to " : "decrease to ") + GetNameOfRange(hoursTillChange.range) + " after " + GetHoursAndMinutesFromTimeSpan(timeDiff);
        }


        SendTTS(TTSMessage);
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
        Descrease

    }
    private class ElectricityPriceInfo
    {

        public double? price;
        public DateTime dateTime;
        public int range;



        public ElectricityPriceInfo(DateTime time, NumericSensorEntity? nordPoolEntity, List<double>? electricityRangeKeys)
        {
            bool isToday = time.Date == DateTime.Now.Date;
            IReadOnlyList<double>? day = isToday ? nordPoolEntity?.EntityState?.Attributes?.Today : nordPoolEntity?.EntityState?.Attributes?.Tomorrow as IReadOnlyList<double>;
            price = day?.ElementAt(time.Hour);
            range = FindRangeForPrice(price, electricityRangeKeys);
            dateTime = time;
        }

        public PriceChangeType Compare(ElectricityPriceInfo endPoint)
        {
            if (range == endPoint.range) return PriceChangeType.NoChange;
            if (range > endPoint.range) return PriceChangeType.Descrease;
            else return PriceChangeType.Increase;
        }

        private int FindRangeForPrice(double? price, List<double>? electricityRangeKeys)
        {
            var range = electricityRangeKeys?.FindIndex(x => x > price);
            range = range == -1 ? 1 : range;

            return (int)range - 1;
        }

    }

    private ElectricityPriceInfo FindWhenElectricityRangeChanges(ElectricityPriceInfo startInfo)
    {

        ElectricityPriceInfo nextInfo = null;// = new ElectricityPriceInfo(currentHour, _myEntities.Sensor.NordpoolKwhFiEur31001, electricityRangeKeys);

        int maxSearchHours = 12;

        for (int searchCounter = 1; searchCounter < maxSearchHours; searchCounter++)
        {
            nextInfo = new ElectricityPriceInfo(startInfo.dateTime.AddHours(searchCounter), _myEntities.Sensor.NordpoolKwhFiEur31001, electricityRangeKeys);

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


    private void UpdatePriceHourly()
    {
        if (_myEntities == null) return;



        var thisHourFortum = _myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * marginOfErrorFix * _myEntities.Sensor?.NordpoolKwhFiEur31001?.State + _myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * marginOfErrorFix * _myEntities.InputNumber.EnergyFortumHardCost.State;
        thisHourFortum += thisHourFortum * (_myEntities.InputNumber.EnergyFortumAlv.State / 100);

        var thisHourTranster = _myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * marginOfErrorFix * _myEntities.InputNumber.EnergyTransferCost.State;
        thisHourTranster += thisHourTranster * _myEntities.InputNumber.EnergyTransferAlv.State;


        var thisHourTotal = thisHourFortum + thisHourTranster;



        _myEntities.InputNumber.EnergyCostDaily.SetValue(_myEntities.InputNumber.EnergyCostDaily.State + thisHourTotal ?? 0);
        _myEntities.InputNumber.EnergyCostHourly.SetValue(thisHourTotal ?? 0);

    }

    private void UpdatePriceDaily()
    {
        if (_myEntities == null) return;

        _myEntities.InputNumber.EnergyCostHourly.SetValue(0);
        _myEntities.InputNumber.EnergyCostDaily.SetValue(0);

    }

}