using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class SleepAnalyzer
    {
        public static SleepAnalyzer instance { get; private set; }

        public enum SleepState {
        
        NotAsleep,
        Rem,
        Light,
        Deep,
        Unknown
   
        };

        public SleepState state { get; private set; }

        public bool isSleeping { get { return state != SleepState.NotAsleep && state != SleepState.Unknown; } }
        public bool inBed { get { return _0Gbl._myEntities.BinarySensor.WithingsInBed.IsOn(); } }
        public BinarySensorEntity InBedSensorEntity { get { return _0Gbl._myEntities.BinarySensor.WithingsInBed; } }

        public void EnforceAwake()
        {
            state = SleepState.NotAsleep;
            _0Gbl._myEntities.InputText.WithingsSleepState.SetValue("NotAsleep");
        }

        public SleepAnalyzer() {

            instance = this;

            _0Gbl._myEntities.Sensor.WithingsDeepSleep.StateChanges().Where(x => x.New.State != null && x.Old.State != null).Subscribe(x => {

                state = SleepState.Deep;
                _0Gbl._myEntities.InputText.WithingsSleepState.SetValue("Deep");
            
            });
            _0Gbl._myEntities.Sensor.WithingsLightSleep.StateChanges().Where(x => x.New.State != null && x.Old.State != null).Subscribe(x => {

                state = SleepState.Light;
                _0Gbl._myEntities.InputText.WithingsSleepState.SetValue("Light");

            });

            _0Gbl._myEntities.Sensor.WithingsRemSleep.StateChanges().Where(x => x.New.State != null && x.Old.State != null).Subscribe(x => {

                state = SleepState.Rem;
                _0Gbl._myEntities.InputText.WithingsSleepState.SetValue("Rem");

            });

            _0Gbl._myEntities.BinarySensor.WithingsInBed.StateChanges().Where(x => x.New.IsOff()).Subscribe(x => {
                state = SleepState.NotAsleep;
                _0Gbl._myEntities.InputText.WithingsSleepState.SetValue("NotAsleep");
            });

        }
    }
}
