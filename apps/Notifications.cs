using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class Notifications
    {
        protected readonly Entities _myEntities;
        public Notifications(IHaContext ha, IScheduler scheduler) {

            _myEntities = new Entities(ha);

            scheduler.ScheduleCron("30 * * * *", () => TTS._instance?.Speak("Hydration Check"));
            scheduler.ScheduleCron("0 2 * * *", () => TTS._instance?.Speak("Gaming Time"));

            _myEntities.BinarySensor.OpenCurtainLimit.StateChanges().WhenStateIsFor(x=>x?.State == "on", TimeSpan.FromMinutes(10)).Subscribe(_ =>{ TTS._instance?.Speak("Open Curtains"); });

            _myEntities.Sensor.PcMemoryusage.StateChanges().Where(x => x?.New?.State > 80).Subscribe(_ => { TTS._instance?.Speak("Memory Alert, Memory Alert"); });
            _myEntities.Sensor.MotoG8PowerLiteBatteryLevel.StateChanges().Where(x => x?.New?.State < 15 && _myEntities.InputBoolean.Ishome.State == "on" && _myEntities.BinarySensor.MotoG8PowerLiteIsCharging.State == "off").Subscribe(_ => { TTS._instance?.Speak("Phone Battery Low"); });


        }
    }
}
