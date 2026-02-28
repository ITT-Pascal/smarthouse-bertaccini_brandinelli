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
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(string name, int pin)
        {
            _doorRepository.Add(new Door(name, pin));
        }
    }
}
