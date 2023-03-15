using HomeAssistantGenerated;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NetDaemon.Extensions.Scheduler;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Globalization;


namespace NetDaemonApps.apps
{
/// <summary>
/// Uses multiple conditions to determine whetever occupant is asleep and runs action accordingle.
/// </summary>
    [NetDaemonApp]
    public class IsAsleepMonitor
    {
        private Entities _myEntities;
        private Dictionary<Entity, bool> isAsleepCondition = new Dictionary<Entity, bool>();

        private TimeSpan sleepTimer =  TimeSpan.FromHours(7)+TimeSpan.FromMinutes(30);

        private bool isLongSleeping = false;

        private IDisposable? alarmTimer;

        public IsAsleepMonitor(IHaContext ha, IScheduler scheduler) {
            _myEntities = new Entities(ha);



            _myEntities.Switch.PcPlug.StateChanges().Where(x => x?.New?.State == "on").Subscribe(_ => CheckCondition(_myEntities.Switch.PcPlug, false));
            _myEntities.Switch.PcPlug.StateChanges().Where(x => x?.New?.State == "off").Subscribe(_ => CheckCondition(_myEntities.Switch.PcPlug, true));
           isAsleepCondition.Add(_myEntities.Switch.PcPlug, _myEntities.Switch.PcPlug.IsOff());

            _myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "off", TimeSpan.FromMinutes(15)).Subscribe(_ => CheckCondition(_myEntities.InputBoolean.MediaPlaying, true));
            _myEntities.InputBoolean.MediaPlaying.StateChanges().WhenStateIsFor(x => x?.State == "on", TimeSpan.FromMinutes(1)).Subscribe(_ => CheckCondition(_myEntities.InputBoolean.MediaPlaying, false));
            isAsleepCondition.Add(_myEntities.InputBoolean.MediaPlaying, _myEntities.InputBoolean.MediaPlaying.IsOff());

           _myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State == "unavailable", TimeSpan.FromMinutes(5)).Subscribe(_ => CheckCondition(_myEntities.Sensor.EnvyLastactive, true));
            _myEntities.Sensor.EnvyLastactive.StateChanges().WhenStateIsFor(x => x?.State != "unavailable", TimeSpan.FromMinutes(1)).Subscribe(_ => CheckCondition(_myEntities.Sensor.EnvyLastactive, false));
            isAsleepCondition.Add(_myEntities.Sensor.EnvyLastactive, _myEntities.Sensor.EnvyLastactive.State == "unavailable");


            _myEntities.InputBoolean.Ishome.StateChanges().Where(x => x?.New?.State == "off").Subscribe(_ => CheckCondition(_myEntities.InputBoolean.Ishome, false));
            _myEntities.InputBoolean.Ishome.StateChanges().Where(x => x?.New?.State == "on").Subscribe(_ => CheckCondition(_myEntities.InputBoolean.Ishome, true));
            isAsleepCondition.Add(_myEntities.InputBoolean.Ishome, _myEntities.InputBoolean.Ishome.IsOn());



            _myEntities.InputBoolean.Isasleep.StateChanges().WhenStateIsFor(x => x?.State == "on", sleepTimer).Subscribe(x => {
                Console.WriteLine("Asleep timer reached, begin repeat");

                alarmTimer = scheduler.RunEvery(TimeSpan.FromMinutes(20), DateTimeOffset.Now, () => {

                    TimeSpan? timeDiff = DateTime.Now - _myEntities?.InputBoolean?.Isasleep?.EntityState?.LastChanged;
                    string ttsTime = "Its: " + DateTime.Now.ToString("H:mm", CultureInfo.InvariantCulture) + ", you have been sleeping for " + timeDiff?.Hours + " hours and " + timeDiff?.Minutes + "minutes";
      
                    TTS._instance?.Speak(ttsTime, true);

                });

            });

            _myEntities.InputBoolean.Isasleep.StateChanges().Where(x => x?.New?.State == "off").Subscribe(x => {
                Console.WriteLine("Woke up");
                // If alarm timer is on it means that this is after a long sleep
                if (alarmTimer != null)
                {
                    alarmTimer.Dispose();
                    Console.WriteLine("DisposeTimer");
                }


                //Run default actions that run everytime isSleep is turned on

            });

            CheckAllIsSleepConditions();

        }


        private void CheckCondition(Entity trueConditionEntity, bool newState)
        {
            if (!isAsleepCondition.ContainsKey(trueConditionEntity)) isAsleepCondition.Add(trueConditionEntity, newState);
            isAsleepCondition[trueConditionEntity] = newState;

            CheckAllIsSleepConditions();



        }

        private void CheckAllIsSleepConditions()
        {

            bool areAllTrue = true;
            foreach (bool cond in isAsleepCondition.Values)
            {
                if (!cond)
                {
                    areAllTrue = false;
                    break;
                };
            }

            // If all conditions are true or false, we might need to change isSleep-state

            bool stateOfIsasleep = _myEntities.InputBoolean.Isasleep.IsOn();

            if (stateOfIsasleep != areAllTrue)
            {
                if (areAllTrue) _myEntities.InputBoolean.Isasleep.TurnOn();
                else _myEntities.InputBoolean.Isasleep.TurnOff();
            }
        }


        }

    
}
