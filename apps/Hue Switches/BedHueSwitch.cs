using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Hue_Switches
{

    public class BedHueSwitch : HueSwitch
    {

        public BedHueSwitch() : base(){}

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchBedAction;
        }


        protected override void OnOnPress()
        {
            base.OnOnPress();
               // _0Gbl._myEntities.Light.BedLight.Toggle();
       
        }

        protected override void OnAnyPress()
        {
            base.OnAnyPress();
          //  _0Gbl._myEntities.Switch.TvPowerMeter.TurnOn();
        }

        //Fan
        protected override void OnOffPressRelease()
        {
          //  _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle(); 
        }

        protected override void OnOffHoldRelease()
        {
          //  _0Gbl._myEntities.Script.ReadoutTime.TurnOn();
        }




    }
}
