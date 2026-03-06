using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Environment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class RemoveRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public RemoveRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Guid roomId)
        {
            Room room = _roomRepository.GetById(roomId);
            if (room != null)
            {
                _roomRepository.Delete(roomId);
                _roomRepository.Update(room);
            }
        }
    }
}
