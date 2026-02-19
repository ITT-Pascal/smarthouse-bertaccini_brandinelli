using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class UnlockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public UnlockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id, int pin)
        {
            Door door = _doorRepository.GetById(id);
            if (door != null)
            {
                door.Unlock(Pin.Create(pin));
                _doorRepository.Update(door);
            }
        }
    }
}
