using SmartHouse.Domain.AirConditionerDevice.Repositories;
using SmartHouse.Domain.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Commands
{
    public class AddAirConditionerCommand
    {
        private IAirConditionerRepository _airconditionerrepository;

        public AddAirConditionerCommand(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public void Execute(string name)
        {
            _airconditionerrepository.Add(new AirConditioner(name));
        }
    }
}
