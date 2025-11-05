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

        const int EveneningShutOffTime = 22;
        const int MorningStartingTime = 4;

        const int MinBrightness = 0;
        const int MaxBrightness = 50;

        public EcoLamp()
        {
            Brightness = 0;
            IsOn = false;
            
        }

        public override void SwitchOnOff()
        {
            if (DateTime.UtcNow.Hour < 22 && DateTime.UtcNow.Hour > 4)
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
