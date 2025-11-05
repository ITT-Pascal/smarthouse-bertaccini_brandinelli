using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public override bool IsOn { get;  set; }

        public override int Brightness { get;  set; }

        const int ShutOffTimeFirstLimit = 8;
        const int ShutOffTimeSecondLimit = 18;

        const int MinBrightness = 0;
        const int MaxBrightness = 50;

        public EcoLamp()
        {
            Brightness = 0;
            while(DateTime.UtcNow.Hour < ShutOffTimeFirstLimit || DateTime.UtcNow.Hour > ShutOffTimeSecondLimit)
            {
                IsOn = false;
            }
               
            
        }
        //Commit
        public override void SwitchOnOff()
        {
            if (DateTime.UtcNow.Hour < ShutOffTimeFirstLimit || DateTime.UtcNow.Hour > ShutOffTimeSecondLimit)
                IsOn = !IsOn;
            else
                IsOn = false;
        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness > MinBrightness && IsOn == true)
                Brightness = Math.Min(newBrightness, MaxBrightness);
            else
                IsOn = false;
        }

    }
}
