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
        private IDisposable? cancelRoutine = null;
      
        public Livingroom_Switch() : base() {

            A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.StateChanges().WhenStateIsFor(x => x?.State < 5, TimeSpan.FromMinutes(10), A0Gbl._myScheduler).Subscribe(x => {

                DeActivateRunningPad();

                A0Gbl._myEntities.Switch.ModemAutoOnPlug.TurnOff();

            });
            A0Gbl._myEntities.Switch.ModemAutoOnPlug.StateChanges().Where(x => x.New.IsOn()).Subscribe(x => { ActivateRunningPad(); });
        }
  

        protected bool hasProcess()
        {
            return A0Gbl._myEntities.Sensor.PcWalkingpadActive.State == "1";
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
            A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(wasPlugOn ? 0 : 5), A0Gbl._myEntities.Button.PcStartrunningpadprocess.Press);
            }
 

        }

        protected void DeActivateRunningPad()
        {
            bool wasRunning = false;
            if(A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.State > 15)
            {
                ToggleRunner();
                wasRunning = true;
            }

            if (hasProcess())
            {
                A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(wasRunning ? 0 : 30), A0Gbl._myEntities.Button.PcStopwalkingpadprocess.Press);
            }

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
            return entities.Sensor.HueSwitchBedAction;
            
        }

        protected override void OnPowerRelease()
        {
            base.OnPowerPress();
            if (runnerSwitch.IsOff() || A0Gbl._myEntities.Sensor.PcWalkingpadActive.State != "1")
            {
                ActivateRunningPad();
                return;
            }
            else
            {
                ToggleRunner();
            }
            
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
            A0Gbl._myEntities.Button.PcWalkingpadspeedup.Press();


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

            if (hasProcess())
            {
                DeActivateRunningPad();
            }
            else
            {
                ActivateRunningPad();
            }

         
        }




    }
}
