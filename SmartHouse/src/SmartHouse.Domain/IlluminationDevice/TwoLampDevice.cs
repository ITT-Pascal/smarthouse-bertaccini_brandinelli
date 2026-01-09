using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Illumination
{
    public class TwoLampDevice : ILampGroup
    {
        public AbstractLamp Lamp1 { get; private set; }
        public AbstractLamp Lamp2 { get; private set; }

        public TwoLampDevice(AbstractLamp lamp1, AbstractLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
        }

        public void SwitchOn(int selectedLamp)
        {
            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if (selectedLamp == 1)
            {
                Lamp1.SwitchOn();
            }
            else
            {
                Lamp2.SwitchOn();
            }
        }

        public void SwitchOff(int selectedLamp)
        {
            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if (selectedLamp == 1)
            {
                Lamp1.SwitchOff();
            }
            else
            {
                Lamp2.SwitchOff();
            }
        }

        public void Dimmer(int selectedLamp)
        {
            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if (selectedLamp == 1)
            {
                Lamp1.Dimmer();
            }
            else
            {
                Lamp2.Dimmer();
            }
        }

        public void Brighten(int selectedLamp)
        {
            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if (selectedLamp == 1)
            {
                Lamp1.Brighten();
            }
            else
            {
                Lamp2.Brighten();
            }
        }

        public void SwitchOnOff(int selectedLamp)
        {

            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if(selectedLamp == 1)
            {
                Lamp1.SwitchOnOff();           
            }
            else
            {
                Lamp2.SwitchOnOff();
            }
            
        }

        public void ChangeBrightness(int newBrightness, int selectedLamp)
        {
            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

            if (selectedLamp == 1)
            {
                Lamp1.ChangeBrightness(newBrightness);
            }
            else
            {
                Lamp2.ChangeBrightness(newBrightness);
            }
        }

        public void AllSwitchOn()
        {
            Lamp1.SwitchOn();
            Lamp2.SwitchOn();
        }

        public void AllSwitchOff()
        {
            Lamp1.SwitchOff();
            Lamp2.SwitchOff();
        }

        public void AllLampsSwitchOnOff()
        {
            Lamp1.SwitchOnOff();
            Lamp2.SwitchOnOff();
        }
    }
}
