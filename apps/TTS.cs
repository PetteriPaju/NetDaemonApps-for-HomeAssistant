using HomeAssistantGenerated;
using NetDaemon.Extensions.Tts;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static TTS _instance;
        private readonly ITextToSpeechService tts;
        private readonly Entities _myEntities;
        private readonly InputBooleanEntity isAsleepEntity;
        public TTS(IHaContext ha, ITextToSpeechService ttsService) {

            _myEntities = new Entities(ha);
            isAsleepEntity = _myEntities.InputBoolean.Isasleep;
            this.tts = ttsService;
            _instance = this;


        
        }


        public void Speak(string text, TTSPriority overrider = TTSPriority.Default)
        {

            if(((isAsleepEntity.IsOff() || overrider == TTSPriority.IgnoreSleep)  && (_myEntities.InputBoolean.HydrationCheckActive.IsOn() || overrider == TTSPriority.IgnoreDisabled)) || overrider == TTSPriority.IgnoreAll)
            tts.Speak("media_player.living_room_display", text, "google_translate_say");

        }

    }
}
