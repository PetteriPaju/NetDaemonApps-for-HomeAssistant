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
            /*
            _00_Globals._myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges().Subscribe(_ =>
      {
          if (_00_Globals._myEntities.BinarySensor.ToiletSensorOccupancy.IsOn() && _00_Globals._myEntities.InputBoolean.SensorsActive.IsOn())
              _00_Globals._myEntities.Light.ToiletLight1.TurnOnLight();
          else if (_00_Globals._myEntities.BinarySensor.ToiletSeatSensorContact.IsOn()) _00_Globals._myEntities.Light.ToiletLight1.TurnOffLight();
      });
            */

            /*
            _0Gbl._myEntities.InputBoolean.Toiletseathelper
           .StateChanges().Where(e => (e.New?.IsOff() ?? true) && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn())
           .Subscribe(_ => OnToiledLidOpen());

            _0Gbl._myEntities.InputBoolean.Toiletseathelper
           .StateChanges().Where(e => (e.New?.IsOn()?? true) && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() )
           .Subscribe(_ => OnToiledLidClose());*/



            _0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .Where(e => e.New?.State == "on" && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn())
            .Subscribe(_ =>
            {
                _0Gbl._myEntities.Light.ToiletLight1.TurnOnLight();

            });

            _0Gbl._myEntities.BinarySensor.ToiletSensorOccupancy.StateChanges()
            .WhenStateIsFor(e => e?.State == "off" && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn(), TimeSpan.FromMinutes(2),_0Gbl._myScheduler)
            .Subscribe(_ =>
            {
                // if(_0Gbl._myEntities.InputBoolean.Toiletseathelper.IsOn() && !forceLightOn)
                if ( !forceLightOn)
                    _0Gbl._myEntities.Light.ToiletLight1.TurnOffLight();

            });


            _0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy.StateChanges()
            .Where(e => e.New.IsOn() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
            .Subscribe(_ =>
            {
              //  if (_0Gbl._myEntities.InputBoolean.Toiletseathelper.IsOn() && !forceLightOn)
               //     _0Gbl._myEntities.Light.ToiletLight1.TurnOffLight();
            });


        }
      



    private void OnToiledLidOpen()
        {
            _0Gbl._myEntities.Light.ToiletLight1.TurnOnLight();
            if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
            lightsThatWereOn.Clear();
            _0Gbl._myEntities.Light.HallwayLight.TurnOffLight();
            foreach (LightEntity light in targetLights)
            {
                if (light != null && light.State != "unavailable" && light.IsOn() && light != _0Gbl._myEntities.Light.PcMultipowermeterL1)
                {
                    lightsThatWereOn.Add(light);
                    light.TurnOffLight();
                }
            }

            //Turn off PC Monitors while in toilet
            if (_0Gbl._myEntities.Switch.PcPlug.IsOn())
                _0Gbl._myEntities.Button.PcTurnoffmonitors.Press();



        }


        private void OnToiledLidClose()
        {
            if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;

            foreach (LightEntity light in lightsThatWereOn)
            {
                light.TurnOnLight();
            }

            lightsThatWereOn.Clear();

            //Turn on PC Monitors
            if (_0Gbl._myEntities.Switch.PcPlug.IsOn())
                _0Gbl._myEntities.Button.PcWakekey.Press();
        }


    }
}
