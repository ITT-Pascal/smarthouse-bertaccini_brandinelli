using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Dto;
using SmartHouse.Domain;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Mapper
{
    public class LampMapper
    {
        

        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name._name,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                Brightness = lamp.Brightness._brightness,
                CreationTime = lamp.CreationTime,
                LastUpdateTime = lamp.LastUpdateTime,
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                Brightness.Create(dto.Brightness,0,100),
                dto.CreationTime,
                dto.LastUpdateTime
                );                             
        }
    }
}
