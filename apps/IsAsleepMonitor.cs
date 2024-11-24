﻿using HomeAssistantGenerated;
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
        private readonly TimeSpan toSleepSpareTime = TimeSpan.FromMinutes(10);
        private static IsAsleepMonitor instance;

        private IDisposable? alarmTimer;
        private IDisposable? alarmSubscription = null;
        private IDisposable? isAsleepOnTimer = null;
        private IDisposable? isAsleepOffTimer = null;

        private IDisposable? rebootTimer = null;
        private IDisposable? modentimer = null;

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

        public static void ToggleMode()
        {
            _0Gbl._myEntities.InputSelect.AlarmSleepMode.SelectNext();
            string nextmode;
            switch (_0Gbl._myEntities.InputSelect.AlarmSleepMode.State)
            {
                case "Normal":
                    nextmode = "Nap";
                        break;

                case "Nap":
                    nextmode = "Free";
                    break;

                case "Free":
                    nextmode = "Exact Time";
                    break;

                case "Exact Time":
                    nextmode = "Normal";
                    break;

                default:
                    nextmode = "Unkwon";
                    break;

            }
            TTS.Speak("Sleep Mode set to" +nextmode, TTS.TTSPriority.Default);
            instance.Resub();
       
        }
        public void Resub(bool reboot = false)
        {

            alarmSubscription?.Dispose();
            modentimer?.Dispose();

            modentimer = _0Gbl._myScheduler.Schedule(reboot ? _0Gbl._myEntities.InputDatetime.AlarmTargetTime.GetDateTime()-TimeSpan.FromMinutes(45) : DetermineAlarmTagetTime() - TimeSpan.FromMinutes(45), x =>
            {
                if (_0Gbl._myEntities.InputBoolean.NotificationAlarm.IsOff()) return;
                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
                if (_0Gbl._myEntities.InputBoolean.Isasleep.IsOff()) return;
                if (_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn()) return;

                _0Gbl._myEntities.Switch.ModemAutoOnPlug.TurnOn();

            });

                alarmSubscription = _0Gbl._myScheduler.Schedule(reboot ? _0Gbl._myEntities.InputDatetime.AlarmTargetTime.GetDateTime() : DetermineAlarmTagetTime(), x => {
                    if (_0Gbl._myEntities.InputBoolean.NotificationAlarm.IsOff()) return;
                    if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
                    if (_0Gbl._myEntities.InputBoolean.Isasleep.IsOff()) return;
                    var alarmnumber = 1;
                    TTS.Speak("Good Morning, ", TTS.TTSPriority.IgnoreAll, null, (MediaPlayerEntity e) => { _0Gbl._myEntities.Script.Actiontodoatalarm.TurnOn(); } );
                alarmTimer = _0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(10), DateTimeOffset.Now + TimeSpan.FromSeconds(3), () => {

                    TimeSpan? timeDiff = DateTime.Now - _0Gbl._myEntities?.InputDatetime.Lastisasleeptime.GetDateTime();
                    string ttsTime = "its " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture) + ", you have been sleeping for " + timeDiff?.Hours + " hours" + (timeDiff?.Minutes > 0 ? " and " + timeDiff?.Minutes + "minutes" : ". ");

                    ttsTime += "This is alarm number " + alarmnumber + ".";

                    TTS.Speak(ttsTime, TTS.TTSPriority.IgnoreAll, null, (MediaPlayerEntity med) => { _0Gbl._myServices.Script.Playmoomin(); });
                    alarmnumber++;
                });
                rebootTimer?.Dispose();
            });



        }

        private DateTimeOffset DetermineAlarmTagetTime()
        {
    
            DateTimeOffset dto;
         
            switch (_0Gbl._myEntities.InputSelect.AlarmSleepMode.State)
            {
                case "Normal":
                    dto =  DateTime.Now + new TimeSpan((int)_0Gbl._myEntities.InputDatetime.AlarmSleepDuration.Attributes.Hour, (int)_0Gbl._myEntities.InputDatetime.AlarmSleepDuration.Attributes.Minute, 0);
             break;

                case "Nap":
                    dto = DateTime.Now + new TimeSpan((int)_0Gbl._myEntities.InputDatetime.AlarmNapDuration.Attributes.Hour, (int)_0Gbl._myEntities.InputDatetime.AlarmNapDuration.Attributes.Minute, 0);
                    break;

                case "Free":
                    dto = DateTime.Now + TimeSpan.FromDays(1);
                    break;

                case "Exact Time":
                    DateTime day = DateTime.Now.Hour<=(int)_0Gbl._myEntities.InputDatetime.Alarmtime.Attributes.Hour ?  DateTime.Today : DateTime.Today+TimeSpan.FromDays(1);
                    dto = new DateTime(day.Year,day.Month, day.Day, (int)_0Gbl._myEntities.InputDatetime.Alarmtime.Attributes.Hour, (int)_0Gbl._myEntities.InputDatetime.Alarmtime.Attributes.Minute, 0);
                    break;

                default:
                    dto = new DateTimeOffset(_0Gbl._myEntities.InputDatetime.AlarmTargetTime.GetDateTime());
                    break;

            }
          
            // Get the unix timestamp in seconds
            long unixTime = dto.ToUnixTimeSeconds();


            _0Gbl._myEntities.InputDatetime.AlarmTargetTime.SetDatetime(timestamp: unixTime);
            Console.WriteLine("Alarm: " + _0Gbl._myEntities.InputDatetime.AlarmTargetTime.GetDateTime());

            return dto;

        }

        public IsAsleepMonitor(IHaContext ha) {

          
            instance = this;
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

            Resub(true);

            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x?.New?.State == "off" && x?.Old.State == "on").Subscribe(x => {

                if(_0Gbl._myEntities.InputSelect.AlarmSleepMode.State == "Nap" || _0Gbl._myEntities.InputSelect.AlarmSleepMode.State == "Free")
                _0Gbl._myEntities.InputSelect.AlarmSleepMode.SelectOption("Normal");

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

                rebootTimer?.Dispose();
                _0Gbl._myEntities.InputDatetime.Awoketime.SetDatetime(timestamp: unixTime);
            });

            _0Gbl._myEntities.InputSelect.AlarmSleepMode.StateChanges().Where(x => (x?.Old.State != "unavailable" && x?.Old.State != "unknown")).Subscribe(x => {

                Resub();

            });


            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().WhenStateIsFor(x => x.IsOn() ,TimeSpan.FromHours(3), _0Gbl._myScheduler).Subscribe(x => {

                rebootTimer?.Dispose();

                rebootTimer = _0Gbl._myScheduler.ScheduleCron("10 * * * *", () =>
                {
                    _0Gbl._myEntities.Button.NodePveReboot.Press();  
                    rebootTimer?.Dispose();
                });

            });
                
            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x?.New?.State == "on" && x?.Old.State == "off").Subscribe(x => {
                Resub();
                _0Gbl._myEntities.InputDatetime.Lastisasleeptime.SetDatetime(timestamp: new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds());
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
                    isAsleepOffTimer = _0Gbl._myScheduler.Schedule(TimeSpan.FromMinutes(10), () =>
                    {

                        _0Gbl._myEntities.InputBoolean.Isasleep.TurnOff();
                        isAsleepOffTimer = null;
                    });
                }

            }
            else if (!isAnyTrue && _0Gbl._myEntities.InputBoolean.Isasleep.IsOff()) {

                if (isAsleepOnTimer == null)
                {
                    isAsleepOnTimer = _0Gbl._myScheduler.Schedule(toSleepSpareTime, () =>
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
