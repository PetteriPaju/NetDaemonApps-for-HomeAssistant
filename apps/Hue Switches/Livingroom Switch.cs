using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System.Diagnostics;
using System.Globalization;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps.Hue_Switches
{
    [NetDaemonApp]
    public class Livingroom_Switch : HueSwitch
    {
        private IDisposable? keepOnRoutine = null;
        public Livingroom_Switch() : base() { }
  


        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchLivingRoomAction;
        }

        protected override void OnPowerPress()
        {
            base.OnPowerPress();
            _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle();

        }

        protected override void OnAnyPress()
        {
            base.OnAnyPress();
            //  _0Gbl._myEntities.Switch.TvPowerMeter.TurnOn();
        }

        protected override void OnHuePress()
        {
            base.OnHuePress();
            TimeSpan? timeDiff = DateTime.Now - _0Gbl._myEntities?.InputBoolean?.Isasleep?.EntityState?.LastChanged;
            string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture); 
            if(_0Gbl._myEntities.InputBoolean.Isasleep.IsOn()) ttsTime += ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ? " and " + timeDiff?.Minutes + "minutes" : ". ");

            TTS.Speak(ttsTime,TTS.TTSPriority.IgnoreAll);
        }

        protected override void OnHueRelease()
        {
            //  _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle(); 
        }

        protected override void OnHueHoldRelease()
        {
            //  _0Gbl._myEntities.Script.ReadoutTime.TurnOn();
        }




    }
}
