using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Doors
{
    public class Door
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DoorStatus Status { get; set; }

        public Door(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DoorStatus.Closed;
        }

        public void OpenDoor()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Open;
        }

        public void CloseDoor()
        {
            if (Status == DoorStatus.Open)
                Status = DoorStatus.Closed;
        }

        public void LockDoor()
        {
            if (Status == DoorStatus.Closed)
                Status = DoorStatus.Locked;

        }

        public void UnlockDoor()
        {
            if (Status == DoorStatus.Locked)
                Status = DoorStatus.Closed;
        }

    }
}
