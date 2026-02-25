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
    public class InMemoryLampRepository : IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryLampRepository()
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

            foreach (Door l in _doors)
                if (l.Id == id)
                    result = l;

            return result;
        }

        public void Add(Door lamp)
        {
            if (lamp != null)
                _doors.Add(lamp);
            else
                throw new ArgumentException("lamp cannot be null");
        }

        public void Delete(Guid id)
        {
            var lamp = GetById(id);

            if (lamp != null)
                _doors.Remove(lamp);
        }

        public void Update(Door lamp)
        {
            //To do
        }
    }
}
