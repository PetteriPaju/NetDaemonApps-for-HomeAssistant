using HomeAssistantGenerated;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.Extensions.Tts;
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
    private ITextToSpeechService tts;
    public SchedulingApp(IHaContext ha, IScheduler scheduler, ITextToSpeechService ttsService)
    {
        _myEntities = new Entities(ha);
        tts = ttsService;
       
        var count = 0;
        /*
        scheduler.RunEvery(TimeSpan.FromHours(1), () =>
        {
            // Make sure we do not flood the notifications :)
            if (count++ < 3)
                ha.CallService("notify", "persistent_notification",
                    data: new {message = "This is a scheduled action!", title = "Schedule!"});
        });
        */

        scheduler.ScheduleCron("59 * * * *", () => UpdatePriceHourly(ha));
        scheduler.ScheduleCron("59 23 * * *", () => UpdatePriceDaily(ha));

        scheduler.ScheduleCron("50 * * * *", () => EnergiPriceChengeAlert(ha));
       
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
        tts.Speak("media_player.vlc_telnet", messsage, "picotts_say");
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
            if (nordPoolEntity?.State >= electiricityRanges.Keys.ElementAt(i))
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