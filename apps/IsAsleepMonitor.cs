using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;
using System.Linq;
using NetDaemon.Extensions.Scheduler;
using System.Reactive.Concurrency;
using System.Globalization;
using System;
using System.Diagnostics;

namespace NetDaemonApps.apps
{
    /// <summary>
    /// Uses multiple conditions to determine whetever occupant is asleep and runs action accordingle.
    /// </summary>
    [NetDaemonApp]
    public class IsAsleepMonitor
    {
        private Dictionary<Entity, bool> isAsleepCondition = new Dictionary<Entity, bool>();

        private TimeSpan sleepTimer;

        private IDisposable? alarmTimer;

        public IsAsleepMonitor(IHaContext ha) {

            ParseAlertTime();
            _0Gbl._myEntities.InputDatetime.SettingsSleepduration.StateAllChanges().Subscribe(_=>ParseAlertTime());

            //DateTime d2 = DateTime.Parse(_00_Globals._myEntities.Sensor.EnvyLastactive.State ?? "", null, System.Globalization.DateTimeStyles.RoundtripKind);

            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x?.New?.State == "on").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Switch.PcPlug, false));
            _0Gbl._myEntities.Switch.PcPlug.StateChanges().Where(x => x?.New?.State == "off").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Switch.PcPlug, true));
           isAsleepCondition.Add(_0Gbl._myEntities.Switch.PcPlug, _0Gbl._myEntities.Switch.PcPlug.IsOff());

            _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(15), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.InputBoolean.MediaPlaying, true));
            _0Gbl._myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.InputBoolean.MediaPlaying, false));
            isAsleepCondition.Add(_0Gbl._myEntities.InputBoolean.MediaPlaying, _0Gbl._myEntities.InputBoolean.MediaPlaying.IsOff());

           _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.EnvyLastactive, true));
            _0Gbl._myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.EnvyLastactive, false));
            isAsleepCondition.Add(_0Gbl._myEntities.Sensor.EnvyLastactive, _0Gbl._myEntities.Sensor.EnvyLastactive.State == "unavailable");

            _0Gbl._myEntities.Sensor.PcLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.PcLastactive, true));
            _0Gbl._myEntities.Sensor.PcLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1), _0Gbl._myScheduler).Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.PcLastactive, false));
            isAsleepCondition.Add(_0Gbl._myEntities.Sensor.PcLastactive, _0Gbl._myEntities.Sensor.PcLastactive.State == "unavailable");

            _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Where(x => x?.New?.State == "off").Subscribe(_ => CheckCondition(_0Gbl._myEntities.InputBoolean.Ishome, false));
            _0Gbl._myEntities.InputBoolean.Ishome.StateChanges().Where(x => x?.New?.State == "on").Subscribe(_ => CheckCondition(_0Gbl._myEntities.InputBoolean.Ishome, true));
            isAsleepCondition.Add(_0Gbl._myEntities.InputBoolean.Ishome, _0Gbl._myEntities.InputBoolean.Ishome.IsOn());


            _0Gbl._myEntities.InputBoolean.Isasleep.StateChanges().WhenStateIsFor(x => x?.State == "on", sleepTimer, _0Gbl._myScheduler).Subscribe(x => {
                if (_0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
                var alarmnumber = 1;
                _0Gbl._myEntities.Script.Actiontodoatalarm.TurnOn();
                TTS.Speak("Good Morning, ", TTS.TTSPriority.IgnoreAll);
                alarmTimer = _0Gbl._myScheduler.RunEvery(TimeSpan.FromMinutes(20), DateTimeOffset.Now + TimeSpan.FromSeconds(3), () => {

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

        private void ParseAlertTime()
        {
            if (TimeSpan.TryParse(_0Gbl._myEntities.InputDatetime.SettingsSleepduration.State, out sleepTimer))
            {
                // Conversion succeeded
               
            }
            else
            {
                sleepTimer = TimeSpan.FromHours(8) + TimeSpan.FromMinutes(15);

            }
        }
        private void CheckCondition(Entity trueConditionEntity, bool newState)
        {
            if (!isAsleepCondition.ContainsKey(trueConditionEntity)) isAsleepCondition.Add(trueConditionEntity, newState);
            isAsleepCondition[trueConditionEntity] = newState;

            CheckAllIsSleepConditions();

        }

        private bool trainingLora()
        {
            return _0Gbl._myEntities.Automation.TurnOffPcWhenLoraTrainingDone.IsOn() && _0Gbl._myEntities.InputSelect.Atloraended.State == "Shutdown";
        }

        private void CheckAllIsSleepConditions()
        {

            bool areAllTrue = true;

            if (trainingLora()) isAsleepCondition[_0Gbl._myEntities.Switch.PcPlug] = true;

            foreach (bool cond in isAsleepCondition.Values)
            {
                if (!cond)
                {
                    areAllTrue = false;
                    break;
                };
            }

            // If all conditions are true or false, we might need to change isSleep-state

            bool stateOfIsasleep = _0Gbl._myEntities.InputBoolean.Isasleep.IsOn();

            if (stateOfIsasleep != areAllTrue)
            {
                if (areAllTrue) _0Gbl._myEntities.InputBoolean.Isasleep.TurnOn();
                else _0Gbl._myEntities.InputBoolean.Isasleep.TurnOff();
            }
        }


        }

    
}
