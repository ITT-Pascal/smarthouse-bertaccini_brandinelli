using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class DoorSwitchOffCommand
    {
        private readonly IDoorRepository _repository;
        public DoorSwitchOffCommand(IDoorRepository repos)
        {
            _repository = repos;
        }

        public void Execute(Guid id)
        {
            var door = _repository.GetById(id);
            if (door != null)
            {
                door.SwitchOff();
                _repository.Update(door);
            }
        }
    }
}
