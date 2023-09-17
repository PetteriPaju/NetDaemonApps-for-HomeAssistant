using HomeAssistantGenerated;
using NetDaemon.Extensions.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class _0Gbl
    {

        public static _0Gbl _instance;
        public static Entities _myEntities { get; private set; }
        public static Services _myServices { get; private set; }
        public static IObservable<Event> _events { get; private set; }
        public static IScheduler _myScheduler { get; private set; }
        public static Action HourlyResetFunction { get; set; }
        public static Action DailyResetFunction { get; set; }


        public _0Gbl(IHaContext ha, IScheduler scheduler)
        {
            _instance = this;
            _myEntities = new Entities(ha);
            _myScheduler = scheduler;
            _myServices = new Services(ha);
            _events = ha.Events;
            _0Gbl._myScheduler.ScheduleCron("59 * * * *", hourlyResetFunction);
            _0Gbl._myScheduler.ScheduleCron("0 0 * * *", dailyResetFunction);
            Task.Run(OnLateStart);
         
        }


        async Task OnLateStart()
        {
          await Task.Delay(1000);
          dateUpdate();

        }

        private void dateUpdate()
        {
            if (checkDateChanged())
            {
                HourlyResetFunction?.Invoke();
            }
        }

        private void hourlyResetFunction()
        {
            HourlyResetFunction?.Invoke();
        }
        private void dailyResetFunction()
        {
            DailyResetFunction?.Invoke();
        }

        bool checkDateChanged()
        {
            DateTime dateTimeVariable = DateTime.ParseExact(_myEntities.InputDatetime.Lastknowndate.State ?? "", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return dateTimeVariable != DateTime.Now.Date;
        }
    }
}
