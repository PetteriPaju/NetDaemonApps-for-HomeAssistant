using HomeAssistantGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class _00_Globals
    {

        public static _00_Globals _instance;
        public static Entities _myEntities;
        public static Services _myServices;
        public static IScheduler _myScheduler;
        public static Action HourlyResetFunction;
        public static Action DailyResetFunction;


        public _00_Globals(IHaContext ha, IScheduler scheduler)
        {
            _instance = this;
            _myEntities = new Entities(ha);
            _myScheduler = scheduler;
            _myServices = new Services(ha);

            Task.Run(OnLateStart);

        }


        async Task OnLateStart()
        {
          await Task.Delay(1000);
          dateUpdate();
            Console.WriteLine("Success!");
        }

        private void dateUpdate()
        {
            if (checkDateChanged())
            {
                HourlyResetFunction?.Invoke();
            }
        }


        bool checkDateChanged()
        {
            DateTime dateTimeVariable = DateTime.ParseExact(_myEntities.InputDatetime.Lastknowndate.State ?? "", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return dateTimeVariable != DateTime.Now.Date;
        }
    }
}
