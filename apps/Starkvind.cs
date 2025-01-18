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
    public class Starkvind
    {
        public Starkvind(IHaContext ha) {

            A0Gbl._myScheduler.ScheduleCron("30 0 * * * *", HourlyTurnOnCheck,true);

        }

        private void HourlyTurnOnCheck()
        {
            if (ShouldTurnOn())
            {
                if (A0Gbl._myEntities.Fan.Starkvind.IsOff())
                {
                    TurnOn();
                    A0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOn();

                }
                else
                {
                    A0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
                }
            }
            else if (A0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.IsOn())
            {
                TurnOff();
                A0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
            }
            else if (A0Gbl._myEntities.BinarySensor.CheapElectricity.IsOff())
            {
                TurnOff();
            }
        }

        private bool ShouldTurnOn()
        {
            return A0Gbl._myEntities.BinarySensor.CheapElectricity.IsOn() && A0Gbl._myEntities.Sensor.Nordpool.State == A0Gbl._myEntities.Sensor.Nordpool.Attributes.Min;
        }

        private void TurnOn()
        {
            A0Gbl._myEntities.Fan.Starkvind.SetPercentage(A0Gbl._myEntities.InputBoolean.Isasleep.IsOff() ?  (long)A0Gbl._myEntities.InputNumber.StarkvindDefaultSpeed.State : (long)A0Gbl._myEntities.InputNumber.StarkvindSleepSpeed.State);
        }
        private void TurnOff()
        {
            A0Gbl._myEntities.Fan.Starkvind.TurnOff();
            A0Gbl._myEntities.Fan.Starkvind.SetPercentage(0);

        }

    }
}
