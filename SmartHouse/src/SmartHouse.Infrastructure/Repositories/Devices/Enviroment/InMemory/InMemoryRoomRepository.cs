using SmartHouse.Domain.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Infrastructure.Repositories.Devices.Enviroment.InMemory
{
    public class InMemoryRoomRepository
    {
        private readonly List<Room> _rooms;

        public InMemoryRoomRepository()
        {
            _rooms = new List<Room>
            {
                new Room("Stefano"),
                new Room("Pasquale"),
                new Room("Giovanni")
            };
        }

        public List<Room> GetAll()
        {
            return _rooms;
        }

        public Room GetById(Guid id)
        {
            return _rooms.FirstOrDefault(room => room.Id == id);
        }

        public void Add(Room room)
        {
            if (room != null)
                _rooms.Add(room);
            else
                throw new ArgumentException("Lamp cannot be null");
        }

        public void Delete(Guid id)
        {
            var room = GetById(id);

            if (room != null)
                _rooms.Remove(room);
        }

        public void Update(Room room)
        {
            //To do
        }
    }
}
