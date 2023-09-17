using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System.Linq;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps
{

    [NetDaemonApp]
    public class StepCounter
    {
        private int lastKnownThreshold = 0;
        private int notificationThreashold = 1000;
        public StepCounter()
        {

            _0Gbl._myEntities.Sensor.MotoG8PowerLiteLastNotification?.StateAllChanges().Where(x => IsValidStep(x))?.Subscribe(x => ParseSteps(x?.Entity?.EntityState?.Attributes?.Android_title));
            lastKnownThreshold = (int)_0Gbl._myEntities.InputNumber.LastKnowStepThreshold.State;
            _0Gbl._myScheduler.ScheduleCron("0 0 * * *", () => { 
                lastKnownThreshold = 0; 
                _0Gbl._myEntities.InputNumber.LastKnowStepThreshold.SetValue(0);
            });
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

                _0Gbl._myEntities.InputNumber.Dailysteps.SetValue(steps);

                if (stepsFloored < lastKnownThreshold)
                {
                    lastKnownThreshold = (int)stepsFloored;
                }

                if (stepsFloored >= FloorDownToThousand(lastKnownThreshold + notificationThreashold))
                {

                    lastKnownThreshold = (int)stepsFloored;
                    _0Gbl._myEntities.InputNumber.LastKnowStepThreshold.SetValue(lastKnownThreshold);

                    TTS.Speak("You have reached " + lastKnownThreshold.ToString() + "steps", TTS.TTSPriority.PlayInGuestMode);

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
