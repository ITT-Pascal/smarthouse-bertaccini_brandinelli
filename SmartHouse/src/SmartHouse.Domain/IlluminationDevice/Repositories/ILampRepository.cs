using SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice.Repositories
{
    public interface ILampRepository
    {
        void Create(Lamp newLamp);
        void Update(Lamp newLamp);
        void Delete(Guid id);
        Lamp GetById(Guid id);
        List<Lamp> GetAll();
    }
}
