using HomeAssistantGenerated;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.Extensions.Tts;
using NetDaemonApps.apps;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
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
    private readonly Dictionary<double, string> electiricityRanges = new Dictionary<double, string>() { { 0.15, "Blue" }, { 0.3, "Yellow" }, { 0.5, "Red" } };
    private int currentRangeIndex = 0;

    private static SchedulingApp _instance;


    public SchedulingApp(IHaContext ha, IScheduler scheduler)
    {
        _myEntities = new Entities(ha);
        _instance = this;
        scheduler.ScheduleCron("59 * * * *", () => UpdatePriceHourly());
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
        currentRangeIndex = GetCurrentElectricityRangeIndex(_myEntities?.Sensor?.NordpoolKwhFiEur31001);
        SendTTS("Good Morning. Current Electricity Cost is " + (currentRangeIndex == -1 ? "Unknown" : "at" + electiricityRanges.Values.ElementAt(currentRangeIndex)));
    }

    public void SendTTS(string messsage)
    {
        // This uses the google service you may use some other like google cloud version, google_cloud_say
       TTS._instance?.Speak(messsage);
    }

    private void EnergiPriceChengeAlert(IHaContext ha)
    {

        if (_myEntities.InputBoolean.Isasleep.State == "on") return;

        int nextElectricityRange = GetCurrentElectricityRangeIndex(_myEntities?.Sensor?.NordpoolKwhFiEur31001);

        if (nextElectricityRange == currentRangeIndex) return;


        string TTSMessage;

        if (nextElectricityRange == -1) {
            TTSMessage = "Electricity Warning. The current range is unkown";
        }
        else if(nextElectricityRange > currentRangeIndex)
        {
            TTSMessage = "Electricity Warning.The Price is About to increase to" + electiricityRanges.Values.ElementAt(nextElectricityRange);
        }
        else
        {
            TTSMessage = "Electricity Notice. The Price is About to fall to" + electiricityRanges.Values.ElementAt(nextElectricityRange);
        }

        currentRangeIndex = nextElectricityRange;
        SendTTS(TTSMessage);
    }

    private int GetCurrentElectricityRangeIndex(NumericSensorEntity? nordPoolEntity)
    {
        if (nordPoolEntity == null) return -1;

        int tmpRangeIndex = electiricityRanges.Count - 1;

        double? nextHourPrice = DateTime.Now.Hour < 23 ? nordPoolEntity?.EntityState?.Attributes?.Today?.ElementAt(DateTime.Now.Hour+1) : ((nordPoolEntity?.EntityState?.Attributes?.TomorrowValid == true) ? (nordPoolEntity?.EntityState?.Attributes?.Tomorrow as IReadOnlyList<double>)?.ElementAt(0) : -1);
       

        for (int i = electiricityRanges.Count-1; i>=0; i--)
        {
            if (nextHourPrice >= electiricityRanges.Keys.ElementAt(i))
            {
                break;
            }
            tmpRangeIndex = i;
        }

        return tmpRangeIndex;

    }


    private double calculateTotalEvergy()
    {
        return 0;
    }


    private void UpdatePriceHourly()
    {
        if (_myEntities == null) return;


        var thisHourFortum = (_myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * _myEntities.Sensor?.NordpoolKwhFiEur31001?.State) + (_myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * _myEntities.InputNumber.EnergyFortumHardCost.State);
        thisHourFortum += thisHourFortum * _myEntities.InputNumber.EnergyFortumAlv.State;

        var thisHourTranster = _myEntities.Sensor.TotalHourlyEnergyConsumptions.EntityState?.State * (_myEntities.InputNumber.EnergyTransferCost.State / 100);
        thisHourTranster += thisHourTranster * (_myEntities.InputNumber.EnergyTransferAlv.State/100);


        var thisHourTotal = thisHourFortum + thisHourTranster;



        _myEntities.InputNumber.EnergyCostDaily.SetValue(_myEntities.InputNumber.EnergyCostDaily.State + thisHourTotal ?? 0);
        _myEntities.InputNumber.EnergyCostHourly.SetValue(thisHourTotal ?? 0);


        Console.WriteLine(thisHourTotal);
        Console.WriteLine(_myEntities.InputNumber.EnergyCostDaily.State);
        Console.WriteLine("");

    }

    private void UpdatePriceDaily()
    { 
        if (_myEntities == null) return;

        _myEntities.InputNumber.EnergyCostHourly.SetValue(0);
        _myEntities.InputNumber.EnergyCostDaily.SetValue(0);

    }

}