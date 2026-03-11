using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Commands
{
    public class AirConditionerSwitchOffCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerSwitchOffCommand(IAirConditionerRepository repos)
        {
            _repository = repos;
        }

        public void Execute(Guid id)
        {
            var ac = _repository.GetById(id);
            if (ac != null)
            {
                ac.SwitchOff();
                _repository.Update(ac);
            }
        }
    }
}
