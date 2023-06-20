using HomeAssistantGenerated;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDaemonApps.apps
{
    [NetDaemonApp]
    public class _00_LivingRoomFP1
    {
        public static AqaraFP1Extender LivingRoomFP1;
        private InputTextEntity inputText;
        public _00_LivingRoomFP1(IHaContext ha) {

           Entities e = new Entities(ha);
            inputText = e.InputText.Fp1debugger;
            LivingRoomFP1 = new AqaraFP1Extender(e.BinarySensor.Livingroomfp1Presence, e.Sensor.Livingroomfp1PresenceEvent, e.Sensor.Livingroomfp1Action);
            
            foreach(var region in LivingRoomFP1.Regions)
            {
                region.callbacks.onEnter += FillDebug;
                region.callbacks.onExit += FillDebug;
            }

        }


        private void FillDebug(AqaraFP1Extender.FP1EventInfo info)
        {
            string text = "Entered: \r\n";
            foreach(var r in info.sensorData.enteredRegions)
            {
                text += r.name + "\r\n";
            }
        }
    }
}
