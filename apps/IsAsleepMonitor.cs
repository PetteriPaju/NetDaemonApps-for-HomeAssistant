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
            private Func<bool> isAwake;
            public MonitorMember(Func<bool> checkFunction, bool overrideByNoInternet = false )
            {
                this.overrideByNoInternet = overrideByNoInternet;
                this.isAwake = checkFunction;
                HasStatusChanged();
            }  
            
            public bool HasStatusChanged()
            {
                Console.WriteLine("Condition Check: " + isAwake());
                bool oldState = currentState;
                currentState = isAwake();
                if (currentState && !_0Gbl._myEntities.Switch.ModemAutoOnPlug.IsOn() && overrideByNoInternet) currentState = false;

                return oldState != currentState;
            }


        }

        private void CheckStatus(MonitorMember m)
        {
            if (m.HasStatusChanged())
            {
                Console.WriteLine("Condition Changed!");
                CheckAllIsSleepConditions();
            }
        }
        public IsAsleepMonitor(IHaContext ha) {

            ParseAlertTime();
            _0Gbl._myEntities.InputDatetime.SettingsSleepduration.StateAllChanges().Subscribe(_ => ParseAlertTime());

            //DateTime d2 = DateTime.Parse(_00_Globals._myEntities.Sensor.EnvyLastactive.State ?? "", null, System.Globalization.DateTimeStyles.RoundtripKind);
            MonitorMember condition = new MonitorMember(bool () => { return _0Gbl._myEntities.Switch.PcPlug.IsOn(); });
            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Subscribe(_ => condition.HasStatusChanged());
            loraTrainingHelper = condition;
            isAwakeConditions.Add(condition);

            condition = new MonitorMember(bool () => { return _0Gbl._myEntities.InputBoolean.MediaPlaying.IsOn(); }, true);
            _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(15), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            isAwakeConditions.Add(condition);

            condition = new MonitorMember(bool () =>{ return _0Gbl._myEntities.Sensor.EnvyLastactive.State != "unavailable"; }, true);
            _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            isAwakeConditions.Add(condition);

            condition = new MonitorMember(bool () => { return _0Gbl._myEntities.Sensor.PcLastactive.State != "unavailable"; }, true);
            _0Gbl._myEntities.Sensor.PcLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            _0Gbl._myEntities.Sensor.PcLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            isAwakeConditions.Add(condition);

            condition = new MonitorMember(bool () => { return _0Gbl._myEntities.InputBoolean.Ishome.IsOff(); });
            _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Subscribe(_ => { CheckStatus(condition); });
            isAwakeConditions.Add(condition);

            condition = new MonitorMember(bool () => { return _0Gbl._myEntities.Light.Awakelights.IsOn(); });
            _0Gbl._myEntities.Light.Awakelights.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(1),_0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            _0Gbl._myEntities.Light.Awakelights.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(20), _0Gbl._myScheduler).Subscribe(_ => CheckStatus(condition));
            isAwakeConditions.Add(condition);

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
                if (cond.HasStatusChanged())
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

            if (trainingLora()) loraTrainingHelper.currentState = false;

            foreach (MonitorMember cond in isAwakeConditions)
            {
                if (cond.currentState)
                {
                    isAnyTrue = true;
                    break;
                };
            }


            // If all conditions are true or false, we might need to change isSleep-state

            bool stateOfIsasleep = _0Gbl._myEntities.InputBoolean.Isasleep.IsOn();

            if (stateOfIsasleep != isAnyTrue)
            {
                if (isAnyTrue) _0Gbl._myEntities.InputBoolean.Isasleep.TurnOff();
                else _0Gbl._myEntities.InputBoolean.Isasleep.TurnOn();
            }
        }


        }

    
}
