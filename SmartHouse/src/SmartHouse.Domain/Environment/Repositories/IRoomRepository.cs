using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Environment.Repositories
{
    public interface IRoomRepository
    {
        void Add(Room newRoom);
        void Update(Room newRoom);
        void Delete(Guid id);
        Room GetById(Guid id);
        List<Room> GetAll();
    }
}
