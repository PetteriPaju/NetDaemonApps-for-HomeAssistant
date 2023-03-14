using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AutoTurnOffs
    {

        public AutoTurnOffs(IHaContext ha) {

            var _myEntities = new Entities(ha);


            _myEntities.Sensor.PcDisplayDisplayCount.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });
            _myEntities.Sensor.PcDisplayDisplay1Resolution.StateChanges().Subscribe(_ => { _myEntities.Button.PcResetbrigtness.Press(); });

            _myEntities.Light.MultiPlugBrightLight.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1)).
                Subscribe(x => { _myEntities.Light.MultiPlugBrightLight.TurnOff(); _myEntities.Light.LivingRoomLight.TurnOn();});

            _myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1)).
               Subscribe(x => { _myEntities.Light.ToiletLight1.TurnOff();});

            //Fan
            _myEntities.Switch.BedMultiPlugL2.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromHours(1)).
               Subscribe(x => { _myEntities.Switch.BedMultiPlugL2.TurnOff(); });

            //PC Plug off on when the unit is shut down
            _myEntities.Sensor.PcPlugPower.StateChanges().WhenStateIsFor(x=>((NumericEntityState)x).State < 5, TimeSpan.FromMinutes(5)).WhenStateIsFor(_=>_myEntities.Sensor.PcLastactive.State == "Unavailable", TimeSpan.FromMinutes(5)).
               Subscribe(x => { _myEntities.Switch.PcPlug.TurnOff(); });


            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "on").Subscribe(_ => {

                _myEntities.Switch.PcConnectorSocket1.TurnOn();
                _myEntities.Switch.PcConnectorSocket2.TurnOn();
                _myEntities.Switch.PcConnectorSocket3.TurnOn();
                _myEntities.Scene.SwitchUsbPc.TurnOn();

            });

       
            _myEntities.Switch.PcPlug.StateChanges().Where(x => x.New?.State == "off").Subscribe(_ => {


                if (_myEntities.Sensor.EnvyNetworkEthernet3.State != "Up" && _myEntities.Sensor.EnvyNetworkEthernet3.State != "Down")
                {
                    _myEntities.Switch.PcConnectorSocket1.TurnOff();
                    _myEntities.Switch.PcConnectorSocket2.TurnOff();
                    _myEntities.Switch.PcConnectorSocket3.TurnOff();
                }
                _myEntities.Scene.SwitchUsbLaptop.TurnOn();

            });

            _myEntities.Sensor.EnvyNetworkEthernet3.StateChanges().Where(x => x.New?.State == "Up" || x.New.State == "Down").Subscribe(_ => {

                    _myEntities.Switch.PcConnectorSocket1.TurnOn();
                    _myEntities.Switch.PcConnectorSocket2.TurnOn();
                    _myEntities.Switch.PcConnectorSocket3.TurnOn();

                    _myEntities.Scene.SwitchUsbLaptop.TurnOn();
            

            });

            _myEntities.Sensor.EnvyNetworkEthernet3.StateChanges().Where(x => x.New?.State != "Up" && x.New.State != "Down").Subscribe(_ => {

                if (_myEntities.Switch.PcPlug.IsOff())
                {
                    _myEntities.Switch.PcConnectorSocket1.TurnOff();
                    _myEntities.Switch.PcConnectorSocket2.TurnOff();
                    _myEntities.Switch.PcConnectorSocket3.TurnOff();
                }
                else _myEntities.Scene.SwitchUsbPc.TurnOn();
            });

            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State < 20).Subscribe(_ => {

                _myEntities.Switch.RunnerPlug.TurnOn();          
            });

            _myEntities.Sensor.EnvyBatteryChargeRemainingPercentage.StateChanges().Where(x => x?.New?.State == 100).Subscribe(_ => {
                _myEntities.Switch.RunnerPlug.TurnOff();
            });



        }
    }
}
