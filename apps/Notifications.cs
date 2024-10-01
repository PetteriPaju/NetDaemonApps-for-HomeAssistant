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
using NetDaemon.HassModel.Entities;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class Notifications
    {
        public static InputBooleanEntity? _sensorsOnBooleanEntity = null;

        public DateTime lastMemoryAlert = DateTime.MinValue;

        public Notifications() {

            _sensorsOnBooleanEntity = _0Gbl._myEntities.InputBoolean.SensorsActive;


            _0Gbl._myScheduler.ScheduleCron("30 * * * *", () => { if (DateTime.Now.Hour != 14) TTS.Speak("Hydration Check", TTS.TTSPriority.DoNotPlayInGuestMode, _0Gbl._myEntities.InputBoolean.NotificationHydrationCheck); });


            string gamingtime = "0" + (DateTime.Now.IsDaylightSavingTime() ? " 3 " : " 2 ") + "* * *";
            _0Gbl._myScheduler.ScheduleCron(gamingtime, () => TTS.Speak("Gaming Time",TTS.TTSPriority.DoNotPlayInGuestMode,_0Gbl._myEntities.InputBoolean.NotificationGamingTime));

            //_00_Globals._myEntities.BinarySensor.OpenCurtainLimit.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(10)).Subscribe(_ => { TTS.Speak("Open Curtains"); });

            _0Gbl._myEntities.Sensor.PcMemoryusage.StateChanges().Where(x => x?.New?.State > 90 && x?.Old?.State < 90).Subscribe(_ => { 
                if(lastMemoryAlert < DateTime.Now - TimeSpan.FromMinutes(2))
                {
                    TTS.Speak("Memory Alert, Memory Alert",TTS.TTSPriority.DoNotPlayInGuestMode, _0Gbl._myEntities.InputBoolean.NotificationMemoryAlert);
                    lastMemoryAlert = DateTime.Now;
                }

            });
            _0Gbl._myEntities.Sensor.MotoG8PowerLiteBatteryLevel.StateChanges().Where(x => x?.New?.State < 15 && _0Gbl._myEntities.InputBoolean.Ishome.State == "on" && _0Gbl._myEntities.BinarySensor.MotoG8PowerLiteIsCharging.State == "off").Subscribe(_ => { TTS.Speak("Phone Battery Low", TTS.TTSPriority.DoNotPlayInGuestMode, _0Gbl._myEntities.InputBoolean.NotificationPhoneBattery); });
            _0Gbl._myEntities.Sensor.MotoG8PowerLiteBatteryLevel.StateChanges().Where(x => x?.New?.State < 50 && x?.Old?.State >= 50 && _0Gbl._myEntities.BinarySensor.MotoG8PowerLiteIsCharging.State == "off").Subscribe(_ => { TTS.Speak("Phone Battery Under 50%", TTS.TTSPriority.DoNotPlayInGuestMode, _0Gbl._myEntities.InputBoolean.NotificationPhoneBattery); });


            _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Where(x => x.New.IsOn()).Subscribe(_ => {
                if (_0Gbl._myEntities.BinarySensor.SolarChargingLimit.IsOn() && _0Gbl._myEntities.Sensor.EcoflowSolarInPower.State == 0)
                 {
               TTS.Speak("There is potential for solar charging");
                 }
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
