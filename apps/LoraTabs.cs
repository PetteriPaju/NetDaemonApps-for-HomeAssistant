using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.apps.Lights;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class LoraTapDekstop: LoraTabs
    {
        protected LightCycler lightCycler;
        public LoraTapDekstop() : base() {
            lightCycler = new LightCycler(_0Gbl._myEntities.InputBoolean.GuestMode, _0Gbl._myEntities.InputSelect.DesktopKnobLights.lightEntitiesFromSelectionDropdown().ToArray());
        }
        protected override SensorEntity GetEntity()
        {
            return _0Gbl._myEntities.Sensor.LrtabPcAction;
        }

        protected override void On1Press()
        {
            base.On1Press();
            lightCycler.NextLight();


        }
        protected override void On1Hold()
        {
            lightCycler.TurnOff();
        }
        protected override void On1Double()
        {
            lightCycler.Reset();
        }

        protected override void On2Press()
        {
            base.On2Press();
            _0Gbl._myEntities.Switch.PcPlug.TurnOn();
        }

        protected override void On3Press()
        {
            base.On2Press();
            _0Gbl._myEntities.Switch.PcMultipowermeterMonitors.Toggle();
        }



        protected override void On5Press()
        {
            base.On5Press();

            if (_0Gbl._myEntities.Switch.DeskFans.IsOff())
            {
                _0Gbl._myEntities.Switch.DeskFans.TurnOn();
            }
            else if (_0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOn() && _0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOn())
            {
                _0Gbl._myEntities.Switch.UsbMultiFansCenter.TurnOff();
            }
            else if (_0Gbl._myEntities.Switch.UsbMultiFansCenter.IsOff() && _0Gbl._myEntities.Switch.UsbMultiFansLeft.IsOn())
            {
                _0Gbl._myEntities.Switch.UsbMultiFansCenter.Toggle();
                _0Gbl._myEntities.Switch.UsbMultiFansLeft.Toggle();

            }
            else
            {
                _0Gbl._myEntities.Switch.DeskFans.TurnOff();

            }
        }

        protected override void On5Hold()
        {
            _0Gbl._myEntities.Switch.DeskFans.Toggle();
        }

        protected override void On6Press()
        {
            _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
        }
        protected override void On6Hold()
        {
            _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
        }

    }

    [NetDaemonApp]
    public class LoraTapBed : LoraTabs
    {

        public LoraTapBed() : base()
        {
        }
        protected override SensorEntity GetEntity()
        {
            return _0Gbl._myEntities.Sensor.LrTabBedAction;
        }

        protected override void On1Press()
        {
            base.On1Press();
            
            _0Gbl._myEntities.Light.BedLight.Toggle();


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

        protected virtual void On1Press()
        {

        }        
        protected virtual void On1Double()
        {

        }        
        protected virtual void On1Hold()
        {

        }
        protected virtual void On2Press()
        {

        }        
        protected virtual void On2Double()
        {

        }        
        protected virtual void On2Hold()
        {

        }
        protected virtual void On3Press()
        {

        }        
        protected virtual void On3Double()
        {

        }        
        protected virtual void On3Hold()
        {

        }
        protected virtual void On4Press()
        {

        }        
        protected virtual void On4Double()
        {

        }        
        protected virtual void On4Hold()
        {

        }       
        protected virtual void On5Press()
        {

        }        
        protected virtual void On5Double()
        {

        }        
        protected virtual void On5Hold()
        {

        }
        protected virtual void On6Press()
        {

        }        
        protected virtual void On6Double()
        {

        }        
        protected virtual void On6Hold()
        {

        }
        
    
    }

}
