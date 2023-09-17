using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System.Diagnostics;

namespace NetDaemonApps.apps.Hue_Switches
{
    [NetDaemonApp]
    public class Livingroom_Switch : HueSwitch
    {
        public Livingroom_Switch() : base(){ lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode,_0Gbl._myEntities.Light.LivingRoomLight, _0Gbl._myEntities.Light.DesktopLight); }
        private LightCycler lightCycler;

        private const double lightBrigthnessStep = 15;
        private const double miniumBrightness = 10;


        protected override SensorEntity ObtainSwitch(Entities entities)
        {
            return entities.Sensor.HueSwitchLivingRoomAction;
        }

        protected override void OnOnPress()
        {
            lightCycler.NextLight();
        }

        protected override void OnOnHoldRelease()
        {
            base.OnOnHoldRelease();
            lightCycler.TurnOff();
        }

        protected override void OnUpPress()
        {
            base.OnUpPress();
     
                if (lightCycler.GetCurrentLight() == null) return;

            if (lightCycler.GetCurrentLight() != null && lightCycler.GetCurrentLight()?.Attributes?.SupportedFeatures != 0 && lightCycler.GetCurrentLight()?.Attributes?.Brightness < 100)
            {
                long minBrightnessFix = (long)MathF.Min((int)(lightCycler.GetCurrentLight().Attributes.Brightness + lightBrigthnessStep), (int)100);

                lightCycler.GetCurrentLight().TurnOn(brightness: minBrightnessFix);
            }
        }

        protected override void OnUpHold()
        {
            base.OnUpHold();
            this.OnUpPress();
        }


        protected override void OnDownPress()
        {
            base.OnDownPress();

             if (lightCycler.GetCurrentLight() == null) return;

            if (lightCycler.GetCurrentLight() != null && lightCycler.GetCurrentLight()?.Attributes?.SupportedFeatures != 0 && lightCycler.GetCurrentLight()?.Attributes?.Brightness > miniumBrightness)
            {
                long minBrightnessFix = (long)MathF.Max((int)(lightCycler.GetCurrentLight().Attributes.Brightness - lightBrigthnessStep), (int)miniumBrightness);

                lightCycler.GetCurrentLight().TurnOn(brightness: minBrightnessFix);
            }
        }

        protected override void OnDownHold()
        {
           
            base.OnDownHold();        
            this.OnDownPress();
        }

    }
}
