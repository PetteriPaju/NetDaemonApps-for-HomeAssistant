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

            knobs.Add(new DesktopKnob(A0Gbl._myEntities.Sensor.KnobDesktopAction, A0Gbl._myEntities.Sensor.KnobDesktopDelta));
            knobs.Add(new BedKnob(A0Gbl._myEntities.Sensor.KnobBedAction, A0Gbl._myEntities.Sensor.KnobBedDelta));
            knobs.Add(new SofaKnob(A0Gbl._myEntities.Sensor.KnobCouchAction, A0Gbl._myEntities.Sensor.KnobCouchDelta));

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
                    long step;
                    if (long.TryParse(knobDelta.State, out step))
                    {
                        step = (int)Math.Round(step * (flipDialDirection ? -1 : 1) * A0Gbl._myEntities.InputNumber.SettingsKnobSensitivity.State ?? 1);
       
                        long minBrightnessFix = Math.Min(((long)lightCycler.GetCurrentLight().getBrightness() + step), (long)255);
                        minBrightnessFix = (Math.Max(minBrightnessFix, (long)10));
                        lightCycler.GetCurrentLight().TurnOn(brightnessPct: (long)(((float)minBrightnessFix / 255f) * 100), transition:1);
                    }

                 
                }
            }
            protected virtual void OnHold()
            {
                A0Gbl._myServices.Script.PlayInterfaceSound();
            }

            protected virtual void OnHoldRelease() { }

            private void DetermineAction(string stateName)
            {
                knobStepWaiter?.Dispose();
                if (IsHomeManager.CancelIsHome()) return;
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
                lightCycler?.NextLight();
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
                flipDialDirection = false;
                lightCycler = new LightCycler(A0Gbl._myEntities.InputBoolean.GuestMode,A0Gbl._myEntities.InputSelect.DesktopKnobLights.lightEntitiesFromSelectionDropdown().ToArray());
            }

            protected override void OnHold()
            {
                base.OnHold();
                if (A0Gbl._myEntities.Switch.PcPlug.IsOn())
                    A0Gbl._myEntities.Button.PcWalkingpadtoggle.Press();
                else
                    return;
            }
            protected override void OnPress()
            {

            }
        }
        private class BedKnob : Knob
        {
            public BedKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                lightCycler = new LightCycler(A0Gbl._myEntities.InputBoolean.GuestMode, A0Gbl._myEntities.InputSelect.BedKnobLights.lightEntitiesFromSelectionDropdown().ToArray());
            }

            protected override void OnHold()
            {
                base.OnHold();
                A0Gbl._myEntities.Switch.InkplatePlug.Toggle();
            }
            protected override void OnPress()
            {

            }
        }
        private class SofaKnob : Knob
        {
            public SofaKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
               // lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.InputSelect.SofaKnobLights.lightEntitiesFromSelectionDropdown().ToArray());
            }

            protected override void OnPress()
            {
                base.OnPress();

                
                A0Gbl._myEntities.InputBoolean.Ishome.Toggle();

                TTS.Speak(A0Gbl._myEntities.InputBoolean.Ishome.IsOn() ? "Ok, bye!" : "Welcome Back", TTS.TTSPriority.IgnoreAll);
               
            }
        }
    }
}
