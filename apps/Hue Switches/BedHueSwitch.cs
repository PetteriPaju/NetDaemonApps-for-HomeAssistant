using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Hue_Switches
{
    [NetDaemonApp]
    public class BedHueSwitch : HueSwitch
    {
        public BedHueSwitch(IHaContext ha) : base(ha){}

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchBedAction;
        }

        protected override void OnOnPress()
        {
            if (_myEntities.Light.LivingRoomLights.IsOn())
            {
                _myEntities.Light.LivingRoomLights.TurnOff();
            }
            else
            {
                _myEntities.Light.BedLight.Toggle();
            }
        }

        //Fan
        protected override void OnOffPressRelease()
        {
            _myEntities.Switch.BedMultiPlugL2.Toggle(); 
        }

        protected override void OnOffHoldRelease()
        {
            _myEntities.Switch.BedMultiPlugL1.Toggle();
        }



    }
}
