using HomeAssistantGenerated;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Livingroom_Lights : AllowOnlyOneLightGroup
    {
        public Livingroom_Lights(IHaContext ha) : base(ha){ }

        protected override LightEntity[] SetLights()
        {
            return new LightEntity[] { _myEntities.Light.LivingRoomLight, _myEntities.Light.MultiPlugBrightLight, _myEntities.Light.MultiPlugBrightLight, _myEntities.Light.DesktopLight, _myEntities.Light.BedLight };
        }

    }
}
