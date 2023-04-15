using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps
{
    public static class Extensions
    {

        public static void TurnOnLight(this LightEntity light)
        {
            SetLightState(light, true);
        }
        public static void TurnOffLight(this LightEntity light)
        {
            SetLightState(light, false);
        }

        private static void SetLightState(LightEntity light, bool state)
        {
            if (light == null) return;

            if(Notifications._sensorsOnBooleanEntity == null || Notifications._sensorsOnBooleanEntity.IsOn())
            {
                if (state) light.TurnOn();
                else light.TurnOff();
            }
        }

        public static void TurnOnWithSensor(this LightEntity light, NumericSensorEntity? luminanceSensorEntity, double maxFlux = double.MaxValue)
        {
            if (light == null) return;


            if (luminanceSensorEntity?.State > maxFlux || luminanceSensorEntity == null)
            {
                light.TurnOnLight();
            }

        }
    }
}
