using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    public class NedisRemote
    {

        public NedisRemote() {

            RemoteEntity?.StateChanges().Subscribe(state => { handleSensor(state.New.State ?? ""); });
        }
        public virtual SensorEntity? RemoteEntity { get; private set; }

        private void handleSensor(string state)
        {
            if (RemoteEntity == null) return;

            switch (state)
            {
                case "emergency":
                    On_O();
                    break;
                case "arm_day_zones":
                    On_A();
                    break;
                case "arm_all_zones":
                    On_I();
                    break;
                case "disarm":
                    On_B();
                    break;

            }



        }
        protected virtual void OnAny() { }

        protected virtual void On_O() { OnAny(); }

        protected virtual void On_A() { OnAny(); }

        protected virtual void On_I() { OnAny(); }
        protected virtual void On_B() { OnAny(); }

    }
    [NetDaemonApp]
    public class TreadmillRemote : NedisRemote
    {


        public override SensorEntity? RemoteEntity => A0Gbl._myEntities.Sensor.KeychainAction;

        public TreadmillRemote() {

            A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.StateChanges().WhenStateIsFor(x => x?.State < 19, TimeSpan.FromMinutes(10), A0Gbl._myScheduler).Subscribe(x => {

                DeActivateRunningPad();
                A0Gbl._myEntities.Switch.ModemAutoOnPlug.TurnOff();

            });

            A0Gbl._myEntities.Switch.ModemAutoOnPlug.StateChanges().Where(x => x.New.IsOn()).Subscribe(x => { ActivateRunningPad(); });


        }

        protected bool hasProcess()
        {
            return A0Gbl._myEntities.Sensor.PcWalkingpadActive.State == "1";
        }
        protected SwitchEntity runnerSwitch { get { return A0Gbl._myEntities.Switch.ModemAutoOnPlug; } }
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
            if (A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.State > 15)
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

        protected override void On_O()
        {
            base.On_O();
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

        protected override void On_A()
        {
            base.On_A();
            if (A0Gbl._myEntities.Sensor.ModemAutoOnPlugPower.State < 15)
                runnerSwitch.Toggle();
            else
            {
                DeActivateRunningPad();
            }
        }

        protected override void On_I()
        {
            base.On_I();
            A0Gbl._myEntities.Button.PcWalkingpadspeedup.Press();
        }

        protected override void On_B()
        {
            base.On_B();
            A0Gbl._myEntities.Button.PcCwalkingpadspeeddown.Press();
        }


    }
    }
