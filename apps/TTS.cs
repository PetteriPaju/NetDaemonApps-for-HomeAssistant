using HomeAssistantGenerated;
using NetDaemon.Extensions.Tts;
using NetDaemon.HassModel.Entities;
using System;
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
            IgnoreDisabled,
            IgnoreAll

        }

        private static TTS? instance;
        protected readonly ITextToSpeechService tts;
        protected readonly Entities _myEntities;
        protected readonly InputBooleanEntity isAsleepEntity;
        protected DateTime lastAnnounsmentTime = DateTime.MinValue;
        protected TimeSpan timeBetweenAnnounsments = TimeSpan.FromSeconds(15);
 

        public static TTS? Instance { get => instance; set => instance = value; }

        public TTS(IHaContext ha, ITextToSpeechService ttsService) {

            lastAnnounsmentTime = DateTime.MinValue;
            _myEntities = new Entities(ha);
            isAsleepEntity = _myEntities.InputBoolean.Isasleep;
            this.tts = ttsService;
            Instance = this;
        }


        public static void Speak(string text, TTSPriority overrider = TTSPriority.Default)
        {
            if (Instance != null)
            {
                Instance.SpeakTTS(text, overrider);
            }
            else
            {
                Console.WriteLine("(TTS unavailable) " +text);
            }
            

        }

        public void SpeakTTS(string text, TTSPriority overrider = TTSPriority.Default)
        {
            if (((isAsleepEntity.IsOff() || overrider == TTSPriority.IgnoreSleep) && (_myEntities.InputBoolean.HydrationCheckActive.IsOn() || overrider == TTSPriority.IgnoreDisabled)) || overrider == TTSPriority.IgnoreAll)
            {
               /*
                if (lastAnnounsmentTime + timeBetweenAnnounsments > DateTime.Now)
                {
                    _myEntities.MediaPlayer.VlcTelnet.PlayMedia("media-source://media_source/local/tos_shipannouncement.mp3", "audio/mpeg");
                    await Task.Delay(1000);

                }
               */
                lastAnnounsmentTime = DateTime.Now;
                tts.Speak("media_player.vlc_telnet", text, "google_translate_say");

               
            }
            else
            {
                Console.WriteLine("(TTS ignored) " + text);
            }
               
        }

    }
}
