using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps.Lights
{
    [NetDaemonApp]
    public class Kitchen_Light
    {
        public static NumericSensorEntity luxSensorEntity;

        public void TurnOn()
        {
            if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
            A0Gbl._myEntities.Light.KitchenLight2.TurnOnLight();
        }
        public void TurnOff()
        {
            if (A0Gbl._myEntities.InputBoolean.GuestMode.IsOn()) return;
            if (A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.State == "approach") return;
            if (A0Gbl._myEntities.BinarySensor._0x001788010bcfb16fOccupancy.IsOn()) return;
            A0Gbl._myEntities.Light.KitchenLight2.TurnOffLight();
        }
        public Kitchen_Light() {


            A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().Where(x => ((bool)x?.New.IsOn())).Subscribe(_ => {
                TurnOn();
                IsHomeManager.CancelIsHome();
            });

            A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.StateChanges().WhenStateIsFor(x => ((bool)x?.IsOff()), TimeSpan.FromSeconds(50), A0Gbl._myScheduler).Subscribe(_ => {
                TurnOff();
            });

            A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().Where(x => x.New?.State == "approach").Subscribe(_ => {
                TurnOn();
            });

            A0Gbl._myEntities.BinarySensor._0x001788010bcfb16fOccupancy.StateChanges().Where(x => x.New.IsOff()).Subscribe(_ => {
                TurnOff();
            });

            A0Gbl._myEntities.BinarySensor.Livingroomfp1Presence.StateChanges().Where(x => x.New.IsOff() && A0Gbl._myEntities.BinarySensor.FridgeContactSensorContact.IsOff()).Subscribe(_ => {

                TurnOff();
            });

            A0Gbl._myEntities.Sensor.Livingroomfp1PresenceEvent.StateChanges().Where(x => (x?.New?.State != "approach")).Subscribe(_ => {
                TurnOff();
            });

        }

    }
}
