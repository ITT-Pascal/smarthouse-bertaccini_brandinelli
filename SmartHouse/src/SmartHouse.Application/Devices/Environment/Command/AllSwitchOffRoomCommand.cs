using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Environment.Repositories;
using SmartHouse.Domain.Environment;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class AllSwitchOffRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public AllSwitchOffRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                room.AllSwitchOff();
                _roomRepository.Update(room);
            }
        }
    }
}
