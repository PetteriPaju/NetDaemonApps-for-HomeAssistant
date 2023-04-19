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

            _myEntities.Switch.PcConnectorSocket2.StateChanges().Subscribe(_ => {
                if (_myEntities.Switch.PcConnectorSocket2.IsOn())
                    _myEntities.Switch.OutsideTemperatureMeterSwitch.TurnOn();
                else
                    _myEntities.Switch.OutsideTemperatureMeterSwitch.TurnOff();
            });

            _myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });
            _myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });

            _myEntities.Light.MultiPlugBrightLight.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
                .Subscribe(x =>  {_myEntities.Light.LivingRoomLight.TurnOn();});

            _myEntities.Light.KitchenLight2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
                .Subscribe(x => { _myEntities.Light.LivingRoomLight.TurnOn(); });

            _myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
               .Subscribe(x => { _myEntities.Light.ToiletLight1.TurnOff();});

            //Fan
            _myEntities.Switch.BedMultiPlugL2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1))
               .Subscribe(x => { _myEntities.Switch.BedMultiPlugL2.TurnOff(); });

            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on")
                .Subscribe(_ => {

                _myEntities.Switch.PcConnectorSocket1.TurnOn();
                _myEntities.Switch.PcConnectorSocket2.TurnOn();
                _myEntities.Switch.PcConnectorSocket3.TurnOn();
                _myEntities.Scene.SwitchUsbPc.TurnOn();

            });

       
            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "off")
                .Subscribe(_ => {


                if (_myEntities.Sensor.EnvyNetworkNetworkCardCount.AsNumeric().State != 1)
                {
                    _myEntities.Switch.PcConnectorSocket1.TurnOff();
                    _myEntities.Switch.PcConnectorSocket2.TurnOff();
                    _myEntities.Switch.PcConnectorSocket3.TurnOff();
                }
                _myEntities.Scene.SwitchUsbLaptop.TurnOn();

            });

            


            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < 20)
                .Subscribe(_ => {

                _myEntities.Switch.RunnerPlug.TurnOn();          
            });

            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State == 100)
                .Subscribe(_ => {
                _myEntities.Switch.RunnerPlug.TurnOff();
            });



        }
    }
}
