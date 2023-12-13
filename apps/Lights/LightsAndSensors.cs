using HomeAssistantGenerated;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        private readonly double defaultFluz = 10;
        DateTime lastStorageOff = DateTime.MinValue;
        public LightsAndSensors()
        {
            luxSensorEntity = _0Gbl._myEntities.Sensor.StorageSensorAqaraIlluminanceLux;
            SubcribeLightOn(_0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, _0Gbl._myEntities.Light.HallwayLight);
            SubcribeLightOff(_0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy, _0Gbl._myEntities.Light.HallwayLight, defaulMotionTimeout);

            _0Gbl._myEntities.BinarySensor.StorageSensorOccupancy.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => {

                lastStorageOff = DateTime.Now;

            });

            SubcribeLightOff(_0Gbl._myEntities.BinarySensor.StorageSensorAqaraOccupancy, _0Gbl._myEntities.Light.StorageLight2, new TimeSpan(0, 0, 5));

            SubcribeLightOn(_0Gbl._myEntities.BinarySensor.FridgeContactSensorContact, _0Gbl._myEntities.Light.KitchenLight2);

            _0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().Where(x => x.New?.State == "approach" ).Subscribe(_ => {
                _0Gbl._myEntities.Light.KitchenLight2.TurnOnLight();
            });


            _0Gbl._myEntities.BinarySensor.Livingroomfp1Presence.StateChanges().Where(x => x.New.IsOff() ).Subscribe(_ => {

                _0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
            });

            _0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().WhenStateIsFor(x=> (x?.State != "approach"), TimeSpan.FromSeconds(30)).Subscribe(_ => {
                _0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
            });



            _0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().Where(x => (x?.New?.State == "false" )).Subscribe( _ => {
                _0Gbl._myEntities.Light.KitchenLight2.TurnOn();
            });

            _0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().WhenStateIsFor(x => (x?.State == "true"), TimeSpan.FromSeconds(30)).Subscribe(_ => {
              
                if (_0Gbl._myEntities.BinarySensor.Livingroomfp1Presence.IsOff())
                {
                    _0Gbl._myEntities.Light.KitchenLight2.TurnOff();
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


            _0Gbl._myEntities.BinarySensor.KitchenSensorOccupancy.StateChanges().Where(x => x?.New?.State == "on" && _0Gbl._myEntities.Light.AllLights.IsOff() && _0Gbl._myEntities.Light.AllLights?.EntityState?.LastChanged< DateTime.Now + TimeSpan.FromSeconds(30) && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff()).SubscribeAsync(async s => {

                _0Gbl._myEntities.Light.HallwayLight.TurnOn();

                await Task.Delay(30000);

                if (_0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy.IsOff())
                {
                    _0Gbl._myEntities.Light.HallwayLight.TurnOffLight();
                }

            });
      
        }

        private void SubcribeLightOn(BinarySensorEntity sensor, LightEntity light, Func<bool>? extraConditions = null, NumericSensorEntity? fluzSensor = null, double maxFlux = double.MaxValue)
        {          
            sensor.StateChanges().Where(e => e.New?.State == "on" && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && (extraConditions == null || extraConditions.Invoke())).Subscribe(_ => { light.TurnOnWithSensor(fluzSensor, maxFlux); });
        }

        private void SubcribeLightOff(BinarySensorEntity sensor, LightEntity light, TimeSpan offTime, Func<bool>? extraConditions = null)
        {
            sensor.StateChanges().Where(e => extraConditions != null ? extraConditions.Invoke() : true).WhenStateIsFor(e => e.IsOff() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn(), offTime,_0Gbl._myScheduler).Subscribe(e => { light.TurnOffLight(); });
            //extraConditions != null ? extraConditions.Invoke() : true
        }


    }
}
