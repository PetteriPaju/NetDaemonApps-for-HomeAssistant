using HomeAssistantGenerated;
using System.Collections.Generic;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Livingroom_Lights : AllowOnlyOneLightGroup
    {
        public Livingroom_Lights() : base() { 
        
           
      
        }

        protected override LightEntity[] SetLights()
        {
            return A0Gbl._myEntities.InputSelect.LivingRoomLights.lightEntitiesFromSelectionDropdown().ToArray();
        }

    }
}
