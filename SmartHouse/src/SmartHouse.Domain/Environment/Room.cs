using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Environment
{
    public class Room
    {
        public List<AbstractDevice> Devices { get; private set; }
        public Name Name { get; }
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public Room(string name)
        {
            Name = Name.Create(name);
            Devices = new List<AbstractDevice>();
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void AddDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Add(device);
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void AddDeviceInPosition(AbstractDevice device, int position)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.Insert(position, device);
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void RemoveDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Remove(device);
            LastUpdatedAt = DateTime.UtcNow;
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
            LastUpdatedAt = DateTime.UtcNow;
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
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void RemoveDeviceInPosition(int position)
        {
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.RemoveAt(position);
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOn(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOn();
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOn(Name name)
        {
            if (name == null)
                throw new ArgumentException("Name cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                    Devices[i].SwitchOn();
            }
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOn(Guid id)
        {
            if (id == null)
                throw new ArgumentException("Id cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                    Devices[i].SwitchOn();
            }
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOff(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOff();
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOff(Name name)
        {
            if (name == null)
                throw new ArgumentException("Name cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == name)
                    Devices[i].SwitchOff();
            }
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void SwitchOff(Guid id)
        {
            if (id == null)
                throw new ArgumentException("Id cannot be null");

            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
                    Devices[i].SwitchOff();
            }
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void AllSwitchOn()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOn();
            }
            LastUpdatedAt = DateTime.UtcNow;
        }

        public void AllSwitchOff()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOff();
            }
            LastUpdatedAt = DateTime.UtcNow;
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
