using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Queries
{
    public class ThermostatGetByIdQuery
    {
        private readonly IThermostatRepository _thermostatRepository;

        public ThermostatGetByIdQuery(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public Thermostat Execute(Guid id)
        {
            return _thermostatRepository.GetById(id);
        }
    }
}
