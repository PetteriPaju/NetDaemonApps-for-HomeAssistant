using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AqaraCube
    {
        protected readonly SensorEntity? cubeEntity;
        protected readonly Entities _myEntities;
        protected readonly List<LightEntity> lightEntities;
        protected LightEntity? currentlyActiveLight =  null;
        private const double lightBrigthnessStep = 50;
        private const double miniumBrightness = 25;

        public AqaraCube(IHaContext ha)
        {
            _myEntities = new Entities(ha);

            cubeEntity = _myEntities.Sensor.CubeAction;
            cubeEntity.StateChanges().Subscribe(x => DetermineAction(x?.Entity?.State ?? "Unknown"));
            lightEntities = new List<LightEntity> { _myEntities.Light.LivingRoomLight, _myEntities.Light.MultiPlugBrightLight, _myEntities.Light.DesktopLight };

            void SetActiveLightListener(LightEntity lightE)
            {
                lightE.StateChanges().Where(x => x.New?.State == "on").Subscribe(x => { currentlyActiveLight = lightE; });
                lightE.StateChanges().Where(x => x.New?.State == "off").Subscribe(x => {  if(currentlyActiveLight == lightE) currentlyActiveLight = null; });
            }


            foreach (var entity in lightEntities)
            {
                SetActiveLightListener(entity);
            }

            currentlyActiveLight = lightEntities.FirstOrDefault(x => x.IsOn(), null);

        }

        private int GetNextActiveLightIndex()
        {
            if (currentlyActiveLight == null) return 0;


            var indexOfCurrent = lightEntities.IndexOf(currentlyActiveLight);



            if (indexOfCurrent == -1 || indexOfCurrent == lightEntities.Count - 1) 
            return 0;

            else return indexOfCurrent + 1;


        }

        private void DetermineAction(string stateName)
        {

            switch (stateName)
            {
               
                case "rotate_left":
                    OnRotateLeft();
                    break;

                case "rotate_right":
                    OnRotateRight();
                    break;

                case "tap":
                    OnTap();
                    break;

                case "flip90":
                    OnFlip90();
                    break;


                case "shake":
                    OnShake();
                    break;

                case "flip180":
                    OnFlip180();
                    break;

            }

        }
        /// <summary> Power-button Press Down</summary>
        protected virtual void OnRotateLeft() {

            //Check if any light is on and that it supports brightness
            if(currentlyActiveLight != null && currentlyActiveLight.Attributes.SupportedFeatures != 0 && currentlyActiveLight.Attributes.Brightness > miniumBrightness)
            {
              long minBrightnessFix =  (long)MathF.Max((int)(currentlyActiveLight.Attributes.Brightness - lightBrigthnessStep), (int)miniumBrightness);
            
                currentlyActiveLight.TurnOn(brightness: minBrightnessFix);
            }
   
        
        }
        /// <summary> Power-button Press Release</summary>
        protected virtual void OnRotateRight() {

            if (currentlyActiveLight != null && currentlyActiveLight.Attributes.SupportedFeatures != 0 && currentlyActiveLight.Attributes.Brightness < 255)
            {
                currentlyActiveLight.TurnOn(brightness: (long)(currentlyActiveLight.Attributes.Brightness + lightBrigthnessStep));
            }


        }
        /// <summary> Power-button Hold</summary>
        protected virtual void OnTap() { }
        /// <summary> Power-button Hold release</summary>
        protected virtual void OnFlip90() {


            if (currentlyActiveLight == null || currentlyActiveLight != _myEntities.Light.LivingRoomLight)
            {
                _myEntities.Light.LivingRoomLight.TurnOn();
            }
            else _myEntities.Light.LivingRoomLight.TurnOff();



        }

        /// <summary> Brighness Up-button Press Down</summary>
        protected virtual void OnShake() { _myEntities.Switch.PcPlug.TurnOn(); }
        /// <summary> Brighness Up-button Press Release</summary>
        protected virtual void OnFlip180() {


            currentlyActiveLight = lightEntities[GetNextActiveLightIndex()];
            if (currentlyActiveLight != null) currentlyActiveLight.TurnOn();


        }
        /// <summary> Brighness Up-button Hold</summary>

    }
}
