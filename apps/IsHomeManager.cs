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
        protected readonly Entities _myEntities;
        protected readonly Services _myServices;
        protected Notifications.Actionable_NotificationData mobileNotificationData;
        private IDisposable? isHomeCancelFollower;
        private IDisposable? outOfHomeUntilTimeoutFollower;
        private  TimeSpan notificationTimeOut = TimeSpan.FromSeconds(30);
        public IsHomeManager(IHaContext ha, IScheduler scheduler) {

            _myServices = new Services(ha);
            _myEntities = new Entities(ha);

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


            _myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _myEntities.InputBoolean.Ishome.IsOff())
                .Subscribe(x => {
                _myEntities.InputBoolean.Ishome.TurnOn();
                    isHomeCancelFollower?.Dispose();
                    outOfHomeUntilTimeoutFollower?.Dispose();
                    isCancelled = true;
                });

            _myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on" && _myEntities.InputBoolean.Ishome.IsOn())
                .SubscribeAsync(async s => {

                    isCancelled = false;
                    _myServices.Script.Sendishomephonenotification();
                    await Task.Delay(1000);


                    TTS.Instance?.SpeakTTS("I noticed you might not be at home, can you confirm?");



                    outOfHomeUntilTimeoutFollower = _myEntities.BinarySensor.FrontDoorSensorContact.StateChanges().Where(x => x.New?.State == "off" && x.Old?.State == "on").Subscribe(x => { isCancelled = true; });
                    isHomeCancelFollower = ha.Events.Filter<Notifications.ActionableNotificationResponseData>("mobile_app_notification_action").Where(x => x.Data.action == "IsHome")
                    .Subscribe(x => { 
                        isHomeCancelFollower?.Dispose();
                        outOfHomeUntilTimeoutFollower?.Dispose(); 
                        TTS.Instance?.SpeakTTS("OK never mind");
                        isCancelled = true; });

                    await Task.Delay((int)notificationTimeOut.TotalMilliseconds);

                    if (!isCancelled)
                    {
                        _myEntities.InputBoolean.Ishome.TurnOff();
                        TTS.Instance?.SpeakTTS("I guess he left");

                    }


                    isHomeCancelFollower?.Dispose();
                    outOfHomeUntilTimeoutFollower?.Dispose();

                });


       

            

        }
    }
}
