using HomeAssistantGenerated;
using Microsoft.AspNetCore.Mvc.Formatters;
using NetDaemon.Extensions.Scheduler;
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
            _myEntities.Sensor.MotoG8PowerLiteLastNotification.StateAllChanges().Where(x => (bool)x?.Entity?.EntityState?.Attributes?.Package?.Contains("com.huawei.health") && (bool)x?.Entity?.EntityState?.Attributes?.Android_title?.Contains("steps")).Subscribe(x => ParseSteps(x.Entity.EntityState?.Attributes?.Android_title ?? null));

            scheduler.ScheduleCron("0 0 * * *", () => lastKnownThreshold = 0);
        }

        private void ParseSteps(string message)
        {
            if (message == null) return;
            int steps;

            Console.WriteLine("Step Message");

            string numericPhone = new String(message.Where(Char.IsDigit).ToArray());

            bool wasParsed = int.TryParse(numericPhone, out steps);

            if (wasParsed)
            {
                Console.WriteLine("Parsed Step:" + steps);
                _myEntities.InputNumber.Dailysteps.SetValue(steps);


                int modulus;

                if (Math.Floor((double)(steps / 1000)) > Math.Floor( (double)(lastKnownThreshold + notificationThreashold)/1000))
                {

                    lastKnownThreshold = (int)Math.Floor((double)(steps / 1000)) * 1000;
                    Console.WriteLine("Threshold Reached");
                    TTS._instance.Speak("You have reached " + lastKnownThreshold.ToString() + "steps");
              

                }

               
            }




        }

    }
}
