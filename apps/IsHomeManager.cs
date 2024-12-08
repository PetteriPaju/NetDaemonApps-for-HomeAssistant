using HomeAssistantGenerated;
using Microsoft.Extensions.Configuration;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Text.RegularExpressions;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace NetDaemonApps.apps
{
  [NetDaemonApp]
    public class IsHomeManager
    {
        private  TimeSpan notificationTimeOut = TimeSpan.FromSeconds(30);
        public bool isCancelled = false;
        public bool cancelWait = false;

        public static IsHomeManager _instance { get; private set; }
        public static bool CancelIsHome()
        {
            if (_instance.cancelWait)
            {
                _instance.isCancelled = true;
                _instance.cancelWait = false;
                TTS.Instance?.SpeakTTS("OK never mind");
                return true;
            }

            return false;
        }

        public IsHomeManager() {

            _instance = this;
        /*
     
            mobileNotificationData = new Notifications.Actionable_NotificationData("I noticed you might not be home.");

            mobileNotificationData.PushToData("actions", new List<Notifications.ActionableData>() { new Notifications.TapableAction("CancelOutGome", "I am home", "ClearedTag", 5) } );



            NotifyMobileAppMotoG8PowerLiteParameters notifyMobileAppMotoG8PowerLiteParameters = new NotifyMobileAppMotoG8PowerLiteParameters()
            {
                Message = mobileNotificationData.message,
                Data = mobileNotificationData.data
            };
        */

            _0Gbl._myEntities.InputBoolean.SensorsActive.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => {_0Gbl._myEntities.InputBoolean.Ishome.TurnOn(); });
            _0Gbl._myEntities.InputBoolean.GuestMode.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => { _0Gbl._myEntities.InputBoolean.Ishome.TurnOn(); });

            _0Gbl._myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _0Gbl._myEntities.InputBoolean.Ishome.IsOff() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
                .Subscribe(x => {
                _0Gbl._myEntities.InputBoolean.Ishome.TurnOn();
                    isCancelled = true;
                });

            _0Gbl._myEntities.BinarySensor.HallwaySensorOccupancy.StateChanges().Where(x => x.New?.State == "on" && x.Old?.State == "off" && _0Gbl._myEntities.InputBoolean.Ishome.IsOff() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff() && _0Gbl._myEntities.InputBoolean.Ishome.StateFor(TimeSpan.FromMinutes(2)))
                .Subscribe(x => {
                    _0Gbl._myEntities.InputBoolean.Ishome.TurnOn();

                });



            _0Gbl._myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _0Gbl._myEntities.InputBoolean.Ishome.IsOn() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
                .SubscribeAsync(async s => {
                    await Task.Delay((int)TimeSpan.FromSeconds(5).TotalMilliseconds);
                    isCancelled = false;

                    _instance.cancelWait = true;
                    TTS.Instance?.SpeakTTS("I noticed you might not be at home, can you confirm?");

                    await Task.Delay((int)notificationTimeOut.TotalMilliseconds);

                    if (!isCancelled)
                    {
                        _0Gbl._myEntities.InputBoolean.Ishome.TurnOff();
                        TTS.Instance?.SpeakTTS("I guess he left");

                    }
                    _instance.cancelWait = false;
                });


       

            

        }
    }
}
