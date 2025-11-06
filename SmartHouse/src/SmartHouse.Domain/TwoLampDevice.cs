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

            if (selectedLamp < 0 || selectedLamp >= Lamps.Count)
                throw new ArgumentException("Selected lamp doesn't exist");

            Lamps[selectedLamp].SwitchOnOff();
            

        }

        public void ChangeBrightness(int newBrightness, int selectedLamp)
        {
            if (selectedLamp < 0 || selectedLamp >= Lamps.Count)
                throw new ArgumentException("Selected lamp doesn't exist");

            Lamps[selectedLamp].ChangeBrightness(newBrightness);



        }









    }
}
