using HomeAssistantGenerated;
using NetDaemon.HassModel;

namespace NetDaemonApps.apps.Hue_Switches
{
    public abstract class HueSwitch
    {
        protected SensorEntity ?hueSwitchEntity;
        private readonly string[] events = { "on_press", "on_press_release", "on_hold", "on_hold_release", "up_press", "up_press_release", "up_hold", "up_hold_release", "down_press", "down_press_release", "down_hold", "down_hold_release", "off_press", "off_press_release", "off_hold", "off_hold_release" };
        public HueSwitch() {
            hueSwitchEntity = ObtainSwitch(_0Gbl._myEntities);


            if (hueSwitchEntity == null) return;

          //  hueSwitchEntity.StateAllChanges().Subscribe(x => DetermineAction(x?.Entity?.State ?? "Unknown"));

            foreach (var e in events)
            {
                var triggerObservable = _0Gbl.TriggerManager.RegisterTrigger(
                 new
                 {
                     platform = "state",
                     entity_id = new string[] { hueSwitchEntity.EntityId },
                     to = e
                 });
                 triggerObservable.Subscribe(n => DetermineAction(e)
                    );
            }

        }

        private void DetermineAction(string stateName)
        {
            Console.WriteLine("State:" + stateName);
            switch (stateName)
            {
                // Power Button
                case "on_press":
                    OnOnPress();
                break;

                case "on_press_release":
                    OnOnPressRelease();
                break;

                case "on_hold":
                    OnOnHold();
                break;

                case "on_hold_release":
                    OnOnHoldRelease();
                break;

                //Brightness Up
                case "up_press":
                    OnUpPress();
                break;

                case "up_press_release":
                    OnUpPressRelease();
                break;

                case "up_hold":
                    OnUpHold();
                break;

                case "up_hold_release":
                    OnUpHoldRelease();
                break;

                //Brightness Down
                case "down_press":
                    OnDownPress();
                    break;

                case "down_press_release":
                    OnDownPressRelease();
                    break;

                case "down_hold":
                    OnDownHold();
                    break;

                case "down_hold_release":
                    OnDownHoldRelease();
                break;


                // Hue Button
                case "off_press":
                    OnOffPress();
                    break;

                case "off_press_release":
                    OnOffPressRelease();
                    break;

                case "off_hold":
                    OnOffHold();
                    break;

                case "off_hold_release":
                    OnOffHoldRelease();
                    break;


            }

        }

        protected virtual SensorEntity ObtainSwitch(Entities entities)
        {
            return null;
        }

        /// <summary> Power-button Press Down</summary>
        protected virtual void OnOnPress() { }
        /// <summary> Power-button Press Release</summary>
        protected virtual void OnOnPressRelease() { }
        /// <summary> Power-button Hold</summary>
        protected virtual void OnOnHold() { }
        /// <summary> Power-button Hold release</summary>
        protected virtual void OnOnHoldRelease() { }

        /// <summary> Brighness Up-button Press Down</summary>
        protected virtual void OnUpPress() { }
        /// <summary> Brighness Up-button Press Release</summary>
        protected virtual void OnUpPressRelease() { }
        /// <summary> Brighness Up-button Hold</summary>
        protected virtual void OnUpHold() { }
        /// <summary> Brighness Up-button Hold release</summary>
        protected virtual void OnUpHoldRelease() { }

        /// <summary> Brighness Down-button Press Down</summary>
        protected virtual void OnDownPress() { }
        /// <summary> Brighness Down-button Press Release</summary>
        protected virtual void OnDownPressRelease() { }
        /// <summary> Brighness Down-button</summary>
        protected virtual void OnDownHold() { }
        protected virtual void OnDownHoldRelease() { }

        /// <summary> Hue-button Press Down</summary>
        protected virtual void OnOffPress(){}
        /// <summary> Hue-button Press Release</summary>
        protected virtual void OnOffPressRelease(){}
        /// <summary> Hue-button Hold</summary>
        protected virtual void OnOffHold(){}
        /// <summary> Hue-button Hold release</summary>
        protected virtual void OnOffHoldRelease(){}





 
    }
}
