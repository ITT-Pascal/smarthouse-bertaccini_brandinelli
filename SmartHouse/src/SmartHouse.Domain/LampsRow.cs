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

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            Lamps.Insert(position, lamp);
        }

        public void RemoveLamp(string name)
        {
            for(int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                {
                    Lamps.RemoveAt(i);
                }
            }
        }

        public void RemoveLampInPosition(string name, int position)
        {
            Lamps.RemoveAt(position);
        }



        public void SingleLampSwitchOnOff(string name)
        {
           for(int i = 0; i<Lamps.Count;i++)
           {
                if (Lamps[i].Name == name)
                {
                    Lamps[i].SwitchOnOff();
                }
           }
        }

        public void SingleLampChangeBrightness(int newbrightness, string name)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                {
                    Lamps[i].ChangeBrightness(newbrightness);
                }
            }
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
