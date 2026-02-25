using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.ThermostatDevice.Dto;
using SmartHouse.Domain.TemperatureDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Mapper
{
    public class ThermostatMapper
    {
        public static ThermostatDto ToDto(Thermostat thermostat)
        {
            return new ThermostatDto
            {
                Id = thermostat.Id,
                Name = thermostat.Name._name,
                Status = DeviceStatusMapper.ToDto(thermostat.Status),
                CreationTime = thermostat.CreationTime,
                LastUpdateTime = thermostat.LastUpdateTime,
                Temperature = thermostat.Temperature._temp,
            };
        }

        public static Thermostat ToDomain(ThermostatDto dto)
        {
            return new Thermostat(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.Temperature,
                dto.CreationTime,
                dto.LastUpdateTime
                );
        }
    }
}
