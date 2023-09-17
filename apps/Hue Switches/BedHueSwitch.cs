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

        public BedHueSwitch() : base(){}

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchBedAction;
        }

        protected override void OnOnPress()
        {

                _0Gbl._myEntities.Light.BedLight.Toggle();
       
           
        }

        //Fan
        protected override void OnOffPressRelease()
        {
            _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle(); 
        }

        protected override void OnOffHoldRelease()
        {
            _0Gbl._myEntities.Switch.BedMultiPlugL3.Toggle();
        }



    }
}
