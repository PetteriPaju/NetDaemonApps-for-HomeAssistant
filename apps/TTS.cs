using HomeAssistantGenerated;
using Microsoft.AspNetCore.Builder;
using NetDaemon.Extensions.Tts;
using NetDaemon.HassModel.Entities;
using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class TTS
    {
        public enum TTSPriority
        {
            Default,
            IgnoreSleep,
            PlayInGuestMode,
            DoNotPlayInGuestMode,
            IgnoreDisabled,
            IgnoreAll

        }

        private static TTS? instance;
        protected readonly ITextToSpeechService tts;
        protected readonly InputBooleanEntity isAsleepEntity;
        protected DateTime lastAnnounsmentTime = DateTime.MinValue;
        protected TimeSpan timeBetweenAnnounsments = TimeSpan.FromSeconds(15);
 

        public static TTS? Instance { get => instance; set => instance = value; }

        public TTS(ITextToSpeechService ttsService) {

            lastAnnounsmentTime = DateTime.MinValue;
            isAsleepEntity = A0Gbl._myEntities.InputBoolean.Isasleep;
            this.tts = ttsService;
            Instance = this;
        }



        public static void Speak(string text, TTSPriority overrider = TTSPriority.Default, InputBooleanEntity? inputBoolean = null, Action callback = null)
        {
            if (Instance != null)
            {
                if(inputBoolean == null || inputBoolean.IsOn())
                {
                    Instance.SpeakTTS(text, callback, overrider);

                    if (callback != null)
                    {

                    }
                }
                
                else Console.WriteLine("(Notification Disabled) " + text);

            }
            else
            {
                Console.WriteLine("(TTS unavailable) " +text);
            }
            

        }

        bool allowTTS(TTSPriority[] overriders)
        {
   
            bool paramsContain(TTSPriority target)
            {
                return overriders.Contains(target);
            }

            if (overriders.Length == 0) return true;
            if (paramsContain(TTSPriority.IgnoreAll)) return true;
           
            if (A0Gbl._myEntities.InputBoolean.HydrationCheckActive.IsOn())
            {
               if( paramsContain(TTSPriority.IgnoreDisabled)) return true;

                if (A0Gbl._myEntities.InputBoolean.Isasleep.IsOn() && paramsContain(TTSPriority.IgnoreSleep) && 
                   (A0Gbl._myEntities.InputBoolean.GuestMode.IsOff() || paramsContain(TTSPriority.PlayInGuestMode))) return true;

                if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && (DateTime.Now.Hour < 7 || DateTime.Now.Hour == 23)) return false;

                if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.PlayInGuestMode)) return true;
                if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.DoNotPlayInGuestMode)) return false;

                if (A0Gbl._myEntities.InputBoolean.Isasleep.IsOn() && !paramsContain(TTSPriority.IgnoreSleep)) return false;


                return true;
            }

             return false;

        }

        public void SpeakTTS(string text,Action callback = null, params TTSPriority[] overriders)
        {

            if (allowTTS(overriders))
            {
               /*
                if (lastAnnounsmentTime + timeBetweenAnnounsments > DateTime.Now)
                {
                    _00_Globals._myEntities.MediaPlayer.VlcTelnet.PlayMedia("media-source://media_source/local/tos_shipannouncement.mp3", "audio/mpeg");
                    await Task.Delay(1000);

                }
               */

                lastAnnounsmentTime = DateTime.Now;
                A0Gbl._myEntities.Script.Clearplaylists.TurnOn();
                tts.Speak(A0Gbl._myEntities.Sensor.PreferredMediaplayer.State ?? "media_player.vlc_telnet", text, getTTSService());

                A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(1),() => {
                    IDisposable disp = null;

                    MediaPlayerEntity ent = new MediaPlayerEntity(A0Gbl.HaContext, A0Gbl._myEntities.Sensor.PreferredMediaplayer.State ?? "media_player.vlc_telnet");
                   disp = ent.StateChanges().Where(x => x.New?.State != "playing").Subscribe(x => {

                        callback?.Invoke();
                        
                       disp?.Dispose();
                    });
                    A0Gbl._myScheduler.Schedule(TimeSpan.FromSeconds(30), () => { disp?.Dispose(); });
                });
               
                }
            else
            {
                callback?.Invoke();
                Console.WriteLine("(TTS ignored) " + text);
            }
               
        }

       private string getTTSService()
        {
            return A0Gbl._myEntities.BinarySensor.FritzBox6660CableConnection.State == "on" ? "google_translate_say" : "picotts_say";
        }

    }
}
