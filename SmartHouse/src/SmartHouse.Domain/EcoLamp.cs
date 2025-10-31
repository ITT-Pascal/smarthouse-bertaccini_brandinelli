using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public bool IsOn { get; private set; }

        public int Brightness { get; private set; }

        const int MinBrightness = 0;
        const int MaxBrightness = 50;

        public EcoLamp()
        {
            Brightness = 0;
            IsOn = false;

        }

        public override void SwitchOnOff()
        {
            IsOn = !IsOn;

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
