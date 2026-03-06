using SmartHouse.Application.Devices.ThermostatDevice.Mapper;
using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Queries
{
    public class ThermostatCheckTemperatureIsMaxQuery
    {
        private readonly IThermostatRepository _repository;

        public ThermostatCheckTemperatureIsMaxQuery(IThermostatRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            Temperature temp = ThermostatMapper.ToDomain(new ThermostatGetByIdQuery(_repository).Execute(id)).Temperature;
            if (temp == new Thermostat("Check").MaxTemperature)
                return true;
            return false;
        }
    }
}
