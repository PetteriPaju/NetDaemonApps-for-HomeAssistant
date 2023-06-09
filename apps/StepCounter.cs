﻿using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System.Linq;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps
{

    [NetDaemonApp]
    public class StepCounter
    {
        protected readonly Entities _myEntities;
        private int lastKnownThreshold = 0;
        private int notificationThreashold = 1000;
        public StepCounter(IHaContext ha, IScheduler scheduler)
        {
            _myEntities = new Entities(ha);
            _myEntities.Sensor.MotoG8PowerLiteLastNotification?.StateAllChanges().Where(x => IsValidStep(x))?.Subscribe(x => ParseSteps(x?.Entity?.EntityState?.Attributes?.Android_title));

            scheduler.ScheduleCron("0 0 * * *", () => lastKnownThreshold = 0);
        }

        private void ParseSteps(string? message)
        {
            if (message == null) return;

            int steps;
            message = message.Substring(0, message.IndexOf("s"));
            string numericPhone = new String(message.Where(Char.IsDigit).ToArray());

            bool wasParsed = int.TryParse(numericPhone, out steps);
      
            if (wasParsed && steps>0)
            {

                var stepsFloored = FloorDownToThousand(steps);

                _myEntities.InputNumber.Dailysteps.SetValue(steps);

                if (stepsFloored < lastKnownThreshold)
                {
                    lastKnownThreshold = (int)stepsFloored;
                }

                if (stepsFloored >= FloorDownToThousand(lastKnownThreshold + notificationThreashold))
                {

                    lastKnownThreshold = (int)stepsFloored;
              
                    TTS.Speak("You have reached " + lastKnownThreshold.ToString() + "steps");
              

                }

               
            }
        }

        private double FloorDownToThousand(double input)
        {
            return Math.Floor((double)((input) / 1000))*1000;
        }

        

        private bool IsValidStep(StateChange<SensorEntity,EntityState<SensorAttributes>> ent)
        {
            if (ent == null) return false;
            if (ent?.New?.Attributes == null) return false;

            var package = ent.New.Attributes.Package;

            if (package == null) return false;
            if (!package.Contains("com.huawei.health")) return false;

            var steps = ent.New.Attributes.Android_title;

            if (steps == null) return false;

            return true;


        }

    }
}
