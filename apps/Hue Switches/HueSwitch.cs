using HomeAssistantGenerated;

namespace NetDaemonApps.apps.Hue_Switches
{
    public abstract class HueSwitch
    {
        protected SensorEntity ?hueSwitchEntity;
        protected Entities _myEntities;
        public HueSwitch(IHaContext ha) {

            _myEntities = new Entities(ha);

            hueSwitchEntity = ObtainSwitch(_myEntities);


            if (hueSwitchEntity == null) return;

            hueSwitchEntity.StateChanges().Subscribe(x => DetermineAction(x?.Entity?.State ?? "Unknown"));

        }

        private void DetermineAction(string stateName)
        {

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
                    OnOffHold();
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

        protected virtual void OnOnPress() { }
        protected virtual void OnOnPressRelease() { }
        protected virtual void OnOnHold() { }
        protected virtual void OnOnHoldRelease() { }

        protected virtual void OnUpPress() { }
        protected virtual void OnUpPressRelease() { }
        protected virtual void OnUpHold() { }
        protected virtual void OnUpHoldRelease() { }

        protected virtual void OnDownPress() { }
        protected virtual void OnDownPressRelease() { }
        protected virtual void OnDownHold() { }
        protected virtual void OnDownHoldRelease() { }

        protected virtual void OnOffPress(){}
        protected virtual void OnOffPressRelease(){}
        protected virtual void OnOffHold(){}
        protected virtual void OnOffHoldRelease(){}





 
    }
}
