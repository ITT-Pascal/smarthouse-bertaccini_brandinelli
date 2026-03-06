using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class DoorSwitchOnCommand
    {
        private readonly IDoorRepository _repository;
        public DoorSwitchOnCommand(IDoorRepository repos)
        {
            _repository = repos;
        }

        public void Execute(Guid id)
        {
            var door = _repository.GetById(id);
            if(door != null)
            {
                door.SwitchOn();
                _repository.Update(door);
            }
        }
    }
}
