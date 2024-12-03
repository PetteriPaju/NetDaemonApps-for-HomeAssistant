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

            _0Gbl._myScheduler.ScheduleCron("1 * * * *", HourlyTurnOnCheck);

        }

        private void HourlyTurnOnCheck()
        {
            if (ShouldTurnOn())
            {
                if (_0Gbl._myEntities.Fan.Starkvind.IsOff())
                {
                    TurnOn();
                    _0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOn();

                }
                else
                {
                    _0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
                }
            }
            else if (_0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.IsOn())
            {
                TurnOff();
                _0Gbl._myEntities.InputBoolean.StarkvindOnbyauto.TurnOff();
            }
            else if (_0Gbl._myEntities.BinarySensor.CheapElectricity.IsOff())
            {
                TurnOff();
            }
        }

        private bool ShouldTurnOn()
        {
            return _0Gbl._myEntities.BinarySensor.CheapElectricity.IsOn() && _0Gbl._myEntities.Sensor.Nordpool.State == _0Gbl._myEntities.Sensor.Nordpool.Attributes.Min;
        }

        private void TurnOn()
        {
            _0Gbl._myEntities.Fan.Starkvind.SetPercentage(_0Gbl._myEntities.InputBoolean.Isasleep.IsOff() ?  (long)_0Gbl._myEntities.InputNumber.StarkvindDefaultSpeed.State : (long)_0Gbl._myEntities.InputNumber.StarkvindSleepSpeed.State);
        }
        private void TurnOff()
        {
            _0Gbl._myEntities.Fan.Starkvind.SetPercentage(0);
        }

    }
}
