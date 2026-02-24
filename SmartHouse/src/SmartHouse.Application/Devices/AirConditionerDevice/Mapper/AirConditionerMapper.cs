using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.AirConditionerDevice.Dto;
using SmartHouse.Domain.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Mapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner airConditioner)
        {
            return new AirConditionerDto
            {
                Id = airConditioner.Id,
                Name = airConditioner.Name._name,
                Status = DeviceStatusMapper.ToDto(airConditioner.Status),
                CreationTime = airConditioner.CreationTime,
                LastUpdateTime = airConditioner.LastUpdateTime,
                FanSpeed = FanSpeedMapper.ToDto(airConditioner.FanSpeed),
            };
        }

        public static AirConditioner ToDomain(AirConditionerDto dto)
        {
            return new AirConditioner(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                FanSpeedMapper.ToDomain(dto.FanSpeed),
                dto.CreationTime,
                dto.LastUpdateTime
                );
        }
    }
}
