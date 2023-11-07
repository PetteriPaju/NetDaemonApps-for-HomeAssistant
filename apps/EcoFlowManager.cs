using HomeAssistantGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using NetDaemon.Extensions.Scheduler;
using System.Text.Json;
using System.Diagnostics;
using NetDaemon.HassModel.Entities;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
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



        public EcoFlowManager()
        {

            _0Gbl._myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State <= 2 && x.New?.State.HasValue ?? true  && _0Gbl._myEntities.Sensor.EcoflowAcOutPower.State > 0 && _0Gbl._myEntities.InputBoolean.EcoflowAllow0Battery.IsOff()).Subscribe(x => {

                _0Gbl._myEntities.Switch.EcoflowPlug.TurnOn();

                TTS.Speak("Battery Recharing", TTS.TTSPriority.Default);
         
            });

            _0Gbl._myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State == 100 && _0Gbl._myEntities.Switch.Schedule9ee8ea.IsOff()).Subscribe(x => {

                _0Gbl._myEntities.Switch.EcoflowPlug.TurnOff();
               // DetermineNextChargeTime();
            });
            _0Gbl._myEntities.Switch.EcoflowPlug.StateChanges().WhenStateIsFor(x => x.IsOff() && _0Gbl._myEntities.Sensor.EcoflowStatus.State == "online" && _0Gbl._myEntities.Sensor.EcoflowAcOutPower.State == 0, TimeSpan.FromSeconds(6),_0Gbl._myScheduler).Subscribe(x =>
            {
                _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
            });

                _0Gbl._myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State < 5 && x.Old?.State >= 5).Subscribe(x => {

                TTS.Speak("Warning Only 5% of Power remaining", TTS.TTSPriority.Default);
            });

            /*
            scheduler.ScheduleCron("0 * * * *", () => {





                if (plannedOnHoursToday.Contains(DateTime.Now.Hour))
                {
                    if (_00_Globals._myEntities.InputSelect.SettingsEcoflowMode.State == "Manual") return;
                    
                    if(plannedOnHoursToday.IndexOf(DateTime.Now.Hour) != 0 && _00_Globals._myEntities.InputSelect.SettingsEcoflowMode.State == "Auto")
                    {
                        if((DateTime.Now + TimeSpan.FromMinutes(_00_Globals._myEntities.Sensor.EcoflowDischargeRemainingTime.State ?? 0)).TimeOfDay.TotalSeconds < _00_Globals._myEntities.InputDatetime.NextPlannedEcocharge.Attributes?.Timestamp )
                        _00_Globals._myEntities.Switch.EcoflowPlug.TurnOn();
                    } 
                    else if(plannedOnHoursToday.IndexOf(DateTime.Now.Hour) == 0)
                    _00_Globals._myEntities.Switch.EcoflowPlug.TurnOn();
                }
                DetermineNextChargeTime();
            });

            scheduler.ScheduleCron("0 0 * * *", () => {
                plan(_00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Today, todayHoursRaw, plannedOnHoursToday);
            });


            _00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001.StateChanges().Where(x => x?.New?.State == _00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Min).Subscribe(_ => { _00_Globals._myEntities.Switch.EcoflowPlug.TurnOn(); });
            _00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001.StateAllChanges().Where(x => x?.New?.Attributes?.TomorrowValid == true && x.Old?.Attributes?.TomorrowValid == false).Subscribe(_ => { DetermineNextChargeTime(); });




            plan(_00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001.Attributes?.Today, todayHoursRaw, plannedOnHoursToday);
            if (_00_Globals._myEntities?.Sensor.NordpoolKwhFiEur31001?.Attributes?.TomorrowValid ?? false )
            {
                var list = JsonSerializer.Deserialize<List<double>?>(_00_Globals._myEntities.Sensor?.NordpoolKwhFiEur31001?.EntityState?.Attributes?.Tomorrow.ToString());
                plan(list, tomorrowHoursRaw, plannedChargeHoursTomorrow);
            }

            DetermineNextChargeTime();
            */
        }
        private void plan(IEnumerable<double>? hours, List<KeyValuePair<int, double>> rawList, List<int> planList)
        {
            rawList.Clear();

            List<double>? tmp = hours?.ToList();

            for (int i = 0; i < tmp?.Count; i++)
            {
                rawList.Add(new KeyValuePair<int, double>(i, tmp[i]));
            }


            planList.Clear();
            List<KeyValuePair<int, double>> orderedHours = rawList.OrderByDescending(x => x.Value).Reverse().ToList();

            KeyValuePair<int, double> lowest = orderedHours.First();
       
            KeyValuePair<int, double> highest = orderedHours.Last();

            KeyValuePair<int, double> middayChargingHour = orderedHours.FirstOrDefault(x => x.Value > 12 && x.Key < 20, highest);
            bool shoudMiddayBeUsed = middayChargingHour.Value * 2 < highest.Value;

            planList.Add(lowest.Key);
            if(shoudMiddayBeUsed) planList.Add(middayChargingHour.Key);


        }

        private void DetermineNextChargeTime()
        {
            int hour = -1;
            hour = plannedOnHoursToday.LastOrDefault(x => x > DateTime.Now.Hour,-1);
            _0Gbl._myEntities.InputDatetime.NextPlannedEcocharge.SetDatetime(datetime:DateTime.Now.ToString(@"yyyy-MM-dd HH\:mm\:ss"));
            
            if (hour != -1)
            {
                _0Gbl._myEntities.InputDatetime.NextPlannedEcocharge.SetDatetime(datetime: new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, 0, 0).ToString(@"yyyy-MM-dd HH\:mm\:ss"));
            }
            else if(_0Gbl._myEntities?.Sensor.NordpoolKwhFiEur31001?.Attributes?.TomorrowValid ?? false)
            {
                hour = plannedChargeHoursTomorrow.FirstOrDefault(-1);
            
                DateTime tmrw = DateTime.Now.AddDays(1);
                if(hour != -1)
                _0Gbl._myEntities.InputDatetime.NextPlannedEcocharge.SetDatetime(datetime: new DateTime(tmrw.Year, tmrw.Month, tmrw.Day, hour, 0, 0).ToString(@"yyyy-MM-dd HH\:mm\:ss"));

            }


        }



    }
}
