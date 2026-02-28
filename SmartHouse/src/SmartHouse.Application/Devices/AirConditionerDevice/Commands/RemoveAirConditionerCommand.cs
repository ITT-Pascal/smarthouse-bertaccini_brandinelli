using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Commands
{
    public class RemoveAirConditionerCommand
    {
        private readonly IAirConditionerRepository _airconditionerrepository;

        public RemoveAirConditionerCommand(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public void Execute(Guid id)
        {
            AirConditioner airconditioner = _airconditionerrepository.GetById(id);
            if(airconditioner != null)
            {
                _airconditionerrepository.Delete(id);
                _airconditionerrepository.Update(airconditioner);
            }
        }
    }
}
