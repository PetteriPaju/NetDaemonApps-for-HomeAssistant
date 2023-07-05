using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    public class EcoFlowManager
    {

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

        private void planToday()
        {
            todayHoursRaw.Add(new KeyValuePair<int, double>(0, 1));
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
