using SmartHouse.Application.Devices.AirConditionerDevice.Mapper;
using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Queries
{
    public class AirConditionerCheckFanSpeedHighQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckFanSpeedHighQuery(IAirConditionerRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            FanSpeed fs = FanSpeedMapper.ToDomain(new AirConditionerGetByIdQuery(_repository).Execute(id).FanSpeed);
            if (fs == FanSpeed.High)
                return true;
            return false;
        }
    }
}
