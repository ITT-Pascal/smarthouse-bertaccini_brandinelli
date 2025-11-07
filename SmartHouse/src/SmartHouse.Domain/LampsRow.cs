using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class LampsRow
    {
        public List<AbstractLamp> Lamps { get; private set; }

        public LampsRow()
        {
            Lamps = new List<AbstractLamp>();
        }

        public void AddEcoLamp()
        {           
             Lamps.Add(new EcoLamp());           
        }

        public void AddLamp()
        {         
             Lamps.Add(new Lamp());          
        }

        public void SingleLampSwitchOnOff(int selectedLamp)
        {
            if (selectedLamp < 0 || selectedLamp >= Lamps.Count)
                throw new ArgumentException("Selected lamp doesn't exist");

            Lamps[selectedLamp].SwitchOnOff();
        }

        public void SingleLampChangeBrightness(int newBrightness, int selectedLamp)
        {
            if (selectedLamp < 0 || selectedLamp >= Lamps.Count)
                throw new ArgumentException("Selected lamp doesn't exist");

            Lamps[selectedLamp].ChangeBrightness(newBrightness);
        }

        public void AllLampsSwitchOnOff()
        {
            for(int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SwitchOnOff();
            }

        }

       public void AllLampsChangeBrightness(int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {               
                Lamps[i].ChangeBrightness(newBrightness);
            }
        }









    }
}
