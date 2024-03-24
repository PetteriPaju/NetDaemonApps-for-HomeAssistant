using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;
using System.Linq;
using NetDaemon.Extensions.Scheduler;
using System.Reactive.Concurrency;
using System.Globalization;
using System;
using System.Diagnostics;
using NetDaemon.HassModel;
using System.Reactive.Linq;

namespace NetDaemonApps.apps
{
    /// <summary>
    /// Uses multiple conditions to determine whetever occupant is asleep and runs action accordingle.
    /// </summary>
    [NetDaemonApp]
    public class IsAsleepMonitor
    {
        private List<MonitorMember> isAwakeConditions = new List<MonitorMember>();
        private MonitorMember loraTrainingHelper;
        private TimeSpan sleepTimer;

        private IDisposable? alarmTimer;

        private class MonitorMember {
            public bool currentState;
            public bool overrideByNoInternet;
            public string name;
            public MonitorMember(bool value, string debugName, bool overrideByNoInternet = false )
            {
                this.overrideByNoInternet = overrideByNoInternet;
                this.name = debugName;
                this.currentState = value;
            }  
            
            public bool SetState(bool state)
            {
                bool oldState = currentState;
                currentState = state;
              //  if (currentState && !_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() && overrideByNoInternet) currentState = false;

                return oldState != currentState;
            }


        }

        private void SetConditiotnState(MonitorMember member, bool state)
        {
            if (member.SetState(state))
            {
                Console.WriteLine(member.name + "changed to: " + state);
                CheckAllIsSleepConditions();
            }
        }

        public IsAsleepMonitor(IHaContext ha) {

            ParseAlertTime();
            _0Gbl._myEntities.InputDatetime.SettingsSleepduration.StateAllChanges().Subscribe(_ => ParseAlertTime());

            //DateTime d2 = DateTime.Parse(_00_Globals._myEntities.Sensor.EnvyLastactive.State ?? "", null, System.Globalization.DateTimeStyles.RoundtripKind);
            {
                var condition = new MonitorMember(_0Gbl._myEntities.Switch.PcPlug.IsOn(), "Pc Plug");
                _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New.IsOn()).Subscribe(_ => SetConditiotnState(condition, true));
                _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => SetConditiotnState(condition, false));

                loraTrainingHelper = condition;
                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember(_0Gbl._myEntities.InputBoolean.MediaPlaying.IsOn(), "Media", true);
                _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(15), _0Gbl._myScheduler).Subscribe(_ => { SetConditiotnState(condition, false); });
                _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => { SetConditiotnState(condition, true); });
                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember(_0Gbl._myEntities.Sensor.EnvyLastactive.State != "unavailable", "Envy Active", true);
                _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5), _0Gbl._myScheduler).Subscribe(_ => { SetConditiotnState(condition, false); });
                _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => { SetConditiotnState(condition, true); });
                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember(_0Gbl._myEntities.InputBoolean.Ishome.State == "off", "Is Home");
                _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => { SetConditiotnState(condition, true); });
                _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Where(x => x.New.IsOn()).Subscribe(_ => { SetConditiotnState(condition, false); });

                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember(_0Gbl._myEntities.Light.Awakelights.IsOn(), "Lights");
                _0Gbl._myEntities.Light.Awakelights.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => SetConditiotnState(condition, false));
                _0Gbl._myEntities.Light.Awakelights.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(20), _0Gbl._myScheduler).Subscribe(_ => SetConditiotnState(condition, true));
                isAwakeConditions.Add(condition);
            }
            CheckAllIsSleepConditions();

            _0Gbl._myEntities.Switch.ModemAutoOnPlug.StateChanges().WhenStateIsFor(x=>x.State != "on", TimeSpan.FromMinutes(5)).Subscribe(_ => RefreshAll());


            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().WhenStateIsFor(x => x?.State == "on", sleepTimer, _0Gbl._myScheduler).Subscribe(x => {
                if (_0Gbl._myEntities.InputBoolean.NotificationAlarm.IsOff()) return;
                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
                var alarmnumber = 1;
                _0Gbl._myEntities.Script.Actiontodoatalarm.TurnOn();
                TTS.Speak("Good Morning, ", TTS.TTSPriority.IgnoreAll);
                alarmTimer = _0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(10), DateTimeOffset.Now + TimeSpan.FromSeconds(3), () => {

                    TimeSpan? timeDiff = DateTime.Now - _0Gbl._myEntities?.InputBoolean?.Isasleep?.EntityState?.LastChanged;
                    string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture) + ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ?  " and " + timeDiff?.Minutes + "minutes" : ". ");

                    ttsTime += "This is alarm number " + alarmnumber + ".";

                    TTS.Speak(ttsTime, TTS.TTSPriority.IgnoreAll);
                    alarmnumber++;
                });

            });

            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x?.New?.State == "off").Subscribe(x => {
                // If alarm timer is on it means that this is after a long sleep
                if (alarmTimer != null)
                {
                    alarmTimer.Dispose();
                   
                    EnergyMonitor.ReadOutGoodMorning();
                }
                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;

                //Run default actions that run everytime isSleep is turned on
                // Get the offset from current time in UTC time
                DateTimeOffset dto = new DateTimeOffset(DateTime.Now);
                // Get the unix timestamp in seconds
                long unixTime = dto.ToUnixTimeSeconds();


                _0Gbl._myEntities.InputDatetime.Awoketime.SetDatetime(timestamp: unixTime);


            });

            CheckAllIsSleepConditions();

        }
        private void RefreshAll()
        {
            bool wasThereChange = false;
            foreach (var cond in isAwakeConditions)
            {
                if (cond.SetState(cond.currentState))
                {
                    wasThereChange = true;
          
                }
            }
            if (wasThereChange)
            {
                CheckAllIsSleepConditions();
            }
        }


            private void ParseAlertTime()
        {
            if (TimeSpan.TryParse(_0Gbl._myEntities.InputDatetime.SettingsSleepduration.State, out sleepTimer))
            {
                // Conversion succeeded
               
            }
            else
            {
                sleepTimer = TimeSpan.FromHours(9);

            }
        }


        private bool trainingLora()
        {
            return _0Gbl._myEntities.Automation.TurnOffPcWhenLoraTrainingDone.IsOn() && _0Gbl._myEntities.InputSelect.Atloraended.State == "Shutdown";
        }

        private void CheckAllIsSleepConditions()
        {

            bool isAnyTrue = false;

            if (trainingLora()) { 
                loraTrainingHelper.currentState = false;
            }

            foreach (MonitorMember cond in isAwakeConditions)
            {
                if (cond.currentState)
                {
                    isAnyTrue = true;
                    Console.WriteLine(cond.name + " is true");
                   
                };
            }

            Console.WriteLine("States are: " + isAnyTrue + ": " + DateTime.Now.ToShortTimeString());
            // If all conditions are true or false, we might need to change isSleep-state

                if (isAnyTrue && _0Gbl._myEntities.InputBoolean.Isasleep.IsOn()) _0Gbl._myEntities.InputBoolean.Isasleep.TurnOff();
                else if (!isAnyTrue && _0Gbl._myEntities.InputBoolean.Isasleep.IsOff()) _0Gbl._myEntities.InputBoolean.Isasleep.TurnOn();
            
        }


        }

    
}
