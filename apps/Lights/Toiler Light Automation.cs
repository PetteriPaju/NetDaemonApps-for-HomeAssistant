using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Toiler_Light_Automation
    {
        private List<LightEntity> targetLights = new List<LightEntity>();
        private List<LightEntity> lightsThatWereOn = new List<LightEntity>();

        private Entities _myEntities;
        private readonly TimeSpan lightOnTimeOutSpan = new TimeSpan(1, 0, 0);
        private readonly TimeSpan motionSensorTimeOutSpan = new TimeSpan(0, 0, 10);

        public Toiler_Light_Automation(IHaContext ha)
        {

            _myEntities = new Entities(ha);

            targetLights.Add(_myEntities.Light.BedLight);
            targetLights.Add(_myEntities.Light.PcMultipowermeterL2);
  
            targetLights.Add(_myEntities.Light.LivingRoomLight);
            targetLights.Add(_myEntities.Light.DesktopLight);

            /*
            _myEntities.BinarySensor.ToiletSeatSensorContact
           .StateChanges().Where(e => e.New?.State == "on" && _myEntities.InputBoolean.SensorsActive.IsOn())
           .Subscribe(_ => OnToiledLidOpen());

            _myEntities.BinarySensor.ToiletSeatSensorContact
           .StateChanges().Where(e => e.New?.State == "off" && _myEntities.InputBoolean.SensorsActive.IsOn())
           .Subscribe(_ => OnToiledLidClose());
            */
            bool canTurnoffToilet = false;

            _myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .Where(e => e.New?.State == "on")
            .Subscribe(_ => {
                canTurnoffToilet = false;
                _myEntities.Light.ToiletLight1.TurnOnLight();
     
            });

       

            _myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .Where(e => e.New.IsOff() && canTurnoffToilet)
            .Subscribe(_ => {
                _myEntities.Light.ToiletLight1.TurnOffLight();

            });
            
            _00_LivingRoomFP1.LivingRoomFP1.Regions[3].callbacks.onEnter += (AqaraFP1Extender.FP1EventInfo info) =>
            {
                canTurnoffToilet = true;
   

                if (_myEntities.Light.ToiletLight1.IsOn() && _myEntities.BinarySensor.ToiletSensorOccupancy.IsOff())
                {
                    _myEntities.Light.ToiletLight1.TurnOffLight();
                }

             
            };



        }



        private void OnToiledLidOpen()
        {

            lightsThatWereOn.Clear();
            _myEntities.Light.HallwayLight.TurnOffLight();
            foreach (LightEntity light in targetLights)
            {
                if (light != null && light.IsOn())
                {
                    lightsThatWereOn.Add(light);
                    light.TurnOffLight();
                }
            }

            //Turn off PC Monitors while in toilet
            if (_myEntities.Switch.PcPlug.IsOn())
                _myEntities.Button.PcTurnoffmonitors.Press();

        }


        private void OnToiledLidClose()
        {

            foreach (LightEntity light in lightsThatWereOn)
            {
                light.TurnOnLight();
            }

            lightsThatWereOn.Clear();

            //Turn on PC Monitors
            if (_myEntities.Switch.PcPlug.IsOn())
                _myEntities.Button.PcWakekey.Press();
        }

    }
}
