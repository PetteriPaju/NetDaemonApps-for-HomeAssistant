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
    public class KeepServerPoweredDownWhenAsleep
    {
        private IDisposable? qnapMonitor;
    
        public KeepServerPoweredDownWhenAsleep()
        {
           
          
            void monitor()
            {
                
                if (_0Gbl._myEntities.BinarySensor.ZatnasPing.State == "on")
                {
                    _0Gbl._myServices.Script.TurnOffServer();
                }
            }

            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x?.New?.State == "on" && _0Gbl._myEntities.InputBoolean.AutoTurnOffServer.IsOn()).Subscribe(x => {
                qnapMonitor?.Dispose();

                qnapMonitor = _0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(15), DateTimeOffset.Now, () => {
                    monitor();
                });

            });

            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x.New?.State == "off" && _0Gbl._myEntities.InputBoolean.AutoTurnOffServer.IsOn()).Subscribe(x => {
                qnapMonitor?.Dispose();
                _0Gbl._myServices.Script.TurnOnServer();
            });

            _0Gbl._myEntities.InputBoolean.AutoTurnOffServer.StateAllChanges().Subscribe(x => {

                if (x.New.IsOn() && _0Gbl._myEntities.BinarySensor.ZatnasPing.IsOff())
                {
                    qnapMonitor?.Dispose();
                    qnapMonitor = _0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(15), DateTimeOffset.Now, () => {
                        monitor();
                    });
                }
                else { qnapMonitor?.Dispose();}
            
            
            
            });

        }
      
    }
}
