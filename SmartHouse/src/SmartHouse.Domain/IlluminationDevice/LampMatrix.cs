using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice
{
    public class LampMatrix
    {
        public AbstractLamp[,] Lamps { get; private set; }
        public string Name { get; private set; }

        public LampMatrix(string name, AbstractLamp[,] lamps)
        {           
            Lamps = lamps;
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is not valid");
            Name = name;
        }
        
        public void AddLamp(AbstractLamp lamp)
        {
            int count = 0;
            foreach(AbstractLamp i in Lamps)
            {
                if(i != null)
                {
                    count++;   
                }
            }

            if (count == Lamps.Length)
                throw new ArgumentException("The matrix of lamps is alredy full");

            bool flag = false;
            for(int r = 0; r<Lamps.GetLength(0) && !flag; r++)
            {
                for(int c = 0; c<Lamps.GetLength(1) && !flag; c++)
                {
                    if (Lamps[r,c] == null)
                    {
                        Lamps[r, c] = lamp;
                        flag = true;
                    }
                }
            }
        }

        public void AddLampInPosition(AbstractLamp lamp, int row, int column)
        {
            int count = 0;
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    count++;
                }
            }

            if (count == Lamps.Length)
                throw new ArgumentException("The matrix of lamps is alredy full");

            if (Lamps[row, column] != null)
                throw new ArgumentException("The place where the lamp is to be placed is alredy occupied");

            Lamps[row, column] = lamp;
        }

        public void RemoveLamp(string name)
        {
            for(int r = 0; r<Lamps.GetLength(0); r++)
            {
                for(int c = 0; c<Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)
                    {
                        if (Lamps[r, c].Name == name)
                        {
                            Lamps[r, c] = null;
                        }
                    }
                }
            }
        }

        public void RemoveLamp(Guid id)
        {
            for (int r = 0; r < Lamps.GetLength(0); r++)
            {
                for (int c = 0; c < Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)
                    {
                        if (Lamps[r, c].Id == id)
                        {
                            Lamps[r, c] = null;
                        }
                    }
                }
            }
        }

        public void RemoveLampInPosition(int row, int column)
        {
            Lamps[row, column] = null;
        }

        public void SwitchOn(string name)
        {
            foreach(AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    if (i.Name == name)
                        i.SwitchOn();
                }
            }
        }

        public void SwitchOn(Guid id)
        {
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    if (i.Id == id)
                        i.SwitchOn();
                }
            }
        }

        public void SwitchOff(string name)
        {
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    if (i.Name == name)
                        i.SwitchOff();
                }
            }
        }

        public void SwitchOff(Guid id)
        {
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    if (i.Id == id)
                        i.SwitchOff();
                }
            }
        }

        public void AllSwitchOn()
        {
            foreach(AbstractLamp i in Lamps) 
            {
                if (i != null)
                    i.SwitchOn();
            }
        }
        public void AllSwitchOff()
        {
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                    i.SwitchOff();
            }
        }

        public void AllLampsSwitchOnOff()
        {
            foreach (AbstractLamp i in Lamps)
            {
                if (i != null)
                    i.SwitchOnOff();
            }
        }

        public void SingleLampSwitchOnOff(string name)
        {
            foreach(AbstractLamp i in Lamps)
            {
                if (i != null)
                {
                    if (i.Name == name)
                        i.SwitchOnOff();
                }
            }
        }

        public void AllLampsChangeBrightness(int newbrightness)
        {
            foreach(AbstractLamp lamp in Lamps)
            {
                if (lamp != null)
                    lamp.ChangeBrightness(newbrightness);
            }
        }

        public void SingleLampChangeBrightness(int newbrightness, string name)
        {
            foreach(AbstractLamp lamp in Lamps)
            {
                if (lamp != null)
                {
                    if (lamp.Name == name)
                        lamp.ChangeBrightness(newbrightness);
                }
            }
        }

        public void SingleLampChangeBrightness(int newbrightness, Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp != null)
                {
                    if (lamp.Id == id)
                        lamp.ChangeBrightness(newbrightness);
                }
            }
        }

        public AbstractLamp? FindLampWithMaxBrightness()
        {
            AbstractLamp? lamp = Lamps[0, 0];

            foreach(AbstractLamp l in Lamps)
            {
                if (l != null)
                {
                    if (l.Brightness > lamp.Brightness)
                        lamp = l;
                }
            }

            return lamp;
        }

        public AbstractLamp? FindLampWithMinBrightness()
        {
            AbstractLamp? lamp = Lamps[0, 0];

            foreach (AbstractLamp l in Lamps)
            {
                if (l != null)
                {
                    if (l.Brightness < lamp.Brightness)
                        lamp = l;
                }
            }

            return lamp;
        }

        public AbstractLamp[,] FindLampByIntensityRange(int min, int max)
        {
            AbstractLamp[,] lamps = new AbstractLamp[Lamps.GetLength(0) , Lamps.GetLength(1)];

            for(int r = 0; r<Lamps.GetLength(0); r++)
            {
                for(int c = 0; c<Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)
                        if (Lamps[r, c].Brightness >= min && Lamps[r, c].Brightness <= max)
                            lamps[r, c] = Lamps[r, c];
                }
            }

            return lamps;
        }

        public AbstractLamp[,] FindAllOn()
        {
            AbstractLamp[,] lamps = new AbstractLamp[Lamps.GetLength(0), Lamps.GetLength(1)];

            for (int r = 0; r < Lamps.GetLength(0); r++)
            {
                for (int c = 0; c < Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)    
                        if (Lamps[r, c].Status == DeviceStatus.On)
                            lamps[r, c] = Lamps[r, c];
                }
            }

            return lamps;
        }

        public AbstractLamp[,] FindAllOff()
        {
            AbstractLamp[,] lamps = new AbstractLamp[Lamps.GetLength(0), Lamps.GetLength(1)];

            for (int r = 0; r < Lamps.GetLength(0); r++)
            {
                for (int c = 0; c < Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)
                        if (Lamps[r, c].Status == DeviceStatus.Off)
                            lamps[r, c] = Lamps[r, c];
                }
            }

            return lamps;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            AbstractLamp? lamp = Lamps[0,0];

            for (int r = 0; r < Lamps.GetLength(0); r++)
            {
                for (int c = 0; c < Lamps.GetLength(1); c++)
                {
                    if (Lamps[r,c] != null)
                        if (Lamps[r, c].Id == id)
                            lamp = Lamps[r, c];
                }
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
                    if (l != null)
                    {
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
            }
            else
            {
                foreach (AbstractLamp l in Lamps)
                {
                    int count = 0;
                    if (l != null)
                    {
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
            }

            return lamps;
        }
    }
}
