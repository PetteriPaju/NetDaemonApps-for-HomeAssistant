﻿using HomeAssistantGenerated;
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
        private readonly double kitchenDistanceSensorDistance = 150;
        private bool kitchenDistanceHelper = false;

        public LightsAndSensors(IHaContext ha)
        {
            _myEntities = new Entities(ha);

            SubcribeLightOn(_myEntities.BinarySensor.HallwaySensorOccupancy, _myEntities.Light.HallwayLight);
            SubcribeLightOff(_myEntities.BinarySensor.HallwaySensorOccupancy, _myEntities.Light.HallwayLight, defaulMotionTimeout);

            SubcribeLightOn(_myEntities.BinarySensor.KitchenSensorOccupancy, _myEntities.Light.KitchenLight2);
            SubcribeLightOff(_myEntities.BinarySensor.KitchenSensorOccupancy, _myEntities.Light.KitchenLight2, defaulMotionTimeout, () => { return kitchenDistanceHelper == false; });

            SubcribeLightOn(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2);
            SubcribeLightOff(_myEntities.BinarySensor.StorageSensorAqaraOccupancy, _myEntities.Light.StorageLight2, new TimeSpan(0, 0, 0));


            ha.Entity("binary_sensor.kitchen_distance_helper").StateChanges().Where(x => x.Entity?.EntityState?.LastUpdated > DateTime.Now - TimeSpan.FromSeconds(3)).Subscribe(

                _ => {

                    kitchenDistanceHelper = ha.Entity("binary_sensor.kitchen_distance_helper").State == "on";
                }
                
                
                );


          


        }

        private void SubcribeLightOn(BinarySensorEntity sensor, LightEntity light, Func<bool>? extraConditions = null)
        {          
            sensor.StateChanges().Where(e => e.New?.State == "on" && _myEntities.InputBoolean.SensorsActive.IsOn() && (extraConditions == null || extraConditions.Invoke())).Subscribe(_ => { light.TurnOn(); });
        }

        private void SubcribeLightOff(BinarySensorEntity sensor, LightEntity light, TimeSpan offTime, Func<bool>? extraConditions = null)
        {
            sensor.StateChanges().Where(e => extraConditions != null ? extraConditions.Invoke() : true).WhenStateIsFor(e => e.IsOff() && _myEntities.InputBoolean.SensorsActive.IsOn(), offTime).Subscribe(e => { light.TurnOff(); });
            //extraConditions != null ? extraConditions.Invoke() : true
        }


    }
}