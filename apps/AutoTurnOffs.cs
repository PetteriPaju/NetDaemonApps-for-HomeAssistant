using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System.Linq;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AutoTurnOffs
    {

        public AutoTurnOffs(IHaContext ha) {

            var _myEntities = new Entities(ha);

            _myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });
            _myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });

            _myEntities.Light.PcMultipowermeterL2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
                .Subscribe(x =>  {_myEntities.Light.LivingRoomLight.TurnOn();});

            _myEntities.Light.KitchenLight2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
                .Subscribe(x => { _myEntities.Light.LivingRoomLight.TurnOn(); });

            _myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
               .Subscribe(x => { _myEntities.Light.ToiletLight1.TurnOff();});

            //Fan
            _myEntities.Switch.BrightLightPlug.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
               .Subscribe(x => { _myEntities.Switch.BrightLightPlug.TurnOff(); });

            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on" && x.Old?.State == "off")
                .Subscribe(_ => {

                 _myEntities.Light.PcMultipowermeterL2.TurnOn();
                    AgaraCube_LivingRoom.BrightLightTurnedOnByPC = true;
                _myEntities.Switch.PcMultipowermeterMonitors.TurnOn();
                _myEntities.Switch.FanPlug.TurnOn();
                _myEntities.Scene.SwitchUsbLaptop.TurnOn();

            });

       
            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on")
                .Subscribe(_ => {


                if (_myEntities.Sensor.EnvyNetworkNetworkCardCount.AsNumeric().State != 1)
                {
                        _myEntities.Light.PcMultipowermeterL2.TurnOff();
                        _myEntities.Switch.PcMultipowermeterMonitors.TurnOff();
                }
                _myEntities.Scene.SwitchUsbPc.TurnOn();

            });

            


            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < _myEntities.InputNumber.SettingsLaptopchargerturnonpercent.State)
                .Subscribe(_ => {

                _myEntities.Switch.PcMultipowermeterLplug.TurnOn();          
            });

            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State >= 99)
                .Subscribe(_ => {
                _myEntities.Switch.PcMultipowermeterLplug.TurnOff();
            });

            _myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "on" && x?.Old?.State == "off").Subscribe(_ => {
                _myEntities.Switch.TbdPowermeter.TurnOff();
            });

            _myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Where(x => x?.New?.State == "off" && x?.Old?.State == "on").Subscribe(_ => {
                _myEntities.Switch.TbdPowermeter.TurnOn();
            });
        }
    }
}
