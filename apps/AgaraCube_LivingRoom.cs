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
    [NetDaemonApp]

    public class AgaraCube_LivingRoom : AqaraCube
    {

        public AgaraCube_LivingRoom() : base()
        {



        }

        protected override SensorEntity? SetCubeActionEntity() { return _0Gbl._myEntities?.Sensor.CubeAction; }
        protected override SensorEntity? SetCubeSideEntity() { return _0Gbl._myEntities?.Sensor.CubeSide; }


        protected override void OnShake()
        {
            base.OnShake();

            if (_0Gbl._myEntities.Sensor.EcoflowStatus.State.ToLower() != "online")
            {

                _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();

                Task.Run(async () =>
                {
                    await Task.Run(async () =>
                    {
                        var waitTask = Task.Run(async () =>
                        {
                            while (_0Gbl._myEntities.Sensor.EcoflowStatus.State != "online") await Task.Delay(1000);
                        });

                        if (waitTask != await Task.WhenAny(waitTask, Task.Delay(120000)))
                            throw new TimeoutException();
                    });

                    _0Gbl._myEntities.Switch.EcoflowAcEnabled.TurnOn();


                });



            }
            else if (_0Gbl._myEntities.Sensor.EcoflowAcOutputFixed.State == 0)
            {
                _0Gbl._myEntities.Switch.EcoflowPlug.TurnOff();
                Task.Run(async () =>
                {
                    await Task.Delay(5000);

                    _0Gbl._myEntities.Switch.SwitchbotEcoflow.Toggle();


                });
              

                if(_0Gbl._myEntities.Sensor.EcoflowSolarInPower.State > 0)
                {
                    TTS.Speak("Solar Panels are active", TTS.TTSPriority.Default);
                }

            }

        }
    }

}
