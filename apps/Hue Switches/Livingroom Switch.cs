﻿using HomeAssistantGenerated;
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
        private IDisposable? speedIncrementRoutine = null;
      
        public Livingroom_Switch() : base() {

            A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.StateChanges().WhenStateIsFor(x => x?.State < 19, TimeSpan.FromMinutes(30), A0Gbl._myScheduler).Subscribe(x => {

                DeActivateRunningPad();
                SafeTurnOff();

            });

            A0Gbl._myEntities.Switch.ModemAutoOnPlug.StateChanges().Where(x => x.New.IsOn()).Subscribe(x => { ActivateRunningPad(); });

                A0Gbl._myEntities.Sensor.PcWalkingpadActive.StateChanges().Where(x => x.New.State == "1").Subscribe(x => {
                    speedIncrementRoutine?.Dispose();
                    speedIncrementRoutine = A0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(5),(DateTime.Now+TimeSpan.FromMinutes(5)), () => {


                        A0Gbl._myEntities.Button.PcWalkingpadSpeedupone.Press();
                    });
                });

            A0Gbl._myEntities.Sensor.PcWalkingpadActive.StateChanges().Where(x => x.New.State != "1").Subscribe(x => {
                speedIncrementRoutine?.Dispose();
            });
        }
  
        protected void SafeTurnOff()
        {
            if(A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.State > 15)
                A0Gbl._myEntities.Switch.ModemAutoOnPlug.TurnOff();
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
                A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(wasRunning ? 30 : 0), A0Gbl._myEntities.Button.PcStopwalkingpadprocess.Press);
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
            return entities.Sensor.HueSwitchRunnerAction;
            
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
