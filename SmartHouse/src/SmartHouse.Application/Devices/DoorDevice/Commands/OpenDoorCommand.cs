using SmartHouse.Domain.DoorsDevice.Repositories;
using SmartHouse.Domain.DoorsDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Doors;

namespace SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public OpenDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            Door door = _doorRepository.GetById(id);
            if (door != null)
            {
                door.Open();
                _doorRepository.Update(door);
            }
        }
    }
}
