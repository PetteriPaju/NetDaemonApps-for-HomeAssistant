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
        private Entities _myEntities;
        private readonly TimeSpan defaulMotionTimeout = new TimeSpan(0, 0, 10);

        public LightsAndSensors(IHaContext ha)
        {
            _myEntities = new Entities(ha);

            SubcribeLightOn(_myEntities.BinarySensor.HallwaySensorOccupancy, _myEntities.Light.HallwayLight);
            SubcribeLightOff(_myEntities.BinarySensor.HallwaySensorOccupancy, _myEntities.Light.HallwayLight, defaulMotionTimeout);

 
            SubcribeLightOn(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2);
            SubcribeLightOff(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2, new TimeSpan(0, 0, 0));

            SubcribeLightOn(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2);
            SubcribeLightOff(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2, new TimeSpan(0, 0, 0));
            //Distance must be bellow threshold fot at least 3 seconds until it is considereds to be turn off

            _myEntities.Sensor.KitchenSensors.StateChanges().WhenStateIsFor(x => x?.State == "True", TimeSpan.FromSeconds(1)).Subscribe(_ => {
                _myEntities.Light.KitchenLight2.TurnOnLight();
            });

            _myEntities.Sensor.KitchenSensors.StateChanges().WhenStateIsFor(x => x?.State == "False", TimeSpan.FromSeconds(10)).Subscribe(_ => {
                _myEntities.Light.KitchenLight2.TurnOffLight();
            });



            _myEntities.BinarySensor._0x001788010bcfb16fOccupancy.StateChanges().Where(x => x?.New?.State == "on" && _myEntities.Light.AllLights.IsOff() && _myEntities.Light.AllLights?.EntityState?.LastChanged< DateTime.Now + TimeSpan.FromSeconds(30)).SubscribeAsync(async s => {

                _myEntities.Light.HallwayLight.TurnOnLight();

                await Task.Delay(30000);

                if (_myEntities.BinarySensor.HallwaySensorOccupancy.IsOff())
                {
                    _myEntities.Light.HallwayLight.TurnOffLight();
                }

            });

        }

        private void SubcribeLightOn(BinarySensorEntity sensor, LightEntity light, Func<bool>? extraConditions = null, NumericSensorEntity? fluzSensor = null, double maxFlux = double.MaxValue)
        {          
            sensor.StateChanges().Where(e => e.New?.State == "on" && _myEntities.InputBoolean.SensorsActive.IsOn() && (extraConditions == null || extraConditions.Invoke())).Subscribe(_ => { light.TurnOnWithSensor(fluzSensor, maxFlux); });
        }

        private void SubcribeLightOff(BinarySensorEntity sensor, LightEntity light, TimeSpan offTime, Func<bool>? extraConditions = null)
        {
            sensor.StateChanges().Where(e => extraConditions != null ? extraConditions.Invoke() : true).WhenStateIsFor(e => e.IsOff() && _myEntities.InputBoolean.SensorsActive.IsOn(), offTime).Subscribe(e => { light.TurnOffLight(); });
            //extraConditions != null ? extraConditions.Invoke() : true
        }


    }
}
