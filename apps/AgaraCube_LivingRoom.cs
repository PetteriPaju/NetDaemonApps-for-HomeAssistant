using HomeAssistantGenerated;
using NetDaemon.HassModel.Entities;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{

    public class AgaraCube_LivingRoom : AqaraCube
    {

        public AgaraCube_LivingRoom() : base()
        {



        }

        protected override SensorEntity? SetCubeActionEntity() { return null; }
        protected override SensorEntity? SetCubeSideEntity() { return A0Gbl._myEntities?.Sensor.CubeSide; }


        protected override void OnShake()
        {
            base.OnShake();

            if (A0Gbl._myEntities.Sensor.EcoflowStatus.State.ToLower() != "online")
            {

                A0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();

                Task.Run(async () =>
                {
                    await Task.Run(async () =>
                    {
                        var waitTask = Task.Run(async () =>
                        {
                            while (A0Gbl._myEntities.Sensor.EcoflowStatus.State != "online") await Task.Delay(1000);
                        });

                        if (waitTask != await Task.WhenAny(waitTask, Task.Delay(120000)))
                            throw new TimeoutException();
                    });

                    A0Gbl._myEntities.Switch.EcoflowAcEnabled.TurnOn();


                });



            }
            else if (A0Gbl._myEntities.Sensor.EcoflowAcOutputFixed.State == 0)
            {
                A0Gbl._myEntities.Switch.EcoflowPlug.TurnOff();
                Task.Run(async () =>
                {
                    await Task.Delay(5000);

                    A0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();


                });
              

                if(A0Gbl._myEntities.Sensor.EcoflowSolarInPower.State > 0)
                {
                    TTS.Speak("Solar Panels are active", TTS.TTSPriority.Default);
                }

            }

        }
    }

}
