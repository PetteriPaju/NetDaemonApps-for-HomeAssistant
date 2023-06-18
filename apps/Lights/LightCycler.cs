using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Lights
{
    public class LightCycler
    {
        private List <LightEntity> lightEntities;
        private LightEntity _currentLight = null;
        
        public LightCycler(params LightEntity[] lights)
        {
            lightEntities = lights.ToList();
            FindActiveLight();

            foreach (var l in lightEntities) { 
                SetListener(l);
                if (l.IsOn() && l != _currentLight) l.TurnOff();
                    
                        }
        }

        private void FindActiveLight()
        {
            _currentLight = lightEntities.FirstOrDefault(x => x != null && x.IsOn(),null);

        }

        public LightEntity GetCurrentLight()
        {
            return _currentLight;
        }


        private void SetListener(LightEntity light)
        {
            light.StateChanges().Where(x => x?.New?.State == "on").Subscribe(x => { 
                if(_currentLight != null && _currentLight != light)
                {
                    _currentLight?.TurnOff();
                }
               
                _currentLight = light; 
            });

            light.StateChanges().Where(x => x?.New?.State != "on").Subscribe(x => {
                if (_currentLight != null && _currentLight == light)
                {
                    _currentLight = null;
                }

            });
        }


        public void NextLight()
        {
            var nLight = GetNext();
            if (nLight != null) nLight.TurnOn();
            else _currentLight?.TurnOff();
    
        }
        public void PreviousLight()
        {
            GetPrevious()?.TurnOn();
        }

        public void TurnOff()
        {
            _currentLight?.TurnOff();
        }

        private LightEntity GetNext()
        {
            int currentIndex = currentLightIndex();
            Debug.WriteLine(currentIndex);
            Debug.WriteLine(lightEntities.Count);
            LightEntity nLight = currentIndex >= lightEntities.Count-1 ? null : lightEntities[currentIndex+1];
            return nLight;
        }

        private LightEntity GetPrevious()
        {
            int currentIndex = currentLightIndex();
            LightEntity nLight = currentIndex <= 0 ? lightEntities.Last() : lightEntities[currentIndex - 1];
            return nLight;
        }

        private int currentLightIndex()
        {
            return _currentLight == null ? -1 : lightEntities.IndexOf(_currentLight);
        }



    }
}
