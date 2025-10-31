using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class TwoLampDevice
    {

        public List<AbstractLamp> Lamps { get; private set; } 

        public TwoLampDevice()
        {

            Lamps = new List<AbstractLamp>();
            

        }

        public void AddEcoLamp()
        {
            if (Lamps.Count < 2)
            {
                Lamps.Add(new EcoLamp());

            }
            

        }

        public void AddLamp()
        {
            if (Lamps.Count < 2)
            {
                Lamps.Add(new Lamp());

            }


        }

        public void SwitchOnOff(int selectedLamp)
        {
            if (selectedLamp == 0)
                Lamps[0].SwitchOnOff();
            else
                Lamps[1].SwitchOnOff();

        }

        public void ChangeBrightness(int newBrightness, int selectedLamp)
        {
            if (selectedLamp == 0)
                Lamps[0].ChangeBrightness(newBrightness);
            else
                Lamps[1].ChangeBrightness(newBrightness);



        }









    }
}
