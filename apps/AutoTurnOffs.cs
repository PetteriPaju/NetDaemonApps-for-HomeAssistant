using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System.Linq;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AutoTurnOffs
    {

        public AutoTurnOffs() {

            _0Gbl._myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { _0Gbl._myEntities.Button.PcResetbrigtness.Press(); });
            _0Gbl._myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _0Gbl._myEntities.Button.PcResetbrigtness.Press(); });

            _0Gbl._myEntities.Light.PcMultipowermeterL2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1),_0Gbl._myScheduler)
                .Subscribe(x =>  {_0Gbl._myEntities.Light.LivingRoomLight.TurnOnWithSensor(LightsAndSensors.luxSensorEntity,10);});

            _0Gbl._myEntities.Light.KitchenLight2.StateChanges().WhenStateIsFor(x => x?.State == "on" && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff(), TimeSpan.FromHours(1), _0Gbl._myScheduler)
                .Subscribe(x => { _0Gbl._myEntities.Light.KitchenLight2.TurnOff(); });

            _0Gbl._myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1), _0Gbl._myScheduler)
               .Subscribe(x => { _0Gbl._myEntities.Light.ToiletLight1.TurnOff();});

            //Fan
            _0Gbl._myEntities.Switch.BedMultiPlugL1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1), _0Gbl._myScheduler)
               .Subscribe(x => { _0Gbl._myEntities.Switch.BedMultiPlugL1.TurnOff(); });

            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on" && x.Old?.State == "off")
                .Subscribe(_ => {

                 _0Gbl._myEntities.Light.PcMultipowermeterL2.TurnOn();
                    AgaraCube_LivingRoom.BrightLightTurnedOnByPC = true;
                _0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOn();
                _0Gbl._myEntities.Switch.FanPlug.TurnOn();
                _0Gbl._myEntities.Scene.SwitchUsbLaptop.TurnOn();

            });

       
            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on")
                .Subscribe(_ => {


                if (_0Gbl._myEntities.Sensor.EnvyNetworkNetworkCardCount.AsNumeric().State != 1)
                {
                        _0Gbl._myEntities.Light.PcMultipowermeterL2.TurnOff();
                        _0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOff();
                }
                _0Gbl._myEntities.Scene.SwitchUsbPc.TurnOn();

            });

            


            _0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < _0Gbl._myEntities.InputNumber.SettingsLaptopchargerturnonpercent.State)
                .Subscribe(_ => {

                _0Gbl._myEntities.Switch.PcMultipowermeterLplug.TurnOn();          
            });

            _0Gbl._myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State >= 99)
                .Subscribe(_ => {
                _0Gbl._myEntities.Switch.PcMultipowermeterLplug.TurnOff();
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
