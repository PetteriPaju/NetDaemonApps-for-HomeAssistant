﻿using HomeAssistantGenerated;
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
            A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.StateChanges().Where(x => x?.New?.State == "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, true));
            A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.StateChanges().Where(x => x?.New?.State != "Headphone (Realtek(R) Audio)").Subscribe(_ => CheckCondition(A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, false));
            A0Gbl._myEntities.Sensor.PcAudioDefaultDevice.StateChanges().Where(x => x?.New?.State == "Speakers (Realtek(R) Audio)").Subscribe(_ => CheckCondition(A0Gbl._myEntities.Sensor.PcAudioDefaultDevice, true));
            A0Gbl._myEntities.Sensor.PcAudioDefaultDevice.StateChanges().Where(x => x?.New?.State != "Speakers (Realtek(R) Audio)").Subscribe(_ => CheckCondition(A0Gbl._myEntities.Sensor.PcAudioDefaultDevice, false));
            A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.StateChanges().Where(x => (bool)(x?.New?.IsOn())).Subscribe(_ => CheckCondition(A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, true));
            A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.StateChanges().Where(x => (bool)(x?.New?.IsOff())).Subscribe(_ => CheckCondition(A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, false));

            isConnectedCondition.Add(A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice, A0Gbl._myEntities.Sensor.EnvyAudioDefaultDevice.State == "Headphone (Realtek(R) Audio)");
            isConnectedCondition.Add(A0Gbl._myEntities.Sensor.PcAudioDefaultDevice, A0Gbl._myEntities.Sensor.PcAudioDefaultDevice.State == "Speakers (Realtek(R) Audio)");
            isConnectedCondition.Add(A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors, A0Gbl._myEntities.BinarySensor.PortableHeadphoneSensors.IsOn());

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
            if (isConnected) A0Gbl._myEntities.Switch.FanPlug.TurnOn();
            else A0Gbl._myEntities.Switch.FanPlug.TurnOff();
        }
    }
}
