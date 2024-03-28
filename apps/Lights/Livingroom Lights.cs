using HomeAssistantGenerated;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Livingroom_Lights : AllowOnlyOneLightGroup
    {
        public Livingroom_Lights() : base() { }

        protected override LightEntity[] SetLights()
        {
            return new LightEntity[] { _0Gbl._myEntities.Light.LivingRoomLight,  _0Gbl._myEntities.Light.PcMultipowermeterL1, _0Gbl._myEntities.Light.DesktopLight, _0Gbl._myEntities.Light.BedLight };
        }

    }
}
