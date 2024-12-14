using HomeAssistantGenerated;
using Microsoft.VisualBasic.FileIO;
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
        private static string runnerCsvPath = "/share/runner.csv";
        public StepCounter()
        {

            _0Gbl._myEntities.Sensor.MotoG8PowerLiteLastNotification?.StateAllChanges().Where(x => IsValidStep(x))?.Subscribe(x => ParseSteps(x?.Entity?.EntityState?.Attributes?.Android_title));
            lastKnownThreshold = (int)_0Gbl._myEntities.InputNumber.LastKnowStepThreshold.State;

            ReadCSV();
            _0Gbl.DailyResetFunction += () =>
            {
                lastKnownThreshold = 0;
                _0Gbl._myEntities.InputNumber.LastKnowStepThreshold.SetValue(0); 
                _0Gbl._myEntities.InputNumber.Dailysteps.SetValue(0);
            };


        }

        void ReadCSV()
        {
            using (TextFieldParser parser = new TextFieldParser(runnerCsvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        Console.WriteLine(field);
                    }
                }
            }
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

                    TTS.Speak("You have reached " + lastKnownThreshold.ToString() + "steps", TTS.TTSPriority.PlayInGuestMode, _0Gbl._myEntities.InputBoolean.NotificationStepCounter);

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
