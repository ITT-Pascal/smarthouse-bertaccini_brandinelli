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
    public class ThermostatCheckTemperatureIsMinQuery
    {
        private readonly IThermostatRepository _repository;

        public ThermostatCheckTemperatureIsMinQuery(IThermostatRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            Temperature temp = ThermostatMapper.ToDomain(new ThermostatGetByIdQuery(_repository).Execute(id)).Temperature;
            if (temp == new Thermostat("Check").MinTemperature)
                return true;
            return false;
        }
    }
}
