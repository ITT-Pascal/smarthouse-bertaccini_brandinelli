using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Environment.Repositories;
using SmartHouse.Domain.Environment;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class SwitchOnOffRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public SwitchOnOffRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                room.SwitchOnOff(roomId);
                _roomRepository.Update(room);
            }
        }
    }
}
