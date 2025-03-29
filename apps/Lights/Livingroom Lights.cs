using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Livingroom_Lights : AllowOnlyOneLightGroup
    {
        public Livingroom_Lights() : base() { 
        
           
      
        }


        protected override bool isEnabled()
        {
            return base.isEnabled() && A0Gbl._myEntities.InputBoolean.LightgroupLivingroomEnabled.IsOn();
        }

        protected override LightEntity[] SetLights()
        {
            return A0Gbl._myEntities.InputSelect.LivingRoomLights.lightEntitiesFromSelectionDropdown().ToArray();
        }

    }
}
