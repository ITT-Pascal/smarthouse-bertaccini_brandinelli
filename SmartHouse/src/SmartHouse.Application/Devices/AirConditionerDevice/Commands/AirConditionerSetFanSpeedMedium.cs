using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Commands
{
    public class AirConditionerSetFanSpeedMedium
    {
        private readonly IAirConditionerRepository _airconditionerrepository;

        public AirConditionerSetFanSpeedMedium(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public void Execute(Guid id)
        {
            AirConditioner a = _airconditionerrepository.GetById(id);
            if (a != null)
            {
                a.SetFanSpeedMedium();
                _airconditionerrepository.Update(a);
            }
        }
    }
}
