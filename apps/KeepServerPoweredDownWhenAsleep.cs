using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
          
            void monitor()
            {
                
                if (_myEntities.BinarySensor.ZatnasPing.State == "on")
                {
                    _myServices.Script.TurnOffServer();
                }
            }


            _myEntities.InputBoolean.NasOn.StateChanges().Where(x => x?.New?.State == "off" && _myEntities.InputBoolean.AutoTurnOffServer.IsOn()).Subscribe(x => {
                qnapMonitor?.Dispose();

                qnapMonitor = scheduler.RunEvery(TimeSpan.FromMinutes(15), DateTimeOffset.Now, () => {
                    monitor();
                });

            });

            _myEntities.InputBoolean.NasOn.StateChanges().Where(x => x.New?.State == "on" && _myEntities.InputBoolean.AutoTurnOffServer.IsOn()).Subscribe(x => {
                qnapMonitor?.Dispose();
                _myServices.Script.TurnOnServer();
            });

            _myEntities.InputBoolean.AutoTurnOffServer.StateAllChanges().Subscribe(x => {

                if (x.New.IsOn() && _myEntities.InputBoolean.NasOn.IsOff())
                {
                    qnapMonitor?.Dispose();
                    qnapMonitor = scheduler.RunEvery(TimeSpan.FromMinutes(15), DateTimeOffset.Now, () => {
                        monitor();
                    });
                }
                else { qnapMonitor?.Dispose();}
            
            
            
            });

        }
      
    }
}
