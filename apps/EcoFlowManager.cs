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
using System.Threading;

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

        private EcoflowPanel ecoflowPanel;

        protected class EcoflowPanel
        {


            private List<EcoflowPanelRow> ecoflowPanelList = new List<EcoflowPanelRow>();
            public EcoflowPanel() { }

            public void RegisterRow(InputBooleanEntity enabledEntity, InputSelectEntity modeEntity, InputDatetimeEntity timeEntity, InputNumberEntity powerEntity)
            {
                ecoflowPanelList.Add(new EcoflowPanelRow(enabledEntity, modeEntity, timeEntity, powerEntity));
            }




            protected class EcoflowPanelRow
            {
                public InputBooleanEntity enabled;
                public InputSelectEntity mode;
                public InputDatetimeEntity time;
                public InputNumberEntity power;
                private IDisposable schedculedEvent;




                public EcoflowPanelRow (InputBooleanEntity enabledEntity, InputSelectEntity modeEntity, InputDatetimeEntity timeEntity, InputNumberEntity powerEntity)
                {
                    enabled = enabledEntity;
                    mode = modeEntity;
                    time = timeEntity;
                    power = powerEntity;
                    RegisterListeners();
                }


                private void RegisterListeners()
                {

                    enabled.StateChanges().Subscribe(_ => { RegisterTimeListener(); });
                    time.StateChanges().Subscribe(_ => { RegisterTimeListener(); });
                    RegisterTimeListener();
                }

                private void RegisterTimeListener()
                {
                    if (schedculedEvent != null) schedculedEvent.Dispose();

                    if (enabled.IsOff()) return;

                    DateTime dateTimeVariable = DateTime.ParseExact(time.EntityState.State ?? "", "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    // Get the current time.
                    DateTime now = DateTime.Now;

                    // Create a DateTime object representing the target time today.
                    DateTime targetTimeToday = new DateTime(now.Year, now.Month, now.Day, dateTimeVariable.Hour, dateTimeVariable.Minute, 0);

                    // Check if the target time has already passed today.
                    if (targetTimeToday < now)
                    {
                        // If so, add a day to get the target time for tomorrow.
                        targetTimeToday = targetTimeToday.AddDays(1);
                    }

                    // Calculate the timespan until the target time.
                    TimeSpan timeSpan = targetTimeToday - now;

                 

                    schedculedEvent = _0Gbl._myScheduler.Schedule(timeSpan, TriggerEvent);
                }

                private void TriggerEvent()
                {
                    if (enabled.IsOff()) return;

                    switch (mode.State)
                    {
                        case "On":
                            TurnOn();
                            SetPower();
                        break;

                        case "Off":
                            TurnOff();
                         break;

                        case "Power Only":
                            SetPower();
                        break;

                    }

                    enabled.TurnOff();
                }


                private void TurnOn()
                {
                    if (_0Gbl._myEntities.Switch.EcoflowPlug.IsOff())
                        _0Gbl._myEntities.Switch.EcoflowPlug.TurnOn();
                    else _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
                }
                private void TurnOff()
                {
                        _0Gbl._myEntities.Switch.EcoflowPlug.TurnOff();
                }

                private void SetPower()
                {
                    Task.Run(async () =>
                    {
                        await Task.Run(async () =>
                        {
                            var waitTask = Task.Run(async () =>
                            {
                                while (_0Gbl._myEntities.Sensor.EcoflowStatus.State != "online") await Task.Delay(1000);
                            });

                            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(120000)))
                                throw new TimeoutException();
                        });

                        _0Gbl._myEntities.Number.EcoflowAcChargingPower.SetValue(power.State.ToString());
                    });
                }
            }


        }

        public EcoFlowManager()
        {

            _0Gbl._myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State <= 2 && (x.New?.State.HasValue ?? true)  && _0Gbl._myEntities.Sensor.EcoflowAcOutPower.State > 0 && _0Gbl._myEntities.InputBoolean.EcoflowAllow0Battery.IsOff()).Subscribe(x => {

                _0Gbl._myEntities.Switch.EcoflowPlug.TurnOn();

                TTS.Speak("Battery Recharing", TTS.TTSPriority.Default, _0Gbl._myEntities.InputBoolean.NotificationEcoflow);
         
            });
            _0Gbl._myEntities.Switch.EcoflowPlug.StateChanges().WhenStateIsFor(x => x.IsOff() && _0Gbl._myEntities.Sensor.EcoflowAcOutPower.State == 0 && _0Gbl._myEntities.Sensor.EcoflowStatus.State == "online", TimeSpan.FromSeconds(6),_0Gbl._myScheduler).Subscribe(x =>
            {
                _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();
            });

                _0Gbl._myEntities.Sensor.EcoflowBatteryLevel.StateChanges().Where(x => x.New?.State < 5 && x.Old?.State >= 5).Subscribe(x => {

                TTS.Speak("Warning Only 5% of Power remaining", TTS.TTSPriority.Default, _0Gbl._myEntities.InputBoolean.NotificationEcoflow);
            });


            ecoflowPanel = new EcoflowPanel();
            ecoflowPanel.RegisterRow(_0Gbl._myEntities.InputBoolean.EcopanelS1Enabled, _0Gbl._myEntities.InputSelect.EcopanelS1Mode, _0Gbl._myEntities.InputDatetime.EcopanelS1Time, _0Gbl._myEntities.InputNumber.EcopanelS1Power);
            ecoflowPanel.RegisterRow(_0Gbl._myEntities.InputBoolean.EcopanelS2Enabled, _0Gbl._myEntities.InputSelect.EcopanelS2Mode, _0Gbl._myEntities.InputDatetime.EcopanelS2Time, _0Gbl._myEntities.InputNumber.EcopanelS2Power);

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
