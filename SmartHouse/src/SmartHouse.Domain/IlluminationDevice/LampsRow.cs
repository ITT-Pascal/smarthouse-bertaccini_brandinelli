using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Domain.Illumination
{
    public class LampsRow : ILampGroup
    {
        public List<AbstractLamp> Lamps { get; private set; }
        public string Name { get; private set; }

        public LampsRow(string name, List<AbstractLamp> lamps)
        {
            Name = name;
            Lamps = lamps;
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Il nome non è valido");
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

        public void RemoveLamp(Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Id == id)
                {
                    Lamps.RemoveAt(i);
                }
            }
        }

        public void RemoveLampInPosition(string name, int position)
        {
            Lamps.RemoveAt(position);
        }

        public void SwitchOn(Guid id)
        {
            for(int i = 0; i<Lamps.Count;i++)
            {
                if (Lamps[i].Id == id)
                    Lamps[i].SwitchOn();
            }

        }
        public void SwitchOff(Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Id == id)
                    Lamps[i].SwitchOff();
            }

        }

        public void SwitchOn(string name)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                    Lamps[i].SwitchOn();
            }
        }

        public void SwitchOff(string name)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                    Lamps[i].SwitchOff();
            }
        }

        public void AllSwitchOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SwitchOn();
            }
        }

        public void AllSwitchOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].SwitchOff();
            }
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

        public void SingleLampChangeBrightness(int newbrightness, Guid id)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Id == id)
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

        public AbstractLamp? FindLampWithMaxBrightness()
        {
            AbstractLamp? lamp = Lamps[0];

            foreach(AbstractLamp l in Lamps)
            {
                if (l.Brightness > lamp.Brightness)
                    lamp = l;
            }

            return lamp;            
        }

        public AbstractLamp? FindLampWithMinBrightness()
        {
            AbstractLamp? lamp = Lamps[0];

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Brightness < lamp.Brightness)
                    lamp = l;
            }

            return lamp;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();

            foreach(AbstractLamp l in Lamps)
            {
                if (l.Brightness >= min && l.Brightness <= max)
                    lamps.Add(l);
            }

            return lamps;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();

            foreach(AbstractLamp l in Lamps)
            {
                if (l.Status == DeviceStatus.On)
                    lamps.Add(l);
            }
            
            return lamps;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();

            foreach (AbstractLamp l in Lamps)
            {
                if (l.Status == DeviceStatus.Off)
                    lamps.Add(l);
            }

            return lamps;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            AbstractLamp? lamp = Lamps[0];

            foreach(AbstractLamp l in Lamps)
            {
                if (l.Id == id)
                    lamp = l;
            }

            return lamp;
         
        }

        public List<AbstractLamp> SortByIntensity(bool descending)
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();

            if (!descending)
            {
                foreach (AbstractLamp l in Lamps)
                {
                    int count = 0;
                    while (lamps.Contains(l) == false)
                    {
                        if (count == lamps.Count)
                            lamps.Add(l);
                        else if (l.Brightness <= lamps[count].Brightness)
                            lamps.Insert(count, l);

                        count++;
                    }

                }
            }
            else
            {
                foreach (AbstractLamp l in Lamps)
                {
                    int count = 0;
                    while (lamps.Contains(l) == false)
                    {
                        if (count == lamps.Count)
                            lamps.Add(l);
                        else if (l.Brightness >= lamps[count].Brightness)
                            lamps.Insert(count, l);

                        count++;
                    }
                }
            }

            return lamps;
        }



        

        





    }
}
