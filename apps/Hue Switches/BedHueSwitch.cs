using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetDaemon.Extensions.Scheduler;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps.Hue_Switches
{
 
    public class BedHueSwitch : HueSwitch
    {
        private IDisposable? keepOnRoutine = null;
        public BedHueSwitch() : base(){}

        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchBedAction;
        }


        protected override void OnOnPress()
        {
            base.OnOnPress();

            if (_0Gbl._myEntities.Light.ToiletLight1.IsOn())
            {
                _0Gbl._myEntities.Light.ToiletLight1.TurnOffLight();
                if (keepOnRoutine != null)
                {
                    keepOnRoutine.Dispose();
                    Lights.Toiler_Light_Automation.forceLightOn = false;
                }
            }
            else
            {
                _0Gbl._myEntities.Light.ToiletLight1.TurnOn();
                if (keepOnRoutine != null)
                {
                    keepOnRoutine.Dispose();
                }
                    keepOnRoutine = _0Gbl._myScheduler.Schedule(TimeSpan.FromMinutes(5), () => {

                    if(_0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.IsOff())
                    {
                        _0Gbl._myEntities.Light.ToiletLight1.TurnOff();
                    }
                  
              
                });
                Lights.Toiler_Light_Automation.forceLightOn = true;
            }
       
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
