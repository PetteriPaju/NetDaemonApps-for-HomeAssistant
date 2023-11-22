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

            knobs.Add(new DesktopKnob(_0Gbl._myEntities.Sensor.KnobDesktopAction, _0Gbl._myEntities.Sensor.KnobDesktopActionStepSize));
            knobs.Add(new BedKnob(_0Gbl._myEntities.Sensor.BedKnobAction, _0Gbl._myEntities.Sensor.BedKnobActionStepSize));
            knobs.Add(new SofaKnob(_0Gbl._myEntities.Sensor.KnobCouchAction, _0Gbl._myEntities.Sensor.KnobCouchActionStepSize));

        }





        private abstract class Knob{

            SensorEntity action;
            SensorEntity step;
            IDisposable knobStepWaiter;
            protected LightCycler lightCycler;

            public Knob(SensorEntity knobAction, SensorEntity knobStep)
            {
                action = knobAction;
                step = knobStep;

                action.StateAllChanges().Subscribe(x=>DetermineAction(x.New.State ?? ""));

            }

            protected virtual void OnHold()
            {

            }

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
                        lightCycler.NextLight();
                        break;

                    case "toggle":
                        lightCycler.NextLight();
                        break;
                    case "double":
                        lightCycler.GetCurrentLight()?.TurnOffLight();
                        break;
                    case "hold":
                        OnHold();
                        break;
                }

            }

            private void OnStepUp() {


                BrigtnessUp((int)_0Gbl._myEntities.InputNumber.SettingsDefaultKnobStep.State);
                return;
                if (step.State != "None")
                {
                    BrigtnessUp(step.State ?? "");
                }
                else
                {
                    knobStepWaiter = step.StateChanges().Where(x => x.New.State != "None").Subscribe(x => BrigtnessUp(x.New.State ?? ""));
                }
            
            }
            private void OnStepDown()
            {
                BrigtnessDown((int)_0Gbl._myEntities.InputNumber.SettingsDefaultKnobStep.State);
                return;
                if (step.State != "None")
                {
                    BrigtnessDown(step.State ?? "");
                }
                else
                {
                    knobStepWaiter = step.StateChanges().Where(x => x.New.State != "None").Subscribe(x => BrigtnessDown(x.New.State ?? ""));
                }

            }
            private void BrigtnessUp(string num)
            {
                knobStepWaiter?.Dispose();
                int step;
                if (int.TryParse(num, out step))
                {
                    BrigtnessUp(step);
                }
            }
            private void BrigtnessUp(int num)
            {
                knobStepWaiter?.Dispose();
                int step = num;
           
                    if (lightCycler.GetCurrentLight() == null) return;

                    if (lightCycler.GetCurrentLight() != null && lightCycler.GetCurrentLight()?.Attributes?.SupportedFeatures != 0 && lightCycler.GetCurrentLight()?.Attributes?.Brightness < 255)
                    {
                        long minBrightnessFix = (long)MathF.Min((int)(((int)lightCycler.GetCurrentLight().Attributes.Brightness) + step), (int)255);

                        lightCycler.GetCurrentLight().TurnOn(brightness: minBrightnessFix);
                    }
                
            }
            private void BrigtnessDown(string num)
            {
                int step;
                if (int.TryParse(num, out step))
                {
                    BrigtnessDown(step);
                }
           }

                private void BrigtnessDown(int num)
            {
                knobStepWaiter?.Dispose();
                int step = num;


                    if (lightCycler.GetCurrentLight() == null) return;

                    if (lightCycler.GetCurrentLight() != null && lightCycler.GetCurrentLight()?.Attributes?.SupportedFeatures != 0 && ((int)lightCycler.GetCurrentLight()?.Attributes?.Brightness) > 0)
                    {
                        long minBrightnessFix = (long)MathF.Max((int)(((int)lightCycler.GetCurrentLight().Attributes.Brightness) - step), (int)0);

                        lightCycler.GetCurrentLight().TurnOn(brightness: minBrightnessFix);
                    }
                
            }
        }

        private class DesktopKnob : Knob
        {
            public DesktopKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.Light.LivingRoomLight, _0Gbl._myEntities.Light.PcMultipowermeterL2, _0Gbl._myEntities.Light.DesktopLight);
            }

            protected override void OnHold()
            {
                _0Gbl._myEntities.Light.KitchenLight2.TurnOff();
            }
        }
        private class BedKnob : Knob
        {
            public BedKnob(SensorEntity knobAction, SensorEntity knobStep) : base(knobAction, knobStep)
            {
                lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.Light.BedLight);
            }

            protected override void OnHold()
            {
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
                _0Gbl._myEntities.Switch.BedMultiPlugL3.Toggle();
            }
        }
    }
}
