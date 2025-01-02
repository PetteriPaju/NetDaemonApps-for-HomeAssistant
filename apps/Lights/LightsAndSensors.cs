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
        private readonly TimeSpan defaulMotionTimeout = new TimeSpan(0, 0, 10);
        public static NumericSensorEntity luxSensorEntity;
        private readonly double defaultFluz = 700;
        DateTime lastStorageOff = DateTime.MinValue;
        public LightsAndSensors()
        {
            luxSensorEntity = A0Gbl._myEntities.Sensor.StorageSensorAqaraIlluminanceLux;
            SubcribeLightOn(A0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, A0Gbl._myEntities.Light.HallwayLight);
            SubcribeLightOff(A0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, A0Gbl._myEntities.Light.HallwayLight, defaulMotionTimeout);

            A0Gbl._myEntities.BinarySensor.StorageSensorOccupancy.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => {

                lastStorageOff = DateTime.Now;

            });

            SubcribeLightOff(A0Gbl._myEntities.BinarySensor.StorageSensorAqaraOccupancy, A0Gbl._myEntities.Light.StorageLight2, new TimeSpan(0, 0, 5));

            SubcribeLightOn(A0Gbl._myEntities.BinarySensor.StorageSensorAqaraOccupancy, A0Gbl._myEntities.Light.StorageLight2);

            A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().Where(x => x.New?.State == "approach" ).Subscribe(_ => {
                A0Gbl._myEntities.Light.KitchenLight2.TurnOnWithSensor(A0Gbl._myEntities.Sensor.OutdoorsBrightness, defaultFluz);
            });


            A0Gbl._myEntities.BinarySensor.Livingroomfp1Presence.StateChanges().Where(x => x.New.IsOff() && A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.IsOff()).Subscribe(_ => {

                A0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
            });

            A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().WhenStateIsFor(x=> (x?.State != "approach") && A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.IsOff(), TimeSpan.FromSeconds(50), A0Gbl._myScheduler).Subscribe(_ => {
                A0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
            });



            A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().Where(x => ((bool)x?.New.IsOn())).Subscribe( _ => {
                A0Gbl._myEntities.Light.KitchenLight2.TurnOnWithSensor(A0Gbl._myEntities.Sensor.OutdoorsBrightness, defaultFluz);
                IsHomeManager.CancelIsHome();
            });

            A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().WhenStateIsFor(x => ((bool)x?.IsOff()), TimeSpan.FromSeconds(50), A0Gbl._myScheduler).Subscribe(_ => {
              
                if (A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.State != "approach")
                {
                    A0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
                }
            });
            /*
           _00_Globals._myEntities.BinarySensor.KitchenSensorOccupancy.StateChanges().Where(x => x.New.IsOn()).Subscribe(_ => {
               _00_Globals._myEntities.Light.KitchenLight2.TurnOnWithSensor(_00_Globals._myEntities.Sensor.OutsideTemperatureMeterLuminosity, 3);
           });

           _00_Globals._myEntities.Sensor.KitchenSensors.StateChanges().WhenStateIsFor(x => x?.State == "False", TimeSpan.FromSeconds(1)).Subscribe(_ => {
               _00_Globals._myEntities.Light.KitchenLight2.TurnOffLight();
           });
           */


            A0Gbl._myEntities.BinarySensor.KitchenSensorOccupancy.StateChanges().Where(x => x?.New?.State == "on" && A0Gbl._myEntities.Light.AllLights.IsOff() && A0Gbl._myEntities.Light.AllLights?.EntityState?.LastChanged< DateTime.Now + TimeSpan.FromSeconds(30) && A0Gbl._myEntities.InputBoolean.GuestMode.IsOff()).SubscribeAsync(async s => {

                A0Gbl._myEntities.Light.HallwayLight.TurnOnWithSensor(A0Gbl._myEntities.Sensor.OutdoorsBrightness, defaultFluz);

                await Task.Delay(30000);

                if (A0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy.IsOff())
                {
                    A0Gbl._myEntities.Light.HallwayLight.TurnOffLight();
                }

            });
      
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
