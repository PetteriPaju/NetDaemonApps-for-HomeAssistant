using HomeAssistantGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using NetDaemon.Extensions.Scheduler;

namespace NetDaemonApps.apps
{
    public class EcoFlowManager
    {
        private readonly Entities _myEntities;
        private double chargeTimeThreshold = 1.25;
        private double peakTimeThreshold = 0.8;

        private int maxOnHours = 5;
        private int maxChargeHours = 3;

        private List<int> plannedChargeHoursToday = new List<int>();
        private List<int> plannedOnHoursToday= new List<int>();
        private List<int> plannedChargeHoursTomorrow = new List<int>();
        private List<int> plannedOnHoursTomorrow = new List<int>();

       private List<KeyValuePair<int,double>> todayHoursRaw = new List<KeyValuePair<int,double>>();
        private List<KeyValuePair<int, double>> tomorrowHoursRaw = new List<KeyValuePair<int, double>>();

        public EcoFlowManager(IHaContext ha, IScheduler scheduler)
        {
            _myEntities = new Entities(ha);

            _myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State < 2).Subscribe(x => {

                _myEntities.Switch.EcoflowPlug.TurnOn();
         
            });

            _myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State == 100).Subscribe(x => {

                _myEntities.Switch.EcoflowPlug.TurnOff();
            });

            _myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State < 10).Subscribe(x => {

                TTS.Speak("Warning Only 10% of Power remaining");
            });


            scheduler.ScheduleCron("0 * * * *", () => {

                if (plannedOnHoursToday.Contains(DateTime.Now.Hour))
                {
                    if (_myEntities.InputSelect.SettingsEcoflowMode.State == "Manual") return;
                    
                    if(plannedOnHoursToday.IndexOf(DateTime.Now.Hour) != 0 && _myEntities.InputSelect.SettingsEcoflowMode.State == "Auto")
                    {
                        //if(DateTime.Now + TimeSpan.FromMinutes(_myEntities.Sensor.EcoflowDischargeRemainingTime.State ?? 0) > )
                        _myEntities.Switch.EcoflowPlug.TurnOn();
                    } 
                    else if(plannedOnHoursToday.IndexOf(DateTime.Now.Hour) == 0)
                    _myEntities.Switch.EcoflowPlug.TurnOn();
                }

            });

            scheduler.ScheduleCron("0 0 * * *", () => {
                planToday(_myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Today);
            });


            _myEntities?.Sensor.NordpoolKwhFiEur31001.StateChanges().Where(x => x?.New?.State == _myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Min).Subscribe(_ => { _myEntities.Switch.EcoflowPlug.TurnOn(); });
            planToday(_myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Today);
        }
        private void planToday(IReadOnlyList<double>? hours)
        {
            todayHoursRaw.Clear();

            for (int i = 0; i <hours?.Count; i++)
            {
                todayHoursRaw.Add(new KeyValuePair<int, double>(i, hours[i]));
            }


            plannedOnHoursToday.Clear();
            List<KeyValuePair<int, double>> orderedHours = todayHoursRaw.OrderByDescending(x => x.Key).ToList();

            KeyValuePair<int, double> lowest = orderedHours.First();       
            KeyValuePair<int, double> highest = orderedHours.Last();

            KeyValuePair<int, double> middayChargingHour = orderedHours.FirstOrDefault(x => x.Value > 12 && x.Key < 20, highest);
            bool shoudMiddayBeUsed = middayChargingHour.Value * 2 < highest.Value;

            plannedOnHoursToday.Add(lowest.Key);
            if(shoudMiddayBeUsed) plannedOnHoursToday.Add(middayChargingHour.Key);


        }

        private void planTomorrow()
        {
            
            List<double> inputList = new List<double>();
            double peak = 0.5f;
            findPeaks(plannedOnHoursTomorrow, inputList, peakTimeThreshold, peak);

        }

        private void findPeaks(List<int> hourList, List<double> inputList, double threshold,double minmaxValue)
        {
            hourList.Clear();

           
            for(int i= 0; i<inputList.Count; i++)
            {

                //check the math
                if (inputList[i]*threshold > minmaxValue)

                {
                    hourList.Add(i);
                }
             
            }

        }

        private int findPossibleHour(int fromhour, out bool isTomorrow)
        {
            int possibleHour = -1;
            isTomorrow = false;
            return possibleHour;
        }




    }
}
