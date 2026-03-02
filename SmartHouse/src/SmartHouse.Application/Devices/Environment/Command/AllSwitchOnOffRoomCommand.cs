using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Environment.Repositories;
using SmartHouse.Domain.Environment;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class AllSwitchOnOffRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public AllSwitchOnOffRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                room.AllSwitchOnOff();
                _roomRepository.Update(room);
            }
        }
    }
}
