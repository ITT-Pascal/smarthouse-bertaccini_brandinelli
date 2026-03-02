using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Environment.Repositories;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class SwitchOnRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public SwitchOnRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                room.SwitchOn(roomId);
                _roomRepository.Update(room);
            }
        }
    }
}
