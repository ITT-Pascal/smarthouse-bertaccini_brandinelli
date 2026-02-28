using SmartHouse.Application.Devices.Environment.Dto;
using SmartHouse.Domain.Abstractions;
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
            List<Object> objects = new List<Object>();
            foreach(AbstractDevice abstractDevice in room.Devices)
            {
                objects.Add((Object)abstractDevice);
            }
            return new RoomDto
            {
                Id = room.Id,
                Name = room.Name._name,
                Devices = objects,
                CreationTime = room.CreationTime,
                LastUpdateTime = room.LastUpdateTime,               
            };
        }

        public static Room ToDomain(RoomDto dto)
        {
            List<AbstractDevice> abstractDevices = new List<AbstractDevice>();
            foreach(Object obj in dto.Devices)
            {
                abstractDevices.Add((AbstractDevice)obj);
            }
            return new Room(
                dto.Id,
                dto.Name,
                abstractDevices,
                dto.CreationTime,
                dto.LastUpdateTime
            );    
        }
    }
}
