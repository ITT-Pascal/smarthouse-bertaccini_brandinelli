using SmartHouse.Application.Devices.Environment.Dto;
using SmartHouse.Domain.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Mapper
{
    public class RoomMapper
    {
        public static RoomDto ToDto(Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Name = room.Name._name,
                Devices = ,
                CreationTime = room.CreationTime,
                LastUpdateTime = room.LastUpdateTime,               
            };
        }

        public static Room ToDomain(RoomDto dto)
        {
            return new Room(
                dto.Id,
                dto.Name,
                dto.Devices,
                dto.CreationTime,
                dto.LastUpdateTime
            );    
        }
    }
}
