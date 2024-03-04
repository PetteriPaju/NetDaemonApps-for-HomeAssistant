using HomeAssistantGenerated;
using Microsoft.AspNetCore.Builder;
using NetDaemon.Extensions.Tts;
using NetDaemon.HassModel.Entities;
using System;
using System.Linq;
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
            isAsleepEntity = _0Gbl._myEntities.InputBoolean.Isasleep;
            this.tts = ttsService;
            Instance = this;
        }


        public static void Speak(string text, TTSPriority overrider = TTSPriority.Default, InputBooleanEntity? inputBoolean = null)
        {
            if (Instance != null)
            {
                if(inputBoolean == null || inputBoolean.IsOn())
                Instance.SpeakTTS(text, overrider);
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
           
            if (_0Gbl._myEntities.InputBoolean.HydrationCheckActive.IsOn())
            {
               if( paramsContain(TTSPriority.IgnoreDisabled)) return true;

                if (_0Gbl._myEntities.InputBoolean.Isasleep.IsOn() && paramsContain(TTSPriority.IgnoreSleep) && 
                   (_0Gbl._myEntities.InputBoolean.GuestMode.IsOff() || paramsContain(TTSPriority.PlayInGuestMode))) return true;

                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && (DateTime.Now.Hour < 7 || DateTime.Now.Hour == 23)) return false;

                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.PlayInGuestMode)) return true;
                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.DoNotPlayInGuestMode)) return false;

                if (_0Gbl._myEntities.InputBoolean.Isasleep.IsOn() && !paramsContain(TTSPriority.IgnoreSleep)) return false;


                return true;
            }

             return false;

        }

        public void SpeakTTS(string text, params TTSPriority[] overriders)
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
                tts.Speak("media_player.vlc_telnet", text, getTTSService());

               
            }
            else
            {
                Console.WriteLine("(TTS ignored) " + text);
            }
               
        }

       private string getTTSService()
        {
            return _0Gbl._myEntities.BinarySensor.FritzBox6660CableConnection.State == "on" ? "google_translate_say" : "piper";
        }

    }
}
