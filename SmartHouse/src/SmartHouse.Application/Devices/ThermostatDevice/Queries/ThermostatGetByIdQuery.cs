using SmartHouse.Application.Devices.ThermostatDevice.Dto;
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
    public class ThermostatGetByIdQuery
    {
        private readonly IThermostatRepository _thermostatRepository;

        public ThermostatGetByIdQuery(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public ThermostatDto Execute(Guid id)
        {
            return ThermostatMapper.ToDto(_thermostatRepository.GetById(id));
        }
    }
}
