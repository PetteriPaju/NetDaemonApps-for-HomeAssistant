using HomeAssistantGenerated;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace NetDaemonApps.apps
{    
    /// <summary> Monitors all media players and keeps track if any device is playing. </summary>
    [NetDaemonApp]
    public class MediaPlayingMonitor
    {
         private List<IsTrueConditioner> _monitoreres = new List<IsTrueConditioner>();

        public MediaPlayingMonitor() {


            MediaPlayerEntities mPlayers = _0Gbl._myEntities.MediaPlayer;
            Entity phoneEntity = _0Gbl._myEntities.Sensor.MotoG8PowerLiteMediaSession;
            Entity tabletEntity = _0Gbl._myEntities.Sensor.SmT530MediaSession;

            Entity[] mediaPlayerEntities= new Entity[] { mPlayers.AndroidTv192168020, mPlayers.Envy, mPlayers.LivingRoomDisplay, mPlayers.LivingRoomTv, mPlayers.Pc, phoneEntity};

            void SetEntityForMediaPlayer(Entity ent)
            {
                if(ent == mPlayers.Envy)
                {
                    AddEntity(ent, () => { return ent.State?.ToLower() == "playing" && _0Gbl._myEntities.BinarySensor._192168025.IsOn(); }, CheckAllStates);
                }
                else if (ent == mPlayers.Pc)
                {
                    AddEntity(ent, () => { return ent.State?.ToLower() == "playing" && _0Gbl._myEntities.Switch.PcPlug.IsOn(); }, CheckAllStates);
                }
                else
                    AddEntity(ent, () => { return ent.State?.ToLower() == "playing"; }, CheckAllStates);
            
            }

            foreach(Entity e in mediaPlayerEntities)
            {
                SetEntityForMediaPlayer(e);
            }

            _0Gbl._myScheduler.ScheduleCron("* * * * *", () => CheckAllStates());


            CheckAllStates();
        }


        private void AddEntity(Entity ent, Func<bool> isTrueMethod, Action onValueChanged)
        {
            IsTrueConditioner conditioner = new IsTrueConditioner(ent,isTrueMethod, onValueChanged);
            ent.StateChanges().Subscribe(_ => conditioner.UpdateState());
            _monitoreres.Add(conditioner);

        }
        private void CheckAllStates()
        {
            CheckAllStates(null);
        }
        private void CheckAllStates(IEnumerable<Entity>? ignoreTheseEntities = null)
        {
            bool somethinggPlaying = false;
            foreach(IsTrueConditioner monitor in _monitoreres)
            {
                if (ignoreTheseEntities != null && ignoreTheseEntities.Contains(monitor.entity)) continue;

                if(monitor.currentState == true)
                {
                    somethinggPlaying = true;
                    Console.WriteLine(monitor.entity.EntityId + " is playing something");
                    break;
                }
            }

            if (somethinggPlaying) _0Gbl._myEntities.InputBoolean.MediaPlaying.TurnOn();
            else _0Gbl._myEntities.InputBoolean.MediaPlaying.TurnOff();

        }


        private class IsTrueConditioner
        {
            private Func<bool> isTrueMethod;
            private Action OnValueChanged;
            public readonly Entity entity;
            public bool currentState { get; private set; }

            public IsTrueConditioner(Entity entity, Func<bool> isTrueMethod, bool currentState, Action onValueChanged)
            {
                this.isTrueMethod = isTrueMethod;
                this.currentState = currentState;
                this.OnValueChanged = onValueChanged;
                this.entity = entity;
            }
            public IsTrueConditioner(Entity entity, Func<bool> isTrueMethod, Action onValueChanged)
            {
                this.isTrueMethod = isTrueMethod;
                this.OnValueChanged = onValueChanged;
                currentState = isTrueMethod != null ? isTrueMethod.Invoke() : true;
                this.entity = entity;
            }



            public void UpdateState()
            {
                bool tempstate = isTrueMethod != null ? isTrueMethod.Invoke() : true;
                if (tempstate != currentState)
                {
                    currentState = tempstate;
                    OnValueChanged?.Invoke();
                }
            }

            public void ForceState(bool state)
            {
                if (state != currentState)
                {
                    currentState = state;
                    OnValueChanged?.Invoke();
                }
                else
                    this.currentState = state;

            }



        }



    }
}
