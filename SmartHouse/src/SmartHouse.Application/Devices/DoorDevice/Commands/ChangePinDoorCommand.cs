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
    public class ChangePinDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public ChangePinDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid id, int currentPin, int newPin)
        {
            Door door = _doorRepository.GetById(id);
            if (door != null)
            {
                door.ChangePIN(currentPin, newPin);
                _doorRepository.Update(door);
            }
        }
    }
}
