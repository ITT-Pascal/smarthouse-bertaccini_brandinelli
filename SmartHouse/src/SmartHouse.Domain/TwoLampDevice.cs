using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class TwoLampDevice
    {

        public AbstractLamp Lamp1 { get; private set; }
        public AbstractLamp Lamp2 { get; private set; }

        public TwoLampDevice(Lamp lamp1, EcoLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;
 
        }

        public TwoLampDevice(Lamp lamp1, Lamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;

        }

        public TwoLampDevice(EcoLamp lamp1, EcoLamp lamp2)
        {
            Lamp1 = lamp1;
            Lamp2 = lamp2;

        }    

        public void SwitchOnOff(int selectedLamp)
        {

            if (selectedLamp < 1 || selectedLamp > 2)
                throw new ArgumentException("Selected lamp doesn't exist, Must select either 1 or 2");

           if(selectedLamp == 1)
           {
                Lamp1.SwitchOnOff();           
           }else
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









    }
}
