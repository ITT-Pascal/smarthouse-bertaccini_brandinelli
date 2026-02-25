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
    public class ThermostatGetAllQuery
    {
        private readonly IThermostatRepository _repository;

        public ThermostatGetAllQuery(IThermostatRepository repos)
        {
            _repository = repos;
        }

        public List<ThermostatDto> Execute()
        {
            List<ThermostatDto> result = new List<ThermostatDto>();

            foreach(Thermostat t in _repository.GetAll())
            {
                if (t != null)
                    result.Add(ThermostatMapper.ToDto(t));
            }
            return result;
        }
    }
}
