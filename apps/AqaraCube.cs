using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
 
    public abstract class AqaraCube
    {
        protected readonly SensorEntity? cubeEntity;
        protected readonly SensorEntity? cubeSideEntity;
        protected readonly Entities _myEntities;
        protected string? lastKnownSide;



        public AqaraCube(IHaContext ha)
        {
            _myEntities = new Entities(ha);
            cubeEntity = SetCubeActionEntity();
            cubeSideEntity = SetCubeSideEntity();
            
            cubeEntity?.StateChanges().Subscribe(x => DetermineAction(x?.Entity?.State ?? "Unknown"));
            cubeSideEntity?.StateChanges().Subscribe(x => Console.WriteLine(x?.New?.State));

            lastKnownSide = cubeSideEntity?.State;
            cubeEntity?.StateChanges().Subscribe(x => DetermineAction(x?.Entity?.State ?? "Unknown"));

          

        }

        protected virtual SensorEntity? SetCubeActionEntity() { return null; }
        protected virtual SensorEntity? SetCubeSideEntity() { return null; }



        protected void DetermineAction(string stateName)
        {

            switch (stateName)
            {
               
                case "rotate_left":
                    OnRotateLeft();
                    break;

                case "rotate_right":
                    OnRotateRight();
                    break;

                case "tap":
                    OnTap();
                    break;

                case "flip90":
                    OnFlip90();
                    break;


                case "shake":
                    OnShake();
                    break;

                case "flip180":
                    OnFlip180();
                    break;

            }

        }
        /// <summary> Power-button Press Down</summary>
        protected virtual void OnRotateLeft() {}
        /// <summary> Power-button Press Release</summary>
        protected virtual void OnRotateRight() {}
        /// <summary> Power-button Hold</summary>
        protected virtual void OnTap() { }
        /// <summary> Power-button Hold release</summary>
        protected virtual void OnFlip90() {}

        /// <summary> Brighness Up-button Press Down</summary>
        protected virtual void OnShake() {  }
        /// <summary> Brighness Up-button Press Release</summary>
        protected virtual void OnFlip180() {}

        protected virtual void OnSideChaged(string? fromSide, string? toSide) { 
        
           

        }


    }
}
