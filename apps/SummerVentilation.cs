using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;

namespace NetDaemonApps.apps
{
   
    
    public class SummerVentilation
    {
        /*
        private enum windowActions {DoNothing, Open, Close};
        private readonly Entities _myEntities;
        private const double mininumOutdoorsTemp = 20;
        private readonly TimeSpan notificationInterval = TimeSpan.FromMinutes(30);
        private DateTime lastTimeNotificationSent = DateTime.MinValue;
        public SummerVentilation(IHaContext ha) {
            _myEntities = new Entities(ha);

            _myEntities.Sensor.OutsideTemperatureMeterTemperature.StateChanges().Subscribe(_=>DetermineAction());
            _myEntities.Sensor.WifiTemperatureHumiditySensorTemperature.StateChanges().Subscribe(_ => DetermineAction());
            _myEntities.BinarySensor.LivingroomWindowSensorContact.StateChanges().Subscribe(_ => lastTimeNotificationSent = DateTime.Now + TimeSpan.FromHours(1));




        }


        private void DetermineAction()
        {
            if (_myEntities.Sensor.OutsideTemperatureMeterTemperature.State < mininumOutdoorsTemp) return;
            if (DateTime.Now < lastTimeNotificationSent + notificationInterval) return;

            windowActions action = GetWindowAction();

            if(action == windowActions.Open)
            {
                TTS.Speak("You should open the window");
                lastTimeNotificationSent = DateTime.Now;

            }
            else if(action == windowActions.Close)
            {
                TTS.Speak("You should close the window");
                lastTimeNotificationSent = DateTime.Now;
            }
        }

        private bool isOutdoorsColderThanInside()
       {

          return  _myEntities.Sensor.OutsideTemperatureMeterTemperature.State < _myEntities.Sensor.WifiTemperatureHumiditySensorTemperature.State;
       }

        private bool isWindowOpen()
        {
            return _myEntities.BinarySensor.LivingroomWindowSensorContact.IsOn();
        }

        private windowActions GetWindowAction()
        {


            if (isOutdoorsColderThanInside() && !isWindowOpen()) return windowActions.Open;
            else if (!isOutdoorsColderThanInside() && isWindowOpen()) return windowActions.Close;


            return windowActions.DoNothing;
        }



        */

    }
}
