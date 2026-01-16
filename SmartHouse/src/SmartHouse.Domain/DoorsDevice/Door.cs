using System;
using SmartHouse.Domain.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.DoorsDevice;

namespace SmartHouse.Domain.Doors
{
    public sealed class Door: AbstractDevice, ILockable, IOpenable
    {
        public int PIN { get; set; }
        public bool IsLocked { get; private set; }
        public bool IsOpen { get; private set; }

        public Door(string name, int pin): base(name)
        {
            if (pin < 4)
                throw new ArgumentException("PIN must have at least 4 digits");
            else
                PIN = pin;
            IsOpen = false;
            IsLocked = true;
            Status = DeviceStatus.Unknown;
        }       

        public void Open()
        {
            if (IsOpen == false && IsLocked == false)
                IsOpen = true;
            else if (IsLocked == true)
                throw new ArgumentException("The door must be unlocked before being opened");
            else
                throw new ArgumentException("The door must be closed before being opened");
        }

        public void Close()
        {
            if (IsOpen == true)
                IsOpen = false;
            else
                throw new ArgumentException("The door must be open before being closed");
        }

        public void Lock()
        {
            if (IsOpen == false && IsLocked == false)
                IsLocked = true;
            else
                throw new ArgumentException("The door must be closed before being locked");

        }

        public void Unlock(int pin)
        {
            if (IsLocked == true)
            {
                if (PIN == pin)
                    IsLocked = false;
                else
                    throw new ArgumentException("The wrong pin was entered");
            }
            else
                throw new ArgumentException("The door must be locked before being unlocked");
        }

    }
}
