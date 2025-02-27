using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class LightsAndSensors
    {
        public static readonly TimeSpan defaulMotionTimeout = new TimeSpan(0, 0, 10);

        public static readonly double defaultFluz = 700;
        DateTime lastStorageOff = DateTime.MinValue;
        public LightsAndSensors()
        {
       
            SubcribeLightOn(A0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, A0Gbl._myEntities.Light.HallwayLight);
            SubcribeLightOff(A0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, A0Gbl._myEntities.Light.HallwayLight, defaulMotionTimeout);

            A0Gbl._myEntities.BinarySensor.StorageSensorOccupancy.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => {

                lastStorageOff = DateTime.Now;

            });

            SubcribeLightOff(A0Gbl._myEntities.BinarySensor.StorageSensorAqaraOccupancy, A0Gbl._myEntities.Light.StorageLight2, new TimeSpan(0, 0, 5));

        }

        private void SubcribeLightOn(BinarySensorEntity sensor, LightEntity light, Func<bool>? extraConditions = null, NumericSensorEntity? fluzSensor = null, double maxFlux = double.MaxValue)
        {          
            sensor.StateChanges().Where(e => e.New?.State == "on" && A0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && (extraConditions == null || extraConditions.Invoke())).Subscribe(_ => { light.TurnOnWithSensor(fluzSensor, maxFlux); });
        }

        private void SubcribeLightOff(BinarySensorEntity sensor, LightEntity light, TimeSpan offTime, Func<bool>? extraConditions = null)
        {
            sensor.StateChanges().Where(e => extraConditions != null ? extraConditions.Invoke() : true).WhenStateIsFor(e => e.IsOff() && A0Gbl._myEntities.InputBoolean.SensorsActive.IsOn(), offTime,A0Gbl._myScheduler).Subscribe(e => { light.TurnOffLight(); });
            //extraConditions != null ? extraConditions.Invoke() : true
        }


    }
}
