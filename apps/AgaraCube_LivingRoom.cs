using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AgaraCube_LivingRoom : AqaraCube
    {
        protected readonly List<LightEntity> lightEntities;
        protected LightEntity? currentlyActiveLight = null;
        protected LightEntity? lastActiveLight = null;
        private const double lightBrigthnessStep = 50;
        private const double miniumBrightness = 25;
    

        //I have taped my cube with Fluorescent tape, so this is for my own needs
        private Dictionary<string, KnownColor> ColorsToSides = new Dictionary<string, KnownColor> { { "0", KnownColor.Pink}, { "1", KnownColor.Blue}, { "2", KnownColor.Yellow }, { "3" , KnownColor.Purple}, { "4" , KnownColor.Green }, { "5", KnownColor.Orange } };
        public static bool BrightLightTurnedOnByPC = false;

        public AgaraCube_LivingRoom() : base() { 

            lightEntities = new List<LightEntity> { _0Gbl._myEntities?.Light.LivingRoomLight, _0Gbl._myEntities?.Light.PcMultipowermeterL1, _0Gbl._myEntities.Light.DesktopLight };
            void SetActiveLightListener(LightEntity lightE)
            {
                lightE.StateChanges().Where(x => x.New?.State == "on").Subscribe(x => { currentlyActiveLight = lightE; lastActiveLight = lightE; });
                lightE.StateChanges().Where(x => x.New?.State == "off").Subscribe(x => { if (currentlyActiveLight == lightE) currentlyActiveLight = null; });
            }


            foreach (var entity in lightEntities)
            {
                SetActiveLightListener(entity);
            }

            currentlyActiveLight = lightEntities.FirstOrDefault(x => x.IsOn(), null);
            lastActiveLight = currentlyActiveLight;

        }

        protected override SensorEntity? SetCubeActionEntity(){return _0Gbl._myEntities?.Sensor.CubeAction;}
        protected override SensorEntity? SetCubeSideEntity(){return _0Gbl._myEntities?.Sensor.CubeSide;}
        private int GetNextActiveLightIndex()
        {
            if (currentlyActiveLight == null) return 0;


            var indexOfCurrent = lightEntities.IndexOf(currentlyActiveLight);



            if (indexOfCurrent == -1 || indexOfCurrent == lightEntities.Count - 1)
                return 0;

            else return indexOfCurrent + 1;


        }

        protected override void OnRotateLeft()
        {
            base.OnRotateLeft();
            //Check if any light is on and that it supports brightness
            if (currentlyActiveLight != null && currentlyActiveLight?.Attributes?.SupportedFeatures != 0 && (int)currentlyActiveLight?.Attributes?.Brightness > miniumBrightness)
            {
                long minBrightnessFix = (long)MathF.Max((int)((int)currentlyActiveLight.Attributes.Brightness - lightBrigthnessStep), (int)miniumBrightness);

                currentlyActiveLight.TurnOn(brightness: minBrightnessFix);
            }
        }
        
        protected override void OnRotateRight()
        {
            base.OnRotateRight();
            if (currentlyActiveLight != null && currentlyActiveLight?.Attributes?.SupportedFeatures != 0 && (int)currentlyActiveLight?.Attributes?.Brightness < 255)
            {
                currentlyActiveLight.TurnOn(brightness: (long)((int)currentlyActiveLight.Attributes.Brightness + lightBrigthnessStep));
            }
        }
      
        protected override void OnFlip180()
        {
            base.OnFlip180();


            foreach (var entity in lightEntities)
            {
                entity.TurnOff();
            }


        }

        protected override void OnFlip90()
        {
            base.OnFlip90();


            if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn())
            {
                currentlyActiveLight = _0Gbl._myEntities.Light.LivingRoomLight;
                _0Gbl._myEntities.Light.LivingRoomLight.Toggle();

                return;
            }
           

            if(currentlyActiveLight == _0Gbl._myEntities.Light.PcMultipowermeterL1 && BrightLightTurnedOnByPC)
            {
                currentlyActiveLight = _0Gbl._myEntities.Light.LivingRoomLight;
                currentlyActiveLight.TurnOn();

            }
            else
            {
                currentlyActiveLight = lightEntities[GetNextActiveLightIndex()];
                if (currentlyActiveLight != null) currentlyActiveLight.TurnOn();
            }

            BrightLightTurnedOnByPC = false;
        }
     

        protected override void OnShake()
        {
            base.OnShake();
            _0Gbl._myEntities.Switch.PcPlug.TurnOn();
        }

        /*
        protected override void OnSideChaged(string? fromSide, string? toSide)
        {
            if (toSide == null) return;
            if (fromSide == toSide) return;

            KnownColor c = ColorsToSides.First(x => x.Key == toSide).Value;

      
            void TurnOnLight(LightEntity? e)
            {
                if (e == currentlyActiveLight) return;
                currentlyActiveLight?.TurnOff();
                e.TurnOn();
            }

            switch (c)
            {
                case KnownColor.Pink:

                break;

                case KnownColor.Blue:
                    currentlyActiveLight?.TurnOff();
                break;

                case KnownColor.Yellow:

                    TurnOnLight(_00_Globals._myEntities.Light.MultiPlugBrightLight);

                break;

                case KnownColor.Purple:
                    TurnOnLight(_00_Globals._myEntities.Light.LivingRoomLight);
                    break;

                case KnownColor.Green:

                break;

                case KnownColor.Orange:
                    TurnOnLight(_00_Globals._myEntities.Light.DesktopLight);
                break;
            }

        }
        */

        protected override void OnTap()
        {
            base.OnTap();
            if(lastActiveLight != null)
            lastActiveLight?.Toggle();
            else _0Gbl._myEntities.Light.LivingRoomLight.TurnOn();
        }
      



    }
}
