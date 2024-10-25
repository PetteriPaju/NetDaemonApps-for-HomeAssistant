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
            _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle();
        }
  
        protected override void OnPowerHoldRelease()
        {
            base.OnPowerHoldRelease();
            _0Gbl._myEntities.Switch.InkplatePlug.Toggle();
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

                if (_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn())
                {
                    message = "Modem Off";
                }
                else
                {
                    message = "Modem On";
                }
         
                cancelRoutine = _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() ? 10 : 0), () => {

                    
                    if(_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() && _0Gbl._myEntities.BinarySensor.ZatnasPing.IsOn())
                    {
                    _0Gbl._myServices.Script.TurnOffServer();
                     _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() ? 5 : 0), () => {
                         _0Gbl._myEntities.Switch.ModemAutoOnPlug.Toggle();
                     });
                    }
                    else
                    {
                        _0Gbl._myEntities.Switch.ModemAutoOnPlug.Toggle();
                    }


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

                cancelRoutine = _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(10), () => {

                    _0Gbl._myEntities.Script.TurnOffEverything.TurnOn();
                    cancelRoutine = null;

                });
            }
            TTS.Speak(message, TTS.TTSPriority.IgnoreSleep);
        }


        protected override void OnHueRelease()
        {

            base.OnHueRelease();
            TimeSpan? timeDiff = DateTime.Now - _0Gbl._myEntities?.InputBoolean?.Isasleep?.EntityState?.LastChanged;
            string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture); 
            if(_0Gbl._myEntities.InputBoolean.Isasleep.IsOn()) ttsTime += ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ? " and " + timeDiff?.Minutes + "minutes" : ". ");

            TTS.Speak(ttsTime,TTS.TTSPriority.IgnoreAll);
        }


        protected override void OnHueHoldRelease()
        {
            base.OnHueHoldRelease();
            IsAsleepMonitor.ToggleMode();
        }




    }
}
