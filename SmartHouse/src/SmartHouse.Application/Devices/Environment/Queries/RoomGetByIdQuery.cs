using SmartHouse.Application.Devices.Environment.Dto;
using SmartHouse.Application.Devices.Environment.Mapper;
using SmartHouse.Domain.Environment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Queries
{
    public class RoomGetByIdQuery
    {
        private readonly IRoomRepository _roomRepository;

        public RoomGetByIdQuery(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomDto Execute(Guid id)
        {
            return RoomMapper.ToDto(_roomRepository.GetById(id));
        }
    }
}
