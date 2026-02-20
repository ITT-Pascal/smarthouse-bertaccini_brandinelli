using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Queries
{
    public class AirConditionerGetByIdQuery
    {
        private readonly IAirConditionerRepository _airconditionerrepository;

        public AirConditionerGetByIdQuery(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public AirConditioner Execute(Guid id)
        {
            return _airconditionerrepository.GetById(id);
        }
    }
}
