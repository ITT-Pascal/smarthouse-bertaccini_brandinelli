using SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.TemperatureDevice.Repositories
{
    public interface IThermostatRepository
    {
        void Add(Thermostat newThermostat);
        void Update(Thermostat newThermostat);
        void Delete(Guid id);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
        void Add(SmartHouse.Application.Devices.Thermostat thermostat);
    }
}
