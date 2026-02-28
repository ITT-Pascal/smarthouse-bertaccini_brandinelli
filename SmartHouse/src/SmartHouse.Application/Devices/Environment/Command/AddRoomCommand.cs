using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Environment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Command
{
    public class AddRoomCommand
    {
        private readonly IRoomRepository _roomRepository;

        public AddRoomCommand(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(string roomName)
        {
            _roomRepository.Add(new Room(roomName));
        }
    }
}
