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
            if (_myEntities.Switch.PcConnectorMonitors.IsOff())
            {
                _myEntities.Switch.PcConnectorMonitors.TurnOn();
                _myEntities.Switch.PcConnectorOthers.TurnOn();

            }
            else
            {
                _myEntities.Switch.PcConnectorMonitors.TurnOff();
                _myEntities.Switch.PcConnectorOthers.TurnOff();
            }
        }


        protected override void OnOffPress()
        {
            _myEntities.Switch.FanPlug.Toggle();
        }

    }
}
