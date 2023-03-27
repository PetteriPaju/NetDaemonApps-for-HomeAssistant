using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class KeepServerPoweredDownWhenAsleep
    {
        private Entities _myEntities;
        private IDisposable? qnapMonitor;
        private Services _myServices;
        public KeepServerPoweredDownWhenAsleep(IHaContext ha, IScheduler scheduler)
        {
            _myEntities = new Entities(ha);
            _myServices = new Services(ha);
            _myEntities.InputBoolean.Isasleep.StateChanges().WhenStateIsFor(x => x.State == "on" && _myEntities.InputBoolean.AutoTurnOffServer.IsOn(), TimeSpan.FromMinutes(10)).Subscribe(x => {
                qnapMonitor?.Dispose();

                qnapMonitor = scheduler.RunEvery(TimeSpan.FromMinutes(15), DateTimeOffset.Now, () => {

                    if(_myEntities.Sensor.BackCornerPlugPower.State > 5)
                    {
                        _myServices.Script.TurnOffServer();
                    }

                });

            });

            _myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x.New?.State == "off" && _myEntities.InputBoolean.AutoTurnOffServer.IsOn()).Subscribe(x => {
                qnapMonitor?.Dispose();
                _myServices.Script.TurnOnServer();
            });


        }
    }
}
