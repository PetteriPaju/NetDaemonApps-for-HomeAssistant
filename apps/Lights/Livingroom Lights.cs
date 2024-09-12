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
            return Extensions.LightgroupToEntytiList(_0Gbl._myEntities.Light.LivingRoomLights.Attributes.EntityId).ToArray();
        }

    }
}
