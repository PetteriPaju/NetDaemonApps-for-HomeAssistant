using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class Knobs
    {
        List<Knob> knobs = new List<Knob>();
        public Knobs() {

            knobs.Add(new DesktopKnob(_0Gbl._myEntities.Sensor.KnobDesktopAction, _0Gbl._myEntities.Sensor.KnobDesktopDelta));
            knobs.Add(new BedKnob(_0Gbl._myEntities.Sensor.BedKnobAction, _0Gbl._myEntities.Sensor.KnobBedDelta));
            knobs.Add(new SofaKnob(_0Gbl._myEntities.Sensor.KnobCouchAction, _0Gbl._myEntities.Sensor.KnobCouchDelta));

        }





        private abstract class Knob{

            SensorEntity action;
            protected bool flipDialDirection = false;
            SensorEntity knobDelta;

            int lasktKnownStep = 0;
            IDisposable knobStepWaiter;
            protected LightCycler lightCycler;

            public Knob(SensorEntity knobAction, SensorEntity _knobDelta)
            {
                action = knobAction;
                knobDelta = _knobDelta;

                knobDelta.StateChanges().Subscribe(x => OnBrightnesssDelta());

                action.StateAllChanges().Subscribe(x=>DetermineAction(x.New.State ?? ""));
       
            }


            protected virtual void OnBrightnesssDelta()
            {
                if (lightCycler.GetCurrentLight() == null) return;

                if (lightCycler.GetCurrentLight() != null && lightCycler.GetCurrentLight()?.Attributes?.SupportedFeatures != 0)
                {
                    int step;
                    if (int.TryParse(knobDelta.State, out step))
                    {
                        step = (int)Math.Round(step * (flipDialDirection ? -1 : 1) * _0Gbl._myEntities.InputNumber.SettingsKnobSensitivity.State ?? 1);
       
                        long minBrightnessFix = (long)MathF.Min((int)(((int)lightCycler.GetCurrentLight().Attributes.Brightness) + step), (int)255);
                        minBrightnessFix = (long)MathF.Max((int)(((int)lightCycler.GetCurrentLight().Attributes.Brightness) + step), (int)10);

                        lightCycler.GetCurrentLight().TurnOn(brightness: minBrightnessFix, transition:1);
                    }


                }
            }
            protected virtual void OnHold()
            {
                _0Gbl._myServices.Script.PlayInterfaceSound();
            }

            protected virtual void OnHoldRelease() { }

            private void DetermineAction(string stateName)
            {
                knobStepWaiter?.Dispose();
             
                switch (stateName)
                {
                    case "brightness_step_down":
                        OnStepUp();
                    break;

                    case "rotate_left":
                        OnStepUp();
                     break;
                    case "rotate_right":
                        OnStepDown();
                        break;
                    case "brightness_step_up":
                        OnStepDown();
                    break;
                    case "single":
                        OnPress();
                        break;

                    case "toggle":
                        OnPress();
                        break;
                    case "double":
                        lightCycler.GetCurrentLight()?.TurnOffLight();
                        break;
                    case "hold":
                        OnHold();
                        break;

                    case "hue_move":
                        OnHold();
                        break;

                    case "hue_stop":
                        OnHoldRelease();
                        break;

                }

            }

            protected virtual void OnPress()
            {
                lightCycler.NextLight();
            }

            protected virtual void OnStepUp() {

         
            }
            protected virtual void OnStepDown()
            {


            }
        }

        private class DesktopKnob : Knob
        {
            public DesktopKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                flipDialDirection = true;
                lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.Light.LivingRoomLight, _0Gbl._myEntities.Light.PcMultipowermeterL1);
            }

            protected override void OnHold()
            {
                base.OnHold();
                _0Gbl._myEntities.Light.KitchenLight2.TurnOff();
            }
        }
        private class BedKnob : Knob
        {
            public BedKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.Light.BedLight);
            }

            protected override void OnPress()
            {
                if (_0Gbl._myEntities.Light.LivingRoomLights.IsOn())
                    _0Gbl._myEntities.Light.LivingRoomLights.TurnOff();
                else _0Gbl._myEntities.Light.BedLight.Toggle();
            }


            protected override void OnHold()
            {
                base.OnHold();
                _0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle();
            }
        }
        private class SofaKnob : Knob
        {
            public SofaKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.Light.DesktopLight, _0Gbl._myEntities.Light.LivingRoomLight);
            }

            protected override void OnHold()
            {
                base.OnHold();
                _0Gbl._myEntities.Switch.BedMultiPlugL3.Toggle();
            }
        }
    }
}
