using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class AudioOutputMonitor
    {
        private Dictionary<Entity, bool> isConnectedCondition = new Dictionary<Entity, bool>();

        public AudioOutputMonitor()
        {
            _0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.StateChanges().Where(x => x?.New?.State == "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, true));
            _0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.StateChanges().Where(x => x?.New?.State != "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, false));
            _0Gbl._myEntities.Sensor.PcAudioDefaultDevice.StateChanges().Where(x => x?.New?.State == "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.PcAudioDefaultDevice, true));
            _0Gbl._myEntities.Sensor.PcAudioDefaultDevice.StateChanges().Where(x => x?.New?.State != "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(_0Gbl._myEntities.Sensor.PcAudioDefaultDevice, false));
            _0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.StateChanges().Where(x => (bool)(x?.New?.IsOn())).Subscribe(_ => CheckCondition(_0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, true));
            _0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.StateChanges().Where(x => (bool)(x?.New?.IsOff())).Subscribe(_ => CheckCondition(_0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, false));

            isConnectedCondition.Add(_0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, _0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.State == "Headphone (Realtek(R) Audio)");
            isConnectedCondition.Add(_0Gbl._myEntities.Sensor.PcAudioDefaultDevice, _0Gbl._myEntities.Sensor.PcAudioDefaultDevice.State == "Headphone (Realtek(R) Audio)");
            isConnectedCondition.Add(_0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, _0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.IsOn());

        }

        private void CheckCondition(Entity trueConditionEntity, bool newState)
        {
            if (!isConnectedCondition.ContainsKey(trueConditionEntity)) isConnectedCondition.Add(trueConditionEntity, newState);
            isConnectedCondition[trueConditionEntity] = newState;

            CheckAllIsSleepConditions();

        }
        private void CheckAllIsSleepConditions()
        {

            bool isConnected = false;

            foreach (bool cond in isConnectedCondition.Values)
            {
                if (cond)
                {
                    isConnected = true;
                    break;
                };
            }

            // If all conditions are true or false, we might need to change isSleep-state
            if (isConnected) _0Gbl._myEntities.Switch.FanPlug.TurnOn();
            else _0Gbl._myEntities.Switch.FanPlug.TurnOff();
        }
    }
}
