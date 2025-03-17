using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System.Diagnostics;
using System.Globalization;
using System.Reactive.Concurrency;
using System;
using System.Linq;
using NetDaemon.Extensions.Scheduler;

namespace NetDaemonApps.apps.Hue_Switches
{
    [NetDaemonApp]
    public class Livingroom_Switch : HueSwitch
    {
        /*
        private IDisposable? cancelRoutine = null;
      
        public Livingroom_Switch() : base() {

                A0Gbl._myEntities.Sensor.PcWalkingpadActive2.StateChanges().Where(x => x.New.State == "1").Subscribe(x => {
                    speedIncrementRoutine?.Dispose();
                    speedIncrementRoutine = A0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(5),(DateTime.Now+TimeSpan.FromMinutes(5)), () => {
                        A0Gbl._myEntities.Button.PcWalkingpadSpeedupone.Press();
                    });
                });

            A0Gbl._myEntities.Sensor.PcWalkingpadActive2.StateChanges().Where(x => x.New.State != "1").Subscribe(x => {
                speedIncrementRoutine?.Dispose();
            });


            A0Gbl._myEntities.BinarySensor.WalkingpadContactSensorContact.StateChanges().Where(x => x.New.IsOff()).Subscribe(x => { ActivateRunningPad(); });
            A0Gbl._myEntities.BinarySensor.WalkingpadContactSensorContact.StateChanges().Where(x => x.New.IsOn()).Subscribe(x => { DeActivateRunningPad(); });

        }
  
        protected bool hasProcess()
        {
            return A0Gbl._myEntities.Sensor.PcWalkingpadActive2.State == "1";
        }
        protected SwitchEntity runnerSwitch { get { return A0Gbl._myEntities.Switch.ModemAutoOnPlug;  } }
        protected void ActivateRunningPad()
        {
            bool wasPlugOn = true;
            if (runnerSwitch.IsOff())
            {
                runnerSwitch.TurnOn();
                wasPlugOn = false;
            }

            if (!hasProcess())
            {
            A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(wasPlugOn ? 0 : 5), A0Gbl._myEntities.Button.PcWalkingpadprocessrun.Press);
            }
            else
            {
                A0Gbl._myEntities.Button.PcWalkingpadprocessrun.Press();    
            }
        }

        protected void DeActivateRunningPad()
        {

            runnerSwitch.TurnOff();
            A0Gbl._myEntities.Button.PcWalkingpadprocesskill.Press();


        }

        protected void ToggleRunner()
        {
            if (hasProcess())
            {
                Console.WriteLine("Toggle");
                A0Gbl._myEntities.Button.PcWalkingpadtoggle.Press();
            }
        }

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchRunnerAction;
            
        }

        protected override void OnPowerRelease()
        {
            base.OnPowerPress();
            ToggleRunner();
        }
  
        protected override void OnPowerHoldRelease()
        {
            base.OnPowerHoldRelease();
      
        }

        protected override void OnAnyPress()
        {
            base.OnAnyPress();
            //  _0Gbl._myEntities.Switch.TvPowerMeter.TurnOn();
        }

        protected override void OnDownPressRelease()
        {
            base.OnDownPressRelease();
            A0Gbl._myEntities.Button.PcCwalkingpadspeeddown.Press();


        }
        protected override void OnUpPressRelease()
        {
            base.OnUpPressRelease();

            A0Gbl._myEntities.Button.PcWalkingpadspeedup.Press();
        }

        protected override void OnUpHoldRelease()
        {
            base.OnUpHoldRelease();
          

        }
        protected override void OnDownHoldRelease()
        {

            base.OnDownHoldRelease();
    
        }


        protected override void OnHueHoldRelease()
        {

            base.OnHueRelease();

        }


        protected override void OnHueRelease()
        {
            base.OnHueRelease();
        
        }


*/

    }
        
}
