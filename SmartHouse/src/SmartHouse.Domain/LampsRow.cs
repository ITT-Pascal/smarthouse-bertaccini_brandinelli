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

        public void AddLamp(string name)
        {
            Lamps.Add(new Lamp(name));
        }

        public void AddEcoLamp(string name)
        {
            Lamps.Add(new EcoLamp(name));
        }

        public void RemoveLamp()
        {
            Lamps.Remove(new Lamp());
        }

        public void RemoveEcoLamp()
        {
            Lamps.Remove(new EcoLamp());
        }

        public void SingleLampSwitchOnOff(string name)
        {
            if (name < 0 || name >= Lamps.Count)
                throw new ArgumentException("Selected lamp doesn't exist");

            Lamps.SwitchOnOff(name);
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
