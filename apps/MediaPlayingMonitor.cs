using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{    
    /// <summary> Monitors all media players and keeps track if any device is playing. </summary>
    [NetDaemonApp]
    public class MediaPlayingMonitor
    {
        private readonly Entities _myEntities;
         private List<IsTrueConditioner> _monitoreres = new List<IsTrueConditioner>();

        public MediaPlayingMonitor(IHaContext ha) {
            _myEntities = new Entities(ha);

            MediaPlayerEntities mPlayers = _myEntities.MediaPlayer;
            Entity phoneEntity = _myEntities.Sensor.MotoG8PowerLiteMediaSession;
            Entity tabletEntity = _myEntities.Sensor.SmT530MediaSession;

            Entity[] mediaPlayerEntities= new Entity[] { mPlayers.AndroidTv192168020, mPlayers.Envy, mPlayers.LivingRoomDisplay, mPlayers.LivingRoomTv, mPlayers.OlohuoneNest, mPlayers.Pc, mPlayers.VlcTelnet, phoneEntity, tabletEntity };

            void SetEntityForMediaPlayer(Entity ent)
            {
                AddEntity(ent, () => { return ent.State?.ToLower() == "playing"; }, CheckAllStates);
            
            }

            foreach(Entity e in mediaPlayerEntities)
            {
                SetEntityForMediaPlayer(e);
            }
        }

        private void AddEntity(Entity ent, Func<bool> isTrueMethod, Action onValueChanged)
        {
            IsTrueConditioner conditioner = new IsTrueConditioner(isTrueMethod, onValueChanged);
            ent.StateChanges().Subscribe(_ => conditioner.UpdateState());
            _monitoreres.Add(conditioner);

        }

        private void CheckAllStates()
        {
            bool somethinggPlaying = false;
            foreach(IsTrueConditioner monitor in _monitoreres)
            {

                if(monitor.currentState == true)
                {
                    somethinggPlaying = true;
                    break;
                }
            }

            Console.WriteLine("MediaPlaying: " + somethinggPlaying);

            if (somethinggPlaying) _myEntities.InputBoolean.MediaPlaying.TurnOn();
            else _myEntities.InputBoolean.MediaPlaying.TurnOff();



        }


        private class IsTrueConditioner
        {
            private Func<bool> isTrueMethod;
            private Action OnValueChanged;
            public bool currentState { get; private set; }

            public IsTrueConditioner(Func<bool> isTrueMethod, bool currentState, Action onValueChanged)
            {
                this.isTrueMethod = isTrueMethod;
                this.currentState = currentState;
                this.OnValueChanged = onValueChanged;
            }
            public IsTrueConditioner(Func<bool> isTrueMethod, Action onValueChanged)
            {
                this.isTrueMethod = isTrueMethod;
                this.OnValueChanged = onValueChanged;
                currentState = isTrueMethod != null ? isTrueMethod.Invoke() : true;
            }



            public void UpdateState()
            {
                bool tempstate = isTrueMethod != null ? isTrueMethod.Invoke() : true;
                if (tempstate != currentState)
                {
                    currentState = tempstate;
                    Console.WriteLine("Someting changed to: " + currentState);
                    OnValueChanged?.Invoke();
                }
            }

            public void ForceState(bool state)
            {
                if (state != currentState)
                {
                    currentState = state;
                    Console.WriteLine("Someting changed to: " + state);
                    OnValueChanged?.Invoke();
                }
                else
                    this.currentState = state;

            }



        }



    }
}
