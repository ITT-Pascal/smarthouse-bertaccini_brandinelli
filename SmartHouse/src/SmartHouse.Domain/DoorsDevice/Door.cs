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
        public Pin PIN { get; set; }
        public bool IsLocked { get; private set; }
        public bool IsOpen { get; private set; }      

        public Door(string name, int pin): base(name)
        {          
            PIN = Pin.Create(pin);
            IsOpen = false;
            IsLocked = true;           
        }       

        public void Open()
        {
            if (Status == DeviceStatus.On)
            {
                if (IsOpen == false && IsLocked == false)
                {
                    IsOpen = true;
                    LastUpdateTime = DateTime.UtcNow;
                }
                else if (IsLocked == true)
                    throw new ArgumentException("The door must be unlocked before being opened");
                else
                    throw new ArgumentException("The door must be closed before being opened");
            }
        }

        public void Close()
        {
            if (Status == DeviceStatus.On)
            {
                if (IsOpen == true)
                {
                    IsOpen = false;
                    LastUpdateTime = DateTime.UtcNow;
                }
                else
                    throw new ArgumentException("The door must be open before being closed");
            }
        }

        public void Lock()
        {
            if (Status == DeviceStatus.On)
            {
                if (IsOpen == false && IsLocked == false)
                {
                    IsLocked = true;
                    LastUpdateTime = DateTime.UtcNow;
                }
                else
                    throw new ArgumentException("The door must be closed before being locked");
            }

        }

        public void Unlock(Pin pin)
        {
            if (Status == DeviceStatus.On)
            {
                if (IsLocked == true)
                {
                    if (PIN == pin)
                    {
                        IsLocked = false;
                        LastUpdateTime = DateTime.UtcNow;
                    }
                    else
                        throw new ArgumentException("The wrong pin was entered");
                }
                else
                    throw new ArgumentException("The door must be locked before being unlocked");
            }
        }

        public void ChangePIN(int currentPin, int newPin)
        {
            if (Status == DeviceStatus.On)
            {
                if (!IsLocked)
                {
                    if (Pin.Create(currentPin) == PIN)
                    {
                        if (PIN == newPin)
                            throw new ArgumentException("The PIN cannot be the same");

                        PIN = Pin.Create(newPin);
                    }
                    else
                        throw new ArgumentException("Current PIN is wrong");
                }
            }
        }
    }
}
