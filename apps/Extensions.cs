using HomeAssistantGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps
{
    public static class Extensions
    {
        public static void TurnOnWithSensor(this LightEntity light, NumericSensorEntity? luminanceSensorEntity, double maxFlux = double.MaxValue)
        {
            if (light == null) return;


            if (luminanceSensorEntity?.State > maxFlux || luminanceSensorEntity == null)
            {
                light.TurnOn();
            }

        }
    }
}
