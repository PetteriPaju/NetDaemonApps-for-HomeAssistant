using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AgaraCube_LivingRoom : AqaraCube
    {
        protected readonly List<LightEntity> lightEntities;
        protected LightEntity? currentlyActiveLight = null;
        private const double lightBrigthnessStep = 50;
        private const double miniumBrightness = 25;
    

        //I have taped my cube with Fluorescent tape, so this is for my own needs
        private Dictionary<string, Color> ColorsToSides = new Dictionary<string, Color> { { "0", Color.Green}, { "1", Color.Yellow}, { "2", Color.Orange }, { "3" ,Color.Red}, { "4" , Color.Purple }, { "5", Color.Blue } };

        public AgaraCube_LivingRoom(IHaContext ha) : base(ha) { 

            lightEntities = new List<LightEntity> { _myEntities.Light.LivingRoomLight, _myEntities.Light.MultiPlugBrightLight, _myEntities.Light.DesktopLight };
            void SetActiveLightListener(LightEntity lightE)
            {
                lightE.StateChanges().Where(x => x.New?.State == "on").Subscribe(x => { currentlyActiveLight = lightE; });
                lightE.StateChanges().Where(x => x.New?.State == "off").Subscribe(x => { if (currentlyActiveLight == lightE) currentlyActiveLight = null; });
            }


            foreach (var entity in lightEntities)
            {
                SetActiveLightListener(entity);
            }

            currentlyActiveLight = lightEntities.FirstOrDefault(x => x.IsOn(), null);

        }

        protected override SensorEntity? SetCubeActionEntity(){return _myEntities?.Sensor.CubeAction;}
        protected override SensorEntity? SetCubeSideEntity(){return _myEntities.Sensor.CubeSide;}
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
            if (currentlyActiveLight != null && currentlyActiveLight?.Attributes?.SupportedFeatures != 0 && currentlyActiveLight?.Attributes?.Brightness > miniumBrightness)
            {
                long minBrightnessFix = (long)MathF.Max((int)(currentlyActiveLight.Attributes.Brightness - lightBrigthnessStep), (int)miniumBrightness);

                currentlyActiveLight.TurnOn(brightness: minBrightnessFix);
            }
        }

        protected override void OnRotateRight()
        {
            base.OnRotateRight();
            if (currentlyActiveLight != null && currentlyActiveLight?.Attributes?.SupportedFeatures != 0 && currentlyActiveLight?.Attributes?.Brightness < 255)
            {
                currentlyActiveLight.TurnOn(brightness: (long)(currentlyActiveLight.Attributes.Brightness + lightBrigthnessStep));
            }
        }

        protected override void OnFlip90()
        {
            base.OnFlip90();

            if (currentlyActiveLight == null || currentlyActiveLight != _myEntities.Light.LivingRoomLight)
            {
                _myEntities.Light.LivingRoomLight.TurnOn();
            }
            else _myEntities.Light.LivingRoomLight.TurnOff();
        }

        protected override void OnFlip180()
        {
            base.OnFlip180();
            currentlyActiveLight = lightEntities[GetNextActiveLightIndex()];
            if (currentlyActiveLight != null) currentlyActiveLight.TurnOn();
        }

        protected override void OnShake()
        {
            base.OnShake();
            _myEntities.Switch.PcPlug.TurnOn();
        }




    }
}
