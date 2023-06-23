using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using System.Linq;
using System.Reactive.Concurrency;
using static NetDaemonApps.apps.MediaPlayingMonitor;
using System.Text.Json;
using System.Collections.Generic;
using System.Xml;
using NetDaemon.HassModel.Integration;
using YamlDotNet.Serialization;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class Notifications
    {
        protected readonly Entities _myEntities;
        public static InputBooleanEntity? _sensorsOnBooleanEntity = null;
  

        public Notifications(IHaContext ha, IScheduler scheduler) {



            _myEntities = new Entities(ha);
            _sensorsOnBooleanEntity = _myEntities.InputBoolean.SensorsActive;

            var SERVICES = new Services(ha);

            




            scheduler.ScheduleCron("30 * * * *", () => TTS.Speak("Hydration Check"));


            string gamingtime = "0" + (DateTime.Now.IsDaylightSavingTime() ? " 3 " : " 2 ") + "* * *";
            scheduler.ScheduleCron(gamingtime, () => TTS.Speak("Gaming Time"));

            //_myEntities.BinarySensor.OpenCurtainLimit.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(10)).Subscribe(_ => { TTS.Speak("Open Curtains"); });

            _myEntities.Sensor.PcMemoryusage.StateChanges().Where(x => x?.New?.State > 80 && x?.Old?.State < 90).Subscribe(_ => { TTS.Speak("Memory Alert, Memory Alert"); });
            _myEntities.Sensor.MotoG8PowerLiteBatteryLevel.StateChanges().Where(x => x?.New?.State < 15 && _myEntities.InputBoolean.Ishome.State == "on" && _myEntities.BinarySensor.MotoG8PowerLiteIsCharging.State == "off").Subscribe(_ => { TTS.Speak("Phone Battery Low"); });
            _myEntities.Sensor.OutsideTemperatureMeterTemperature.StateChanges().WhenStateIsFor(x => x?.State == "Unavailable", TimeSpan.FromMinutes(5)).Subscribe(_=> {
           //   TTS.Speak("Warning Wifi Might Be Down", TTS.TTSPriority.IgnoreDisabled);

            });





        }

        public record ActionableNotificationResponseData
        {
            [JsonPropertyName("action")] public string? action { get; init; }    
            [JsonPropertyName("data")] public JsonElement? data { get; init; }

            [JsonPropertyName("tag")] public string? tag { get; init; }


        }

        public class Actionable_NotificationData
        {
          
            public string message { get; set; }
            public Dictionary<string, List<ActionableData>> data { get; set; }
           

            public Actionable_NotificationData(string message)
            {
                this.message = message;
                data = new Dictionary<string, List<ActionableData>>();
             
             
            }


            public void PushToData(string key, List <ActionableData> value)
            {
                data.Add(key, value);
            }


        }


        [JsonDerivedType(typeof(TapableAction))]
        [JsonDerivedType(typeof(TimeoutData))]
        public class ActionableData
        {

        }
        public class TimeoutData : ActionableData
        {

            public int timeout { get; set; }
            public TimeoutData(int timeout)
            {
                this.timeout = timeout;
            }

        

            public override string ToString()
            {
                return timeout.ToString();
            }
        }

            public class TapableAction : ActionableData
        {
            public string? tag { get; set; } = null;
            public string? action { get; set; } = null;
            public string? title { get; set; } = null;

            public int? timeout { get; set; } = 5;

            public TapableAction(string? action = null, string? title = null, string? tag =  null, int? timeout = null)
            {
                this.action = action;
                this.title = title;
                this.tag = tag;
                this.timeout = timeout;

            }


            
        }


    }
}
