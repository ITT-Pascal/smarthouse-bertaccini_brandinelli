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
    public sealed class Door: ILockable, IOpenable
    {
        public Pin PIN { get; set; }
        public bool IsLocked { get; private set; }
        public bool IsOpen { get; private set; }
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdateTime { get; private set; }

        public Door(string name, int pin)
        {
            Id = Guid.NewGuid();
            PIN = Pin.Create(pin);
            IsOpen = false;
            IsLocked = true;
            Name = Name.Create(name);
            CreationTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
        }       

        public void Open()
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

        public void Close()
        {
            if (IsOpen == true)
            {
                IsOpen = false;
                LastUpdateTime = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("The door must be open before being closed");
        }

        public void Lock()
        {
            if (IsOpen == false && IsLocked == false)
            {
                IsLocked = true;
                LastUpdateTime = DateTime.UtcNow;
            }
            else
                throw new ArgumentException("The door must be closed before being locked");

        }

        public void Unlock(Pin pin)
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
}
