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
        Dictionary<LightEntity, IDisposable[]> lightOffDisposables = new Dictionary<LightEntity, IDisposable[]>(); 
        public AutoTurnOffs() {

            _0Gbl._myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { _0Gbl._myEntities.Button.PcResetbrigtness.Press(); });
            _0Gbl._myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _0Gbl._myEntities.Button.PcResetbrigtness.Press(); });

            _0Gbl._myEntities.Light.KitchenLight2.StateChanges().WhenStateIsFor(x => x?.State == "on" && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff() , TimeSpan.FromHours(1), _0Gbl._myScheduler)
                .Subscribe(x => { _0Gbl._myEntities.Light.KitchenLight2.TurnOffLight(); });

            _0Gbl._myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1), _0Gbl._myScheduler)
               .Subscribe(x => { _0Gbl._myEntities.Light.ToiletLight1.TurnOff();});

            _0Gbl._myEntities.Sensor.InkplatePlugPower.StateChanges().WhenStateIsFor(x => x?.State < 50, TimeSpan.FromMinutes(30), _0Gbl._myScheduler)
               .Subscribe(x => { _0Gbl._myEntities.Switch.InkplatePlug.TurnOff(); });


            void sub(LightEntity light)
            {
                lightOffDisposables.Add(light, new IDisposable[3] {null, null, null});
                
                light.StateChanges()
                        .Subscribe(x => {
                            lightOffDisposables[light][0]?.Dispose();
                            lightOffDisposables[light][1]?.Dispose();
                            lightOffDisposables[light][2]?.Dispose();

                            if (light.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn())
                            {
                               _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(60), () => {
                                   if (light.IsOn())
                                   {
                                       lightOffDisposables[light][0] = _0Gbl._myEntities.Sensor.PcLastactive.StateChanges().Where(x => x.Old?.State != "unavailable" && x.New?.State != "unavailable").Subscribe(x => {
                                           light.TurnOff();
                                           lightOffDisposables[light][0]?.Dispose();
                                           lightOffDisposables[light][0] = null;
                                       });
                                       lightOffDisposables[light][1] = _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().Where(x => x.Old?.State != "unavailable" && x.New?.State != "unavailable" && _0Gbl._myEntities.Sensor.EnvyNetworkNetworkCardCount.State == "1").Subscribe(x => {

                                           light.TurnOff();
                                           lightOffDisposables[light][1]?.Dispose();
                                           lightOffDisposables[light][1] = null;

                                       });
                                   }

                               });
                                    lightOffDisposables[light][2] = _0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(600), () => {
                                    if(lightOffDisposables[light][0] != null)
                                    {
                                        lightOffDisposables[light][0]?.Dispose();
                                        lightOffDisposables[light][1]?.Dispose();
                                    }
                                });
                            }



                            if (light.IsOff())
                            {
                                lightOffDisposables[light][0]?.Dispose();
                                lightOffDisposables[light][1]?.Dispose();
                                lightOffDisposables[light][3]?.Dispose();
                            }


                        });
            }
            sub(_0Gbl._myEntities.Light.ToiletLight1);
            sub(_0Gbl._myEntities.Light.KitchenLight2);
            sub(_0Gbl._myEntities.Light.HallwayLight);
            sub(_0Gbl._myEntities.Light.StorageLight2);



            //Fan
            _0Gbl._myEntities.Switch.BedMultiPlugL1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1)+TimeSpan.FromMinutes(30), _0Gbl._myScheduler)
               .Subscribe(x => { _0Gbl._myEntities.Switch.BedMultiPlugL1.TurnOff(); });

            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on" && x.Old?.State == "off")
                .Subscribe(_ => {

                 _0Gbl._myEntities.Light.PcMultipowermeterL1.TurnOn();
                _0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOn();
                _0Gbl._myEntities.Switch.FanPlug.TurnOn();
               // _0Gbl._myEntities.Scene.SwitchUsbLaptop.TurnOn();


            });



       
            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on")
                .Subscribe(_ => {


                if (_0Gbl._myEntities.Sensor.EnvyNetworkNetworkCardCount.AsNumeric().State != 1)
                {
                        _0Gbl._myEntities.Light.PcMultipowermeterL1.TurnOff();
                        _0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOff();
                }
               
                 //_0Gbl._myEntities.Scene.SwitchUsbPc.TurnOn();

            });

            


            _0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < _0Gbl._myEntities.InputNumber.SettingsLaptopchargerturnonpercent.State)
                .Subscribe(_ => {

                _0Gbl._myEntities.Switch.PcMultipowermeterLaptop.TurnOn();          
            });

            _0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State >= 99)
                .Subscribe(_ => {
                    _0Gbl._myEntities.Switch.PcMultipowermeterLaptop.TurnOff();
                });

            _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "on" && x?.Old?.State == "off").Subscribe(_ => {
              //  _00_Globals._myEntities.Switch.TbdPowermeter.TurnOff();
            });

            _0Gbl._myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "off" && x?.Old?.State == "on").Subscribe(_ => {
               // _00_Globals._myEntities.Switch.TbdPowermeter.TurnOn();
            });

        }
    }
}
