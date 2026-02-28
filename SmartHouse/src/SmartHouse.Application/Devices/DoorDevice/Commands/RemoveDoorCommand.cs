using SmartHouse.Domain.Doors;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class RemoveDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public RemoveDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id)
        {
            Door door = _doorRepository.GetById(id);
            if (door != null)
            {
                _doorRepository.Delete(id);
                _doorRepository.Update(door);
            }
        }
    }
}
