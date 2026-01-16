using System;
using SmartHouse.Domain.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Doors
{
    public class Door: AbstractDevice
    {
        public int PIN { get; set; }
        public DoorStatus DoorStatus { get; set; }

        public Door(string name, int pin): base(name)
        {
            if (pin < 4)
                throw new ArgumentException("PIN must have at least 4 digits");
            else
                PIN = pin;
            DoorStatus = DoorStatus.Closed;
            Status = DeviceStatus.Unknown;
        }

        public override void SwitchOn() { }
        public override void SwitchOff() { }

        public void Open()
        {
            if (DoorStatus == DoorStatus.Closed)
                DoorStatus = DoorStatus.Open;
            else if (DoorStatus == DoorStatus.Locked)
                throw new ArgumentException("The door must be unlocked before being opened");
            else
                throw new ArgumentException("The door must be closed before being opened");
        }

        public void Close()
        {
            if (DoorStatus == DoorStatus.Open)
                DoorStatus = DoorStatus.Closed;
            else
                throw new ArgumentException("The door must be open before being closed");
        }

        public void Lock()
        {
            if (DoorStatus == DoorStatus.Closed)
                DoorStatus = DoorStatus.Locked;
            else
                throw new ArgumentException("The door must be closed before being locked");

        }

        public void Unlock(int pin)
        {
            if (PIN == pin)
            {
                if (DoorStatus == DoorStatus.Locked)
                    DoorStatus = DoorStatus.Closed;
                else
                    throw new ArgumentException("The door must be locked before being unlocked");
            }
            else
                throw new ArgumentException("The wrong PIN was entered. Please try again");
        }

    }
}
