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
        public List<AbstractDevice> Devices { get; set; }
        public Name Name { get; set; }

        public Room(string name)
        {
            Name = Name.Create(name);
            Devices = new List<AbstractDevice>();
        }

        public void AddDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Add(device);
        }

        public void AddDeviceInPosition(AbstractDevice device, int position)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.Insert(position, device);
        }

        public void RemoveDevice(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            Devices.Remove(device);
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
        }

        public void RemoveDeviceInPosition(int position)
        {
            if (position < 0)
                throw new ArgumentException("Position cannot be negative");

            Devices.RemoveAt(position);
        }

        public void SwitchOn(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOn();
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
        }

        public void SwitchOff(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOff();
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
        }

        public void AllSwitchOn()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOn();
            }
        }

        public void AllSwitchOff()
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                Devices[i].SwitchOff();
            }
        }

        public void AllIncreaseFanSpeed()
        {
            for(int i=0;i<Devices.Count;i++)
            {
                if (Devices[i] is AirConditioner)
                {
                    AirConditioner Device = (AirConditioner)Devices[i];
                    Device.IncreaseFanSpeed();
                }
            }
        }
    }
}
