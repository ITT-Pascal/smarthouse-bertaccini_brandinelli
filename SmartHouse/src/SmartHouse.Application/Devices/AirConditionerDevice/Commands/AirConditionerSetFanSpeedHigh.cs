using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Commands
{
    public class AirConditionerSetFanSpeedHigh
    {
        private readonly IAirConditionerRepository _airconditionerrepository;

        public AirConditionerSetFanSpeedHigh(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public void Execute(Guid id)
        {
            AirConditioner a = _airconditionerrepository.GetById(id);
            if (a != null)
            {
                a.SetFanSpeedHigh();
                _airconditionerrepository.Update(a);
            }
        }
    }
}
