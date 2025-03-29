using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class LoraTapDekstop: LoraTabs
    {
        private IDisposable? cancelRoutine = null;
        int pwrpressMode = 0;
        protected LightCycler lightCycler;
        public LoraTapDekstop() : base() {
            lightCycler = new LightCycler(A0Gbl._myEntities.InputBoolean.GuestMode, A0Gbl._myEntities.InputBoolean.LightgroupLivingroomEnabled, A0Gbl._myEntities.InputSelect.DesktopKnobLights.lightEntitiesFromSelectionDropdown().ToArray());
        }
        protected override SensorEntity GetEntity()
        {
            return A0Gbl._myEntities.Sensor.Lrtabdesktopaction;
        }

        protected override void OnAny()
        {
            IsAsleepMonitor.Awake();
            A0Gbl._myEntities.InputBoolean.Ishome.TurnOn();
        }

        protected override void On1Press()
        {
            base.On1Press();
            lightCycler.NextLight();
        }
        protected override void On1Hold()
        {
            base.On1Hold();
            lightCycler.TurnOff();
        }
        protected override void On1Double()
        {   
            base.On1Double();
            lightCycler.Reset();
        }

        protected override void On2Press()
        {
            base.On2Press();
            A0Gbl._myEntities.Button.DesktopK24v8npWakeOnLan.Press();
            A0Gbl._myEntities.Switch.PcPlug.TurnOn();
            A0Gbl._myEntities.Light.PcMultipowermeterL1.TurnOn();
            A0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOn();
            A0Gbl._myEntities.Switch.FanPlug.TurnOn();
        }

        protected override void On4Press()
        {
            base.On3Press();
            A0Gbl._myEntities.Switch.PcMultipowermeterMonitors.Toggle();
        }



        protected override void On5Press()
        {
            base.On5Press();
            IsAsleepMonitor.Awake();
            if (A0Gbl._myEntities.Switch.DeskFans.IsOff())
            {
                A0Gbl._myEntities.Switch.DeskFans.TurnOn();
            }
            else if (A0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOn() && A0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOn())
            {
                A0Gbl._myEntities.Switch.UsbMultiFansCenter.TurnOff();
            }
            else if (A0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOff() && A0Gbl._myEntities.Switch.UsbMultiFansLeft.IsOn())
            {
                A0Gbl._myEntities.Switch.UsbMultiFansCenter.Toggle();
                A0Gbl._myEntities.Switch.UsbMultiFansLeft.Toggle();

            }
            else
            {
                A0Gbl._myEntities.Switch.DeskFans.TurnOff();

            }
        }
        protected override void On3Press()
        {
            base.On5Press();
            string message = "";
            pwrpressMode = pwrpressMode == -1 ? 0 : pwrpressMode;
            switch (pwrpressMode)
            {
                case 0:
                    if (A0Gbl._myEntities.Switch.BrightLightPlug.IsOn())
                    {
                        message = "Modem Off";
                    }
                    else
                    {
                        message = "Modem On";
                    }

                    cancelRoutine?.Dispose();
                    cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(A0Gbl._myEntities.Switch.BrightLightPlug.IsOn() ? 10 : 0), () => {

                        A0Gbl._myEntities.Switch.BrightLightPlug.Toggle();

                        pwrpressMode = -1;
                        cancelRoutine = null;

                    });
                    break;

                case 1:
                    cancelRoutine?.Dispose();
                    message = "Everything Off";
                    cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(30), () => {
                        A0Gbl._myServices.Script.TurnOffEverything();
                        pwrpressMode = 0;
                    });
                    break;
                case 2:
                    message = "Cancel";
                    if (cancelRoutine != null)
                    {
                        cancelRoutine.Dispose();
                        cancelRoutine = null;
                    }
                    break;
            }
            pwrpressMode = pwrpressMode == 2 ? 0 : pwrpressMode + 1;

            TTS.Speak(message, TTS.TTSPriority.IgnoreAll);

        }

        protected override void On5Hold()
        {
            base.On5Hold(); 
            A0Gbl._myEntities.Switch.DeskFans.Toggle();
        }

        protected override void On6Press()
        {
            base.On6Press();
            IsAsleepMonitor.Awake();
            A0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
        }
    }

    [NetDaemonApp]
    public class LoraTapBed : LoraTabs
    {
        private IDisposable? cancelRoutine = null;
        int pwrpressMode = 0;

        public LoraTapBed() : base()
        {
        }
        protected override SensorEntity GetEntity()
        {
            return A0Gbl._myEntities.Sensor.Lrtabbedaction;
        }

        protected override void OnAny()
        {
            base.OnAny();
            if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
            {
                A0Gbl._myEntities.Switch.PcMultipowermeterMonitors.TurnOff();
                A0Gbl._myEntities.Switch.DeskFans.TurnOff();
                A0Gbl._myEntities.Light.ToiletLight1.TurnOff();
            }
            A0Gbl._myEntities.InputBoolean.Ishome.TurnOn();
        }
        protected override void On1Press()
        {
            base.On1Press();        
            A0Gbl._myEntities.Light.BedLight.Toggle();

        }

        protected override void On1Hold()
        {
            base.On1Hold();
            A0Gbl._myEntities.Light.AllLights.TurnOff();    
        }

        protected override void On2Press()
        {
            base.On1Press();
            A0Gbl._myEntities.Switch.BedMultiPlugL1.Toggle();

        }

        protected override void On3Press()
        {
            base.On3Press();
            A0Gbl._myEntities.Switch.InkplatePlug.Toggle();
        }
        protected override void On4Press()
        {
            base.On2Press();
            TimeSpan? timeDiff = DateTime.Now - A0Gbl._myEntities?.InputDatetime.Lastisasleeptime.GetDateTime();
            string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture);
            if (A0Gbl._myEntities.InputBoolean.Isasleep.IsOn()) ttsTime += ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ? " and " + timeDiff?.Minutes + "minutes" : ". ");

            TTS.Speak(ttsTime, TTS.TTSPriority.IgnoreAll);
        }

        protected override void On5Press()
        {
            base.On5Press();
            string message = "";
            pwrpressMode = pwrpressMode == -1 ? 0 : pwrpressMode;
            switch (pwrpressMode)
            {
                case 0:
                    if (A0Gbl._myEntities.Switch.BrightLightPlug.IsOn())
                    {
                        message = "Modem Off";
                    }
                    else
                    {
                        message = "Modem On";
                    }

                    cancelRoutine?.Dispose();
                    cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(A0Gbl._myEntities.Switch.BrightLightPlug.IsOn() ? 10 : 0), () => {

                            A0Gbl._myEntities.Switch.BrightLightPlug.Toggle();
                        
                        pwrpressMode = -1;
                        cancelRoutine = null;

                    });
                    break;

                case 1:
                    cancelRoutine?.Dispose();
                    message = "Everything Off";
                    cancelRoutine = A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(30), () => {
                        A0Gbl._myServices.Script.TurnOffEverything();
                        pwrpressMode = 0;
                    });
                    break;
                case 2:
                    message = "Cancel";
                    if (cancelRoutine != null)
                    {
                        cancelRoutine.Dispose();
                        cancelRoutine = null;
                    }
                    break;
            }
            pwrpressMode = pwrpressMode == 2 ? 0 : pwrpressMode + 1;

            TTS.Speak(message, TTS.TTSPriority.IgnoreAll);

        }

        protected override void On6Press()
        {
            base.On6Press();
            IsAsleepMonitor.ToggleMode();

        }


    }

    public abstract class LoraTabs
    {

        public LoraTabs()
        {

            GetEntity()?.StateChanges().Subscribe(x => DetermineAction(x.New));

        }

        protected virtual SensorEntity GetEntity()
        {
            return null;
        }

        protected virtual void DetermineAction(EntityState<SensorAttributes>? entity)
        {
            Console.WriteLine(entity.State);

            if (entity == null) return;

            if (IsHomeManager.CancelIsHome()) return;

            switch (entity.State) {

                case "1_single": On1Press(); break;                
                
                case "1_double": On1Double(); break;                
                
                case "1_hold": On1Hold(); break;

                case "2_single": On2Press(); break;                
                
                case "2_double": On2Double(); break;                
                
                case "2_hold": On2Hold(); break;

                case "3_single": On3Press(); break;                
                
                case "3_double": On3Double(); break;                
                
                case "3_hold": On3Hold(); break;

                case "4_single": On4Press(); break;                
                
                case "4_double": On4Double(); break;                
                
                case "4_hold": On4Hold(); break;
                case "5_single": On5Press(); break;                
                
                case "5_double": On5Double(); break;                
                
                case "5_hold": On5Hold(); break;
                case "6_single": On6Press(); break;                
                
                case "6_double": On6Double(); break;                
                
                case "6_hold": On6Hold(); break;
 
            }


        }
        protected virtual void OnAny()
        {

        }
        protected virtual void OnAnyPress()
        {
            OnAny();
        }
        protected virtual void OnAnyHold()
        {
            OnAny();
        }
        protected virtual void OnAnyDouble()
        {
            OnAny();
        }
        protected virtual void On1Press()
        {
            OnAnyPress();
        }        
        protected virtual void On1Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On1Hold()
        {
            OnAnyHold();
        }
        protected virtual void On2Press()
        {
            OnAnyPress();
        }        
        protected virtual void On2Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On2Hold()
        {
            OnAnyHold();
        }
        protected virtual void On3Press()
        {
            OnAnyPress();

        }        
        protected virtual void On3Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On3Hold()
        {
            OnAnyHold();
        }
        protected virtual void On4Press()
        {
            OnAnyPress();
        }        
        protected virtual void On4Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On4Hold()
        {
            OnAnyHold();
        }       
        protected virtual void On5Press()
        {
            OnAnyPress();
        }        
        protected virtual void On5Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On5Hold()
        {
            OnAnyHold();
        }
        protected virtual void On6Press()
        {
            OnAnyPress();
        }        
        protected virtual void On6Double()
        {
            OnAnyDouble();
        }        
        protected virtual void On6Hold()
        {
            OnAnyHold();
        }
        
    
    }

}
