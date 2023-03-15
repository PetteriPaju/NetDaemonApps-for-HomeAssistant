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
    public SchedulingApp(IHaContext ha, IScheduler scheduler)
    {
        _myEntities = new Entities(ha);

        scheduler.ScheduleCron("59 * * * *", () => UpdatePriceHourly(ha));
        scheduler.ScheduleCron("59 23 * * *", () => UpdatePriceDaily(ha));

        scheduler.ScheduleCron("50 * * * *", () => EnergiPriceChengeAlert(ha));


        _myEntities.Sensor.NordpoolKwhFiEur31001.StateAllChanges().Where(x => x?.New?.Attributes?.TomorrowValid == true && x.Old?.Attributes?.TomorrowValid == false).Subscribe(_ => { TTS._instance.Speak("Energy Prices Update"); }); 


        ha.Entity("input_boolean.isasleep")
           .StateChanges().Where(e => e.New?.State == "off")
           .Subscribe(_ => {

               currentRangeIndex = GetCurrentElectricityRangeIndex(_myEntities?.Sensor?.NordpoolKwhFiEur31001);
               SendTTS("Good Morning. Current Electricity Cost is " + (currentRangeIndex == -1 ? "Unknown" : "at" + electiricityRanges.Values.ElementAt(currentRangeIndex)));

           });

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
        else if(currentRangeIndex > nextElectricityRange)
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


        for (int i = electiricityRanges.Count-1; i>=0; i--)
        {
            currentRangeIndex = i;

            double? nextHourPrice = DateTime.Now.Hour < 23 ? nordPoolEntity?.EntityState?.Attributes?.Today?[DateTime.Now.Hour] : (nordPoolEntity?.EntityState?.Attributes?.TomorrowValid == true) ? (double?)nordPoolEntity?.EntityState?.Attributes?.Tomorrow?[0] : -1; 

            if (nextHourPrice >= electiricityRanges.Keys.ElementAt(i))
            {
                break;
            }
        }

        return currentRangeIndex;

    }


    private double calculateTotalEvergy(IHaContext ha)
    {
        return 0;
    }


    private void UpdatePriceHourly(IHaContext ha)
    {
        if (_myEntities == null) return;

        double val = _myEntities.InputNumber.EnergyCostHourly.State ?? 0 + (_myEntities.Sensor?.HourlyEnergy?.EntityState?.State ?? 0) * (_myEntities.Sensor?.NordpoolKwhFiEur31001?.State ?? 0);

        //_myEntities.InputNumber.EnergyCostHourly.SetValue(val);

       /* ha.CallService("notify", "persistent_notification",
                   data: new { message = val.ToString() , title = "Schedule!" });
       */

    }

    private void UpdatePriceDaily(IHaContext ha)
    {

    }

}