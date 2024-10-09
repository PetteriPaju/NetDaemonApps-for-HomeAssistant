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

        private readonly TimeSpan lightOnTimeOutSpan = new TimeSpan(1, 0, 0);
        public static bool forceLightOn = false;
        private readonly TimeSpan motionSensorTimeOutSpan = new TimeSpan(0, 0, 10);

        public Toiler_Light_Automation()
        {
            targetLights.Add(_0Gbl._myEntities.Light.BedLight);
            targetLights.Add(_0Gbl._myEntities.Light.PcMultipowermeterL1);

            targetLights.Add(_0Gbl._myEntities.Light.LivingRoomLight);
            targetLights.Add(_0Gbl._myEntities.Light.DesktopLight);
            targetLights.Add(_0Gbl._myEntities.Light.MonitorLight);

            _0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges().Subscribe(_ =>
             {
                  if (_0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.IsOn() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn())
                             _0Gbl._myEntities.Light.ToiletLight1.TurnOnLight();
                  else if (_0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.IsOff() && !isSeatOpen()) _0Gbl._myEntities.Light.ToiletLight1.TurnOffLight();
             });

            _0Gbl._myEntities.BinarySensor.ToilerSeatSensorContact
           .StateChanges()
           .Subscribe(_ => {

               if (_0Gbl._myEntities.InputBoolean.SensorsActive.IsOff() || _0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;

               if (isSeatOpen())
                   OnToiledLidOpen();
               else
                   OnToiledLidClose();
               
               });


            _0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy.StateChanges()
            .Where(e => e.New.IsOn() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
            .Subscribe(_ =>
            {
                if (!isSeatOpen() && !forceLightOn)
                   _0Gbl._myEntities.Light.ToiletLight1.TurnOffLight();
            });


        }
      
        private bool isSeatOpen()
        {
            return _0Gbl._myEntities.BinarySensor.ToilerSeatSensorContact.IsOn() ? true : false;
        }



    private void OnToiledLidOpen()
        {
            _0Gbl._myEntities.Light.ToiletLight1.TurnOnLight();
            if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
            lightsThatWereOn.Clear();
            _0Gbl._myEntities.Light.HallwayLight.TurnOffLight();
            foreach (LightEntity light in targetLights)
            {
                if (light != null && light.State != "unavailable" && light.IsOn())
                {
                    lightsThatWereOn.Add(light);
                    light.TurnOffLight();
                }
            }

            //Turn off PC Monitors while in toilet
            /*if (_0Gbl._myEntities.Switch.PcPlug.IsOn())
                _0Gbl._myEntities.Button.PcTurnoffmonitors.Press();
            */

            TTS.Speak("Open");

        }


        private void OnToiledLidClose()
        {
            if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;

            foreach (LightEntity light in lightsThatWereOn)
            {
                light.TurnOnLight();
            }

            lightsThatWereOn.Clear();
            TTS.Speak("Close");
            //Turn on PC Monitors
            /*
            if (_0Gbl._myEntities.Switch.PcPlug.IsOn())
                _0Gbl._myEntities.Button.PcWakekey.Press();
            */
        }


    }
}
