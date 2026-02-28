using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Domain.Environment
{
    public class Room
    {
        public List<AbstractDevice> Devices { get; private set; }
        public Name Name { get; }
        public Guid Id { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdateTime { get; private set; }

        public Room(string name)
        {
            Name = Name.Create(name);
            Devices = new List<AbstractDevice>();
            Id = Guid.NewGuid();
            CreationTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
        }

        public Room(Guid id, string name, List<Object> devices, DateTime creationtime, DateTime lastupdatetime)
        {
            Id = id;
            Name = Name.Create(name);
            Devices = devices;
            CreationTime = creationtime;
            LastUpdateTime = lastupdatetime;
        }

        public void AddDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Add(device);
            LastUpdateTime = DateTime.UtcNow;
        }

        public void AddDeviceInPosition(AbstractDevice device, int position)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.Insert(position, device);
            LastUpdateTime = DateTime.UtcNow;
        }

        public void RemoveDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Remove(device);
            LastUpdateTime = DateTime.UtcNow;
        }

        public void RemoveDevice(Name name)
        {
            if (name == null)
                throw new ArgumentException("Name cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                {
                    Devices.RemoveAt(i);
                }
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void RemoveDevice(Guid id)
        {
            if (id == null)
                throw new ArgumentException("Id cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                {
                    Devices.RemoveAt(i);
                }
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void RemoveDeviceInPosition(int position)
        {
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.RemoveAt(position);
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOn(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOn();
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOn(Name name)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                    Devices[i].SwitchOn();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOn(Guid id)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                    Devices[i].SwitchOn();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOff(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOff();
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOff(Name name)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                    Devices[i].SwitchOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOff(Guid id)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                    Devices[i].SwitchOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void AllSwitchOn()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOn();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void AllSwitchOff()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOnOff(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device does not exist");

            device.SwitchOnOff();
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOnOff(Name name)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                    Devices[i].SwitchOnOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SwitchOnOff(Guid id)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                    Devices[i].SwitchOnOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        public void AllSwitchOnOff()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOnOff();
            }
            LastUpdateTime = DateTime.UtcNow;
        }

        //public void AllIncreaseFanSpeed()
        //{
        //    for(int i=0;i<Devices.Count;i++)
        //    {
        //        if (Devices[i] is AirConditioner)
        //        {
        //            AirConditioner Device = (AirConditioner)Devices[i];
        //            Device.IncreaseFanSpeed();
        //        }
        //    }
        //}
    }
}
