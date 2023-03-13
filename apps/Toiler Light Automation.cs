using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class Toiler_Light_Automation
    {
        private List<LightEntity> targetLights = new List<LightEntity>();
        private List<LightEntity> lightsThatWereOn = new List<LightEntity>();

        private Entities _myEntities;
        private readonly TimeSpan lightOnTimeOutSpan = new TimeSpan(1, 0, 0);
        private readonly TimeSpan motionSensorTimeOutSpan = new TimeSpan(0, 0, 10);

        public Toiler_Light_Automation(IHaContext ha) {
        
            _myEntities = new Entities(ha);

            targetLights.Add(_myEntities.Light.BedLight);
            targetLights.Add(_myEntities.Light.MultiPlugBrightLight);
            targetLights.Add(_myEntities.Light.KitchenLight2);
            targetLights.Add(_myEntities.Light.LivingRoomLight);
            targetLights.Add(_myEntities.Light.DesktopLight);
            targetLights.Add(_myEntities.Light.MultiPlugBrightLight);

            _myEntities.BinarySensor.ToiletSeatSensorContact
           .StateChanges().Where(e => e.New?.State == "on" && _myEntities.InputBoolean.SensorsActive.IsOn())
           .Subscribe(_ => OnToiledLidOpen());

            _myEntities.BinarySensor.ToiletSeatSensorContact
           .StateChanges().Where(e => e.New?.State == "off" && _myEntities.InputBoolean.SensorsActive.IsOn())
           .Subscribe(_ => OnToiledLidClose());

            _myEntities.Light.ToiletLight1.StateChanges().WhenStateIsFor(e => e.IsOn(), lightOnTimeOutSpan).Subscribe(_ => { });

            _myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .Where(e => e.New?.State == "on")
            .Subscribe(_ => { _myEntities.Light.ToiletLight1.TurnOn(); });

            _myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .WhenStateIsFor(e => e.IsOff() && _myEntities.BinarySensor.ToiletSeatSensorContact.IsOff(), motionSensorTimeOutSpan)
            .Subscribe(_ => { _myEntities.Light.ToiletLight1.TurnOff(); });

        }



        private void OnToiledLidOpen() {

            lightsThatWereOn.Clear();
            _myEntities.Light.HallwayLight.TurnOff();
            foreach (LightEntity light in targetLights)
            {
                if (light != null && light.IsOn())
                {
                    lightsThatWereOn.Add(light);
                    light.TurnOff();
                }
            }

            //Turn off PC Monitors while in toilet
            if(_myEntities.Switch.PcPlug.IsOn())
            _myEntities.Button.PcTurnoffmonitors.Press();

        }


        private void OnToiledLidClose()
        {

            foreach (LightEntity light in lightsThatWereOn)
            {
                    light.TurnOn();            
            }

            lightsThatWereOn.Clear();

            //Turn on PC Monitors
            if (_myEntities.Switch.PcPlug.IsOn())
                _myEntities.Button.PcWakekey.Press();
        }

    }
}
