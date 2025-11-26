using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Doors
{
    public class Door
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PIN { get; set; }
        public DoorStatus Status { get; set; }

        public Door(string name, int pin)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name isn't valid");
            else
                Name = name;
            if (pin < 4)
                throw new ArgumentException("PIN must have at least 4 digits");
            else
                PIN = pin;
            Status = DoorStatus.Closed;
        }

        public void OpenDoor()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Open;
            else if (Status == DoorStatus.Locked)
                throw new ArgumentException("The door must be unlocked before being opened");
            else
                throw new ArgumentException("The door must be closed before being opened");
        }

        public void CloseDoor()
        {
            if (Status == DoorStatus.Open)
                Status = DoorStatus.Closed;
            else
                throw new ArgumentException("The door must be open before being closed");
        }

        public void LockDoor()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Locked;
            else
                throw new ArgumentException("The door must be closed before being locked");

        }

        public void UnlockDoor(int pin)
        {
            if (PIN == pin)
            {
                if (Status == DoorStatus.Locked)
                    Status = DoorStatus.Closed;
                else
                    throw new ArgumentException("The door must be locked before being unlocked");
            }
            else
                throw new ArgumentException("The wrong PIN was entered. Please try again");
        }

    }
}
