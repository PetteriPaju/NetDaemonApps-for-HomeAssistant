using HomeAssistantGenerated;
using Microsoft.VisualBasic.FileIO;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;

namespace NetDaemonApps.apps
{

    [NetDaemonApp]
    public class StepCounter
    {
        private int lastKnownThreshold = 0;
        private int notificationThreashold = 1000;
        private static string runnerCsvPath = "//192.168.0.12/share/runner.csv";
        public StepCounter()
        {

            // _0Gbl._myEntities.Sensor.MotoG8PowerLiteLastNotification?.StateAllChanges().Where(x => IsValidStep(x))?.Subscribe(x => ParseSteps(x?.Entity?.EntityState?.Attributes?.Android_title));
            _0Gbl._myEntities.Sensor.MotoG8PowerLiteStepsSensor.StateChanges().Subscribe(x => CalculatePhoneSteps(x.Old.State ?? x.New.State, x.New.State));
            lastKnownThreshold = (int)_0Gbl._myEntities.InputNumber.LastKnowStepThreshold.State;


            _0Gbl._myEntities.Event.FolderWatcherShare.StateChanges().Subscribe(x => ReadCSV());
            ReadCSV();
            _0Gbl.DailyResetFunction += () =>
            {
                lastKnownThreshold = 0;
                _0Gbl._myEntities.InputNumber.LastKnowStepThreshold.SetValue(0); 
                _0Gbl._myEntities.InputNumber.Dailysteps.SetValue(0);
                _0Gbl._myEntities.InputNumber.WalkingpadStepsDaily.SetValue(0);
            };

        }

        void RefreshThreshold()
        {
            var stepsFloored = FloorDownToThousand(_0Gbl._myEntities.InputNumber.Dailysteps.State ?? 0 + (_0Gbl._myEntities.InputNumber.WalkingpadStepsDaily.State ?? 0));

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
        void CalculatePhoneSteps(double? old, double? now) {

            double dif = double.Max(0,now ?? 0 - old ?? 0);
            _0Gbl._myEntities.InputNumber.Dailysteps.AddValue(dif);
            RefreshThreshold();
        }
        int ReadCSV()
        {
            int totalSteps = 0;
            using (TextFieldParser parser = new TextFieldParser(runnerCsvPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                List<string[]> strings = new List<string[]>();
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    strings.Add(fields);
                }

                for(int i = strings.Count-1; i >= 0; i--)
                {
                    // Using DateTime.TryParse (more robust for potential parsing errors)
                    DateTime parsedDateTime;
                    if (DateTime.TryParse(strings[i][0], out parsedDateTime))
                    {
                        Console.WriteLine(parsedDateTime);
                        if (parsedDateTime.Date == DateTime.Today)
                        {
                            totalSteps = totalSteps+=int.Parse(strings[i][3]);
                            break;
                        }
                        else
                        {
                            break;
                        }

                        // Successful parsing
                       
                    }
                    else
                    {   
                        // Parsing failed
                        Console.WriteLine("Invalid date-time format.");
                    }
                }
            }

            _0Gbl._myEntities.InputNumber.WalkingpadStepsDaily.SetValue(totalSteps);
            RefreshThreshold();
            return totalSteps;
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
                _0Gbl._myEntities.InputNumber.Dailysteps.SetValue(steps);

                var stepsFloored = FloorDownToThousand(steps + (_0Gbl._myEntities.InputNumber.WalkingpadStepsDaily.State ?? 0));

               

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
