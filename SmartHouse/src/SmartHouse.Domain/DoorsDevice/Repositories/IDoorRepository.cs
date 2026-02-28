using SmartHouse.Domain.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.DoorsDevice.Repositories
{
    public interface IDoorRepository
    {
        void Add(Door newDoor);
        void Update(Door newDoor);
        void Delete(Guid id);
        Door GetById(Guid id);
        List<Door> GetAll();
    }
}
