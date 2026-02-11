using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.AirConditionerDevice
{
    public interface IAirConditionerRepository
    {
        void Create(AirConditioner newAc);
        void Update(AirConditioner newAc);
        void Delete(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
