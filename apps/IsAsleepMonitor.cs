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

        private IDisposable? isAsleepOnTimer = null;
        private IDisposable? isAsleepOffTimer = null;
        private class MonitorMember
        {
            public bool currentState;
            private Func<bool> condition;
            public string name;
            public MonitorMember(Func<bool> condition, string debugName)
            {
                this.name = debugName;
                this.condition = condition;
                currentState = CheckState();
            }

            public bool CheckState()
            {

                bool oldState = currentState;
                currentState = condition.Invoke();
                return oldState != currentState;
            }
        }

        public IsAsleepMonitor(IHaContext ha) {

            ParseAlertTime();
            _0Gbl._myEntities.InputDatetime.SettingsSleepduration.StateAllChanges().Subscribe(_ => ParseAlertTime());

            //DateTime d2 = DateTime.Parse(_00_Globals._myEntities.Sensor.EnvyLastactive.State ?? "", null, System.Globalization.DateTimeStyles.RoundtripKind);
            {
                var condition = new MonitorMember(()=> { return (_0Gbl._myEntities.Switch.PcPlug.IsOn() && !(_0Gbl._myEntities.Automation.TurnOffPcWhenLoraTrainingDone.IsOn() &&( _0Gbl._myEntities.InputSelect.Atloraended.State == "Shutdown") || _0Gbl._myEntities.InputSelect.Atloraended.State == "Smart"));  }, "Pc Plug");
                isAwakeConditions.Add(condition);
            }
            {;
                var condition = new MonitorMember( _0Gbl._myEntities.InputBoolean.MediaPlaying.IsOn, "Media");
                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember( _0Gbl._myEntities.BinarySensor._192168022.IsOn , "Envy Active");
                isAwakeConditions.Add(condition);
            }

            {
                var condition = new MonitorMember(_0Gbl._myEntities.InputBoolean.Ishome.IsOff, "Is Home");
                isAwakeConditions.Add(condition);
            }
            {
                var condition = new MonitorMember(_0Gbl._myEntities.Light.Awakelights.IsOn, "Lights");
                isAwakeConditions.Add(condition);
            }


            CheckAllIsSleepConditions();

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

            _0Gbl._myScheduler.ScheduleCron("1-29,31-59 * * * *", RefreshAll);
            _0Gbl._myScheduler.ScheduleCron("0,30 * * * *", CheckAllIsSleepConditions);
        }


        private void RefreshAll()
        {
            bool wasThereChange = false;
            foreach (var cond in isAwakeConditions)
            {
                if (cond.CheckState())
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

            sleepTimer = TimeSpan.FromHours(_0Gbl._myEntities.InputDatetime.SettingsSleepduration.Attributes.Hour ?? 0) + TimeSpan.FromMinutes(_0Gbl._myEntities.InputDatetime.SettingsSleepduration.Attributes.Minute ?? 0) + TimeSpan.FromSeconds(_0Gbl._myEntities.InputDatetime.SettingsSleepduration.Attributes.Second ?? 0);
            Console.WriteLine(sleepTimer);

        }


        private bool trainingLora()
        {
            return _0Gbl._myEntities.Automation.TurnOffPcWhenLoraTrainingDone.IsOn() && (_0Gbl._myEntities.InputSelect.Atloraended.State == "Shutdown" || _0Gbl._myEntities.InputSelect.Atloraended.State == "Smart" ) ;
        }

        private void CheckAllIsSleepConditions()
        {
           
            bool isAnyTrue = false;

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

            if (isAnyTrue && _0Gbl._myEntities.InputBoolean.Isasleep.IsOn())
            {

                if (isAsleepOffTimer == null)
                {
                    isAsleepOffTimer = _0Gbl._myScheduler.Schedule(TimeSpan.FromMinutes(3), () =>
                    {

                        _0Gbl._myEntities.InputBoolean.Isasleep.TurnOff();
                        isAsleepOffTimer = null;
                    });
                }

            }
            else if (!isAnyTrue && _0Gbl._myEntities.InputBoolean.Isasleep.IsOff()) {

                if (isAsleepOnTimer == null)
                {
                    isAsleepOnTimer = _0Gbl._myScheduler.Schedule(TimeSpan.FromMinutes(3), () =>
                    {

                        _0Gbl._myEntities.InputBoolean.Isasleep.TurnOn();
                        isAsleepOnTimer = null;
                    });
                }
            }

            if (!isAnyTrue)
            {
                if(isAsleepOffTimer != null)
                {
                    isAsleepOffTimer.Dispose();
                    isAsleepOffTimer = null;
                }

            }
            else
            {
                if (isAsleepOnTimer != null)
                {
                    isAsleepOnTimer.Dispose();
                    isAsleepOnTimer = null;
                }
            }
          
            
        }


        }

    
}
