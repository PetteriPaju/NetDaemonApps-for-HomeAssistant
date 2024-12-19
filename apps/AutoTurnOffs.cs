using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System.Collections;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Collections.Generic;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AutoTurnOffs
    {
        private IDisposable? toiletLightOffWaiterPC = null;
        private IDisposable? toiletLightOffWaiterLaptop = null;
        private IDisposable? kitchenLightOffWaiterPc = null;
        private IDisposable? kitchenLightOffWaiterLaptop = null;
        Dictionary<LightEntity, AutorunDisposables> lightOffDisposables = new Dictionary<LightEntity, AutorunDisposables>(); 

        protected class AutorunDisposables
        {
            public IDisposable pc = null;
            public IDisposable laptop = null;
            public IDisposable disposer = null;
        }
        public AutoTurnOffs() {

            A0Gbl._myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { A0Gbl._myEntities.Button.PcResetbrigtness.Press(); });
            //_0Gbl._myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _0Gbl._myEntities.Button.PcResetbrigtness.Press(); });

            A0Gbl._myEntities.Light.KitchenLight2.StateChanges().WhenStateIsFor(x => x?.State == "on" && A0Gbl._myEntities.InputBoolean.GuestMode.IsOff() , TimeSpan.FromHours(1), A0Gbl._myScheduler)
                .Subscribe(x => { A0Gbl._myEntities.Light.KitchenLight2.TurnOffLight(); });

            A0Gbl._myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1), A0Gbl._myScheduler)
               .Subscribe(x => { A0Gbl._myEntities.Light.ToiletLight1.TurnOff();});

            A0Gbl._myEntities.Sensor.InkplatePlugPower.StateChanges().WhenStateIsFor(x => x?.State < 50, TimeSpan.FromMinutes(30), A0Gbl._myScheduler)
               .Subscribe(x => { A0Gbl._myEntities.Switch.InkplatePlug.TurnOff(); });


            void sub(LightEntity light)
            {
                lightOffDisposables.TryAdd(light, new AutorunDisposables());
                
                light.StateChanges()
                        .Subscribe(x => {
                            lightOffDisposables[light].pc?.Dispose();
                            lightOffDisposables[light].laptop?.Dispose();
                            lightOffDisposables[light].disposer?.Dispose();

                            if (light.IsOn() && A0Gbl._myEntities.InputBoolean.GuestMode.IsOff() && A0Gbl._myEntities.InputBoolean.SensorsActive.IsOn())
                            {
                               A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(60), () => {
                                   if (light.IsOn())
                                   {
                                       lightOffDisposables[light].pc = A0Gbl._myEntities.Sensor.PcLastactive.StateChanges().Where(x => x.Old?.State != "unavailable" && x.New?.State != "unavailable").Subscribe(x => {
                                           light.TurnOff();
                                           lightOffDisposables[light].pc?.Dispose();
                                           lightOffDisposables[light].pc = null;
                                       });
                                       lightOffDisposables[light].laptop = A0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().Where(x => x.Old?.State != "unavailable" && x.New?.State != "unavailable" && A0Gbl._myEntities.Sensor.EnvyNetworkTotalNetworkCardCount.State == "1").Subscribe(x => {

                                           light.TurnOff();
                                           lightOffDisposables[light].laptop?.Dispose();
                                           lightOffDisposables[light].laptop = null;

                                       });
                                   }

                               });
                                    lightOffDisposables[light].disposer= A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(600), () => {
                                    if(lightOffDisposables[light].pc != null)
                                    {
                                        lightOffDisposables[light].pc?.Dispose();
                                        lightOffDisposables[light].laptop?.Dispose();
                                    }
                                });
                            }



                            if (light.IsOff())
                            {
                                lightOffDisposables[light].pc?.Dispose();
                                lightOffDisposables[light].laptop?.Dispose();
                                lightOffDisposables[light].disposer?.Dispose();
                            }


                        });
            }
            sub(A0Gbl._myEntities.Light.ToiletLight1);
            sub(A0Gbl._myEntities.Light.KitchenLight2);
            sub(A0Gbl._myEntities.Light.HallwayLight);
            sub(A0Gbl._myEntities.Light.StorageLight2);



            //Fan
            A0Gbl._myEntities.Switch.BedMultiPlugL1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1)+TimeSpan.FromMinutes(30), A0Gbl._myScheduler)
               .Subscribe(x => { A0Gbl._myEntities.Switch.BedMultiPlugL1.TurnOff(); });

            A0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on" && x.Old?.State == "off")
                .Subscribe(_ => {

                 A0Gbl._myEntities.Light.PcMultipowermeterL1.TurnOn();
                A0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOn();
                A0Gbl._myEntities.Switch.FanPlug.TurnOn();
                    IsAsleepMonitor.Awake();
               // _0Gbl._myEntities.Scene.SwitchUsbLaptop.TurnOn();


            });


            A0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < A0Gbl._myEntities.InputNumber.SettingsLaptopchargerturnonpercent.State)
                .Subscribe(_ => {

                A0Gbl._myEntities.Switch.PcMultipowermeterLaptop.TurnOn();          
            });

            A0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State >= 99)
                .Subscribe(_ => {
                    A0Gbl._myEntities.Switch.PcMultipowermeterLaptop.TurnOff();
                });

            A0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "on" && x?.Old?.State == "off").Subscribe(_ => {
              //  _00_Globals._myEntities.Switch.TbdPowermeter.TurnOff();
            });

            A0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "off" && x?.Old?.State == "on").Subscribe(_ => {
               // _00_Globals._myEntities.Switch.TbdPowermeter.TurnOn();
            });

        }
    }
}
