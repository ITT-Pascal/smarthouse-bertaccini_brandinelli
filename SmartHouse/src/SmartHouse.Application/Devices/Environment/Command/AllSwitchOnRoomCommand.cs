using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Environment.Repositories;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class AllSwitchOnRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public AllSwitchOnRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                room.AllSwitchOn();
                _roomRepository.Update(room);
            }
        }
    }
}
