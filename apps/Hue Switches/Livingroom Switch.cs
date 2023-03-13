using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;

namespace NetDaemonApps.apps.Hue_Switches
{
    [NetDaemonApp]
    public class Livingroom_Switch : HueSwitch
    {
        public Livingroom_Switch(IHaContext ha) : base(ha){}

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchLivingRoomAction;
        }

        protected override void OnOnPress()
        {
            if (_myEntities.Switch.PcConnectorSocket2.IsOff())
            {
                _myEntities.Switch.PcConnectorSocket2.TurnOn();
                _myEntities.Switch.PcConnectorSocket3.TurnOn();

            }
            else
            {
                _myEntities.Switch.PcConnectorSocket2.TurnOff();
                _myEntities.Switch.PcConnectorSocket3.TurnOff();
            }
        }


        protected override void OnOffPress()
        {
            _myEntities.Switch.FanPlug.Toggle();
        }

    }
}
