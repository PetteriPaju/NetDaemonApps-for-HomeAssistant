using HomeAssistantGenerated;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.Extensions.Tts;
using NetDaemonApps.apps;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using YamlDotNet.Serialization.NodeTypeResolvers;
using System.IO.Pipelines;
using System;
// Use unique namespaces for your apps if you going to share with others to avoid
// conflicting names
namespace Extensions.Scheduling;

/// <summary>
///     Showcase the scheduling capabilities of NetDaemon
/// </summary>
/// 
[NetDaemonApp]
public class SchedulingApp
{
    private Entities _myEntities;
    private readonly Dictionary<double, string> electiricityRanges = new Dictionary<double, string>() { { 0, "Blue" }, { 0.075, "Green" }, { 0.15, "Yellow" }, {0.25, "Red"} };

    private readonly List<double>? electricityRangeKeys;

    private static SchedulingApp _instance;
    ElectricityPriceInfo infoForCurrentHour = null;


    

    public SchedulingApp(IHaContext ha, IScheduler scheduler)
    {
        _myEntities = new Entities(ha);
     
        _instance = this;
        electricityRangeKeys = electiricityRanges.Keys.ToList();

        infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now, _myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);


        scheduler.ScheduleCron("59 * * * *", () => UpdatePriceHourly());
        scheduler.ScheduleCron("0 * * * *", () => { infoForCurrentHour = new ElectricityPriceInfo(DateTime.Now, _myEntities.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys); });
       
        scheduler.ScheduleCron("59 23 * * *", () => UpdatePriceDaily());
        scheduler.ScheduleCron("45 * * * *", () => EnergiPriceChengeAlert(ha));
     
       _myEntities.Sensor.NordpoolKwhFiEur31001.StateAllChanges().Where(x => x?.New?.Attributes?.TomorrowValid == true && x.Old?.Attributes?.TomorrowValid == false).Subscribe(_ => { TTS._instance.Speak("Energy Prices Update"); });
 
    }

    public static void ReadOutGoodMorning()
    {
        _instance?.MorningTTS();
    }




    public void MorningTTS()
    {

        string TTSMessage =  "Good Morning. Current Electricity Cost is " + (infoForCurrentHour.range == -1 ? "Unknown" : "at " + electiricityRanges.Values.ElementAt(infoForCurrentHour.range));



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


            TTSMessage += electiricityRanges.Values.ElementAt(infoForCurrentHour.range);
            TTSMessage += " in " + (60 - DateTime.Now.Minute) + " minutes";
        }


        SendTTS(TTSMessage);

    }

    public void SendTTS(string messsage)
    {
        Console.WriteLine(messsage);
        // This uses the google service you may use some other like google cloud version, google_cloud_say
       TTS._instance?.Speak(messsage);
    }

    private void EnergiPriceChengeAlert(IHaContext ha)
    {

        if (_myEntities.InputBoolean.Isasleep.State == "on") return;


        bool checkTomorrow = DateTime.Now.Hour == 23;


        ElectricityPriceInfo inFoForNextHour = new ElectricityPriceInfo(DateTime.Now.AddHours(1), _myEntities?.Sensor?.NordpoolKwhFiEur31001, electricityRangeKeys);

        PriceChangeType priceChange = infoForCurrentHour.Compare(inFoForNextHour);

        if (priceChange == PriceChangeType.NoChange) return;


        string TTSMessage;

        if(priceChange == PriceChangeType.Increase)
        {
            TTSMessage = "Electricity Warning.The Price is About to increase to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range);
        }
        else
        {
            TTSMessage = "Electricity Notice. The Price is About to fall to " + electiricityRanges.Values.ElementAt(inFoForNextHour.range);
        }



        bool increaseForecast;
        var hoursTillChange = FindWhenElectricityRangeChanges(inFoForNextHour);

        var timeDiff = (hoursTillChange.dateTime - inFoForNextHour.dateTime);
        
        PriceChangeType priceChangeType = inFoForNextHour.Compare(hoursTillChange);

     
        Console.WriteLine(inFoForNextHour.dateTime);

        if (priceChangeType == PriceChangeType.NoChange)
        {
            TTSMessage += ". And will noot fall for a while";
        }
        else
        {

            TTSMessage += ". And will " + (priceChangeType == PriceChangeType.Increase ? "increase to " : "decrease to ") + GetNameOfRange(hoursTillChange.range) +  " after " + GetHoursAndMinutesFromTimeSpan(timeDiff);
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
        var and = (input.Hours > 0 && input.Minutes > 0 ? " and " : "");
        var minute = input.Minutes > 0 ? (input.Minutes.ToString() + " minute" + (input.Minutes > 1 ? "s" : "")) : "";


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
            if(range == endPoint.range) return PriceChangeType.NoChange;
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

        return (int)range-1;
    }


    private void UpdatePriceHourly()
    {
        if (_myEntities == null) return;

       
        var thisHourFortum = (_myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * _myEntities.Sensor?.NordpoolKwhFiEur31001?.State) + (_myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * _myEntities.InputNumber.EnergyFortumHardCost.State);
        thisHourFortum += thisHourFortum * (_myEntities.InputNumber.EnergyFortumAlv.State /100);

        var thisHourTranster = _myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * (_myEntities.InputNumber.EnergyTransferCost.State);
        thisHourTranster += thisHourTranster * (_myEntities.InputNumber.EnergyTransferAlv.State);


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