﻿using HomeAssistantGenerated;
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
  //  [NetDaemonApp]
    public class IsHomeManager
    {
        protected Notifications.Actionable_NotificationData mobileNotificationData;
        private IDisposable? isHomeCancelFollower;
        private IDisposable? outOfHomeUntilTimeoutFollower;
        private  TimeSpan notificationTimeOut = TimeSpan.FromSeconds(30);
        public IsHomeManager() {


        /*
     
            mobileNotificationData = new Notifications.Actionable_NotificationData("I noticed you might not be home.");

            mobileNotificationData.PushToData("actions", new List<Notifications.ActionableData>() { new Notifications.TapableAction("CancelOutGome", "I am home", "ClearedTag", 5) } );



            NotifyMobileAppMotoG8PowerLiteParameters notifyMobileAppMotoG8PowerLiteParameters = new NotifyMobileAppMotoG8PowerLiteParameters()
            {
                Message = mobileNotificationData.message,
                Data = mobileNotificationData.data
            };
        */
            isHomeCancelFollower = null;




            var isCancelled = false;

            _0Gbl._myEntities.InputBoolean.SensorsActive.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => {_0Gbl._myEntities.InputBoolean.Ishome.TurnOn(); });
            _0Gbl._myEntities.InputBoolean.GuestMode.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => { _0Gbl._myEntities.InputBoolean.Ishome.TurnOn(); });

            _0Gbl._myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _0Gbl._myEntities.InputBoolean.Ishome.IsOff() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
                .Subscribe(x => {
                _0Gbl._myEntities.InputBoolean.Ishome.TurnOn();
                    isHomeCancelFollower?.Dispose();
                    outOfHomeUntilTimeoutFollower?.Dispose();
                    isCancelled = true;
                });

            _0Gbl._myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _0Gbl._myEntities.InputBoolean.Ishome.IsOn() && _0Gbl._myEntities.InputBoolean.SensorsActive.IsOn() && _0Gbl._myEntities.InputBoolean.GuestMode.IsOff())
                .SubscribeAsync(async s => {

                    isCancelled = false;
                    _0Gbl._myServices.Script.Sendishomephonenotification();
                    await Task.Delay(1000);
                  

                    TTS.Instance?.SpeakTTS("I noticed you might not be at home, can you confirm?");



                    outOfHomeUntilTimeoutFollower = _0Gbl._myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => { isCancelled = true; });
                    isHomeCancelFollower = _0Gbl._events.Filter<Notifications.ActionableNotificationResponseData>("mobile_app_notification_action").Where(x => x.Data.action == "IsHome")
                    .Subscribe(x => { 
                        isHomeCancelFollower?.Dispose();
                        outOfHomeUntilTimeoutFollower?.Dispose(); 
                        TTS.Instance?.SpeakTTS("OK never mind");
                        isCancelled = true; });

                    await Task.Delay((int)notificationTimeOut.TotalMilliseconds);

                    if (!isCancelled)
                    {
                        _0Gbl._myEntities.InputBoolean.Ishome.TurnOff();
                        TTS.Instance?.SpeakTTS("I guess he left");

                    }


                    isHomeCancelFollower?.Dispose();
                    outOfHomeUntilTimeoutFollower?.Dispose();

                });


       

            

        }
    }
}
