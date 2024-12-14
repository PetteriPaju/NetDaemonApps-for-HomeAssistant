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
        private IDisposable? cancelRoutine = null;
      
        public Livingroom_Switch() : base() { }
  


        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchBedAction;
        }

        protected override void OnPowerRelease()
        {
            base.OnPowerPress();
            A0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle();
        }
  
        protected override void OnPowerHoldRelease()
        {
            base.OnPowerHoldRelease();
            A0Gbl._myEntities.Switch.InkplatePlug.Toggle();
        }

        protected override void OnAnyPress()
        {
            base.OnAnyPress();
            //  _0Gbl._myEntities.Switch.TvPowerMeter.TurnOn();
        }

        protected override void OnDownPressRelease()
        {
            base.OnDownPressRelease();
            if (cancelRoutine != null)
            {
                cancelRoutine.Dispose();
                var message = "Cancelled";
                cancelRoutine = null;
                TTS.Speak(message, TTS.TTSPriority.IgnoreSleep);
            }

        }
        protected override void OnUpPressRelease()
        {
            base.OnUpPressRelease();

            if (cancelRoutine != null)
            {
                cancelRoutine.Dispose();
                cancelRoutine = null;
                var message = "Cancelled";
                TTS.Speak(message, TTS.TTSPriority.IgnoreSleep);
            }

        }
        protected override void OnUpHoldRelease()
        {
            base.OnUpHoldRelease();
            string message = "";
            if (cancelRoutine != null) {
                cancelRoutine.Dispose();
                cancelRoutine = null;
                message = "Cancelled";
            }
            else {

                if (A0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn())
                {
                    message = "Modem Off";
                }
                else
                {
                    message = "Modem On";
                }
         
                cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(A0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() ? 10 : 0), () => {
                        A0Gbl._myEntities.Switch.ModemAutoOnPlug.Toggle();
                    

                    cancelRoutine = null;

                });
            }
            TTS.Speak(message, TTS.TTSPriority.IgnoreSleep);

        }
        protected override void OnDownHoldRelease()
        {

            base.OnDownHoldRelease();
            string message = "";
            if (cancelRoutine != null)
            {
                cancelRoutine.Dispose();
                cancelRoutine = null;
                message = "Cancelled";
            }
            else
            {
                 message = "Everything off";

                cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(10), () => {

                    A0Gbl._myEntities.Script.TurnOffEverything.TurnOn();
                    cancelRoutine = null;

                });
            }
            TTS.Speak(message, TTS.TTSPriority.IgnoreSleep);
        }


        protected override void OnHueHoldRelease()
        {

            base.OnHueRelease();
            TimeSpan? timeDiff = DateTime.Now - A0Gbl._myEntities?.InputDatetime.Lastisasleeptime.GetDateTime();
            string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture); 
            if(A0Gbl._myEntities.InputBoolean.Isasleep.IsOn()) ttsTime += ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ? " and " + timeDiff?.Minutes + "minutes" : ". ");

            TTS.Speak(ttsTime,TTS.TTSPriority.IgnoreAll);
        }


        protected override void OnHueRelease()
        {
            base.OnHueRelease();
            IsAsleepMonitor.ToggleMode();
        }




    }
}
