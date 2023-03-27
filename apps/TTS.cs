using HomeAssistantGenerated;
using NetDaemon.Extensions.Tts;
using NetDaemon.HassModel.Entities;


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

        public static TTS? Instance { get => instance; set => instance = value; }

        public TTS(IHaContext ha, ITextToSpeechService ttsService) {

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
                Console.WriteLine("(TTS) " +text);
            }
            

        }

        public void SpeakTTS(string text, TTSPriority overrider = TTSPriority.Default)
        {
            if (((isAsleepEntity.IsOff() || overrider == TTSPriority.IgnoreSleep) && (_myEntities.InputBoolean.HydrationCheckActive.IsOn() || overrider == TTSPriority.IgnoreDisabled)) || overrider == TTSPriority.IgnoreAll)
                tts.Speak("media_player.living_room_display", text, "google_translate_say");
        }

    }
}
