using HomeAssistantGenerated;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reactive.Concurrency;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            _myEntities.Sensor.MotoG8PowerLiteLastNotification?.StateAllChanges().Where(x => IsValidStep(x))?.Subscribe(x => ParseSteps(x?.Entity?.EntityState?.Attributes?.Android_text));

            scheduler.ScheduleCron("0 0 * * *", () => lastKnownThreshold = 0);
        }

        private void ParseSteps(string? message)
        {
            if (message == null) return;

            int steps;

            string numericPhone = new String(message.Where(Char.IsDigit).ToArray());

            bool wasParsed = int.TryParse(numericPhone, out steps);
            steps = 10000 - steps;
            if (wasParsed && steps>0)
            {
                Console.WriteLine("Parsed Step:" + steps);
                Console.WriteLine("Next threshold:" + Math.Floor((double)((lastKnownThreshold + notificationThreashold) / 1000)));
                _myEntities.InputNumber.Dailysteps.SetValue(steps);

                if (Math.Floor((double)(steps / 1000)) >= Math.Floor( (double)((lastKnownThreshold + notificationThreashold)/1000)))
                {

                    lastKnownThreshold = ((int)Math.Floor((double)(steps / 1000))) * 1000;
                    Console.WriteLine("Threshold Reached");
                    TTS.Speak("You have reached " + lastKnownThreshold.ToString() + "steps");
              

                }

               
            }
        }

        private bool IsValidStep(StateChange<SensorEntity,EntityState<SensorAttributes>> ent)
        {
            if (ent == null) return false;
            if (ent?.New?.Attributes == null) return false;

            var package = ent.New.Attributes.Package;

            if (package == null) return false;
            if (!package.Contains("com.huawei.health")) return false;

            var steps = ent.New.Attributes.Android_text;

            if (steps == null) return false;

            return true;


        }

    }
}
