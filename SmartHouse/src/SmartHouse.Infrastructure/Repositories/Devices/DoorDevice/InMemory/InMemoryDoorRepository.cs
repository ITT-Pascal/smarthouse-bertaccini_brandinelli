using SmartHouse.Domain.Doors;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Infrastructure.Repositories.Devices.DoorDevice.InMemory
{
    public class InMemoryDoorRepository : IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors = new List<Door>
            {
                new Door("Stefano", 1234),
                new Door("Pasquale", 4321),
                new Door("Giovanni", 2143)
            };
        }

        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door? GetById(Guid id)
        {
            Door? result = null;

            foreach (Door d in _doors)
                if (d.Id == id)
                    result = d;

            return result;
        }

        public void Add(Door door)
        {
            if (door != null)
                _doors.Add(door);
            else
                throw new ArgumentException("Door cannot be null");
        }

        public void Delete(Guid id)
        {
            var door = GetById(id);

            if (door != null)
                _doors.Remove(door);
        }

        public void Update(Door door)
        {
            //To do
        }
    }
}
