using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Dto;
using SmartHouse.Domain;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Mapper
{
    public class DoorMapper
    {
        

        public static DoorDto ToDto(Lamp lamp)
        {
            return new DoorDto
            {
                Id = lamp.Id,
                Name = lamp.Name._name,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                CreationTime = lamp.CreationTime,
                LastUpdateTime = lamp.LastUpdateTime,
            };
        }

        public static Lamp ToDomain(DoorDto dto)
        {
            return new Door(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.CreationTime,
                dto.LastUpdateTime
                );                             
        }
    }
}
