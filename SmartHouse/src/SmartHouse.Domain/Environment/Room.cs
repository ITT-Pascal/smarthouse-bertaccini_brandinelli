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
            Devices.Insert(position, device);
        }

        public void RemoveDevice(AbstractDevice device)
        {
            Devices.Remove(device);
        }
        
        public void RemoveDevice(Guid id)
        {
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
            Devices.RemoveAt(position);
        }

        public void SwitchOn(AbstractDevice device)
        {
            if (device == null)
                throw new ArgumentException("Device cannot be null");

            device.SwitchOn();
        }

        public void SwitchOn(Guid id)
        {
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

        public void SwitchOff(Guid id)
        {
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Id == id)
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
