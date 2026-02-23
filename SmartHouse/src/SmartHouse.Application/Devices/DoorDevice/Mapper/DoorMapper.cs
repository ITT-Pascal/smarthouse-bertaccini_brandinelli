using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.Illumination.Lamps.Dto;
using SmartHouse.Domain;
using SmartHouse.Domain.Abstractions;
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
        

        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name._name,
                Status = DeviceStatusMapper.ToDto(door.Status),
                CreationTime = door.CreationTime,
                LastUpdateTime = door.LastUpdateTime,
                Pin = door.PIN.PIN,
                IsLocked = door.IsLocked,
                IsOpen = door.IsOpen
            };
        }

        public static Door ToDomain(DoorDto dto)
        {
            return new Door(
                Name.Create(dto.Name),
                Pin.Create(dto.Pin),
                dto.IsLocked,
                dto.IsOpen,
                dto.Id,
                DeviceStatusMapper.ToDomain(dto.Status),
                dto.CreationTime,
                dto.LastUpdateTime
                );                             
        }
    }
}
