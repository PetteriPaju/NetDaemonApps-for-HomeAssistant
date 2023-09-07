﻿using HomeAssistantGenerated;
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

        bool allowTTS(TTSPriority[] overriders)
        {
   
            bool paramsContain(TTSPriority target)
            {
                return overriders.Contains(target);
            }

            if (overriders.Length == 0) return true;
            if (paramsContain(TTSPriority.IgnoreAll)) return true;
           
            if (_myEntities.InputBoolean.HydrationCheckActive.IsOn())
            {
               if( paramsContain(TTSPriority.IgnoreDisabled)) return true;

                if (_myEntities.InputBoolean.Isasleep.IsOn() && paramsContain(TTSPriority.IgnoreSleep) && 
                   (_myEntities.InputBoolean.GuestMode.IsOff() || paramsContain(TTSPriority.PlayInGuestMode))) return true;

                if (_myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.PlayInGuestMode)) return true;
                if (_myEntities.InputBoolean.GuestMode.IsOn() && paramsContain(TTSPriority.DoNotPlayInGuestMode)) return false;


                return true;
            }

             return true;

        }

        public void SpeakTTS(string text, params TTSPriority[] overriders)
        {
           
           
            bool paramsContain(TTSPriority target)
            {
                return overriders.Contains(target);
            }


            if (allowTTS(overriders))
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
