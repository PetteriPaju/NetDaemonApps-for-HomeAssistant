using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{

    [NetDaemonApp]
    public class Starkvind : AppBase
    {
        public Starkvind(IHaContext ha) {

            myScheduler.ScheduleCron("30 0 * * * *", HourlyTurnOnCheck,true);

        }

        private void HourlyTurnOnCheck()
        {
            if (ShouldTurnOn())
            {
                if (myEntities.Fan.Starkvind.IsOff())
                {
                    TurnOn();
                    myEntities.InputBoolean.StarkvindOnbyauto.TurnOn();

                }
                else
                {
                    myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
                }
            }
            else if (myEntities.InputBoolean.StarkvindOnbyauto.IsOn())
            {
                TurnOff();
                myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
            }
            else if (myEntities.BinarySensor.CheapElectricity.IsOff())
            {
                TurnOff();
            }
        }

        private bool ShouldTurnOn()
        {
            return myEntities.BinarySensor.CheapElectricity.IsOn() && myEntities.Sensor.Nordpool.State == myEntities.Sensor.Nordpool.Attributes.Min;
        }

        private void TurnOn()
        {
            myEntities.Fan.Starkvind.SetPercentage(myEntities.InputBoolean.Isasleep.IsOff() ?  (long)myEntities.InputNumber.StarkvindDefaultSpeed.State : (long)myEntities.InputNumber.StarkvindSleepSpeed.State);
        }
        private void TurnOff()
        {
            myEntities.Fan.Starkvind.TurnOff();

        }

    }
}
