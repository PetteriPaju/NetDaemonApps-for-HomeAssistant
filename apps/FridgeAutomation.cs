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
    public class FridgeAutomation
    {
        private readonly TimeSpan maxTimeOff = TimeSpan.FromHours(2);
        private readonly TimeSpan thresholdTime = TimeSpan.FromMinutes(15);
        private readonly double[] turnOffTemperatures = new double[] { 4, 6 };
        private readonly double[] turnOnTemperatures = new double[] { 7,9 };
        private readonly double maxTemperature = 10;

        private bool turnOffDuringMaxHours = true;
        private bool keepOnDuringMinHours = true;

        private InputBooleanEntity isAsleepEntity;

        private NumericSensorEntity Nordpool;


        public FridgeAutomation()
        {

            Nordpool = _0Gbl._myEntities.Sensor.NordpoolKwhFiEur31001;

           //Nordpool.EntityState.Attributes.


        }


            private int getCurrentOffTemp()
        {
            return isAsleepEntity == null ? 0 : isAsleepEntity.IsOff() ? 0 : 1;
        }
        



    }
}
