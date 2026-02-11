using SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.ThermostastDevice
{
    public interface IThermostatRepository
    {
        void Create(Thermostat newThermostat);
        void Update(Thermostat newThermostat);
        void Delete(Guid id);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
