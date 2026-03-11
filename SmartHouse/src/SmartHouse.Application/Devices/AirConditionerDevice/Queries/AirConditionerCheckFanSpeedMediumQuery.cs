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
    public class AirConditionerCheckFanSpeedMediumQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckFanSpeedMediumQuery(IAirConditionerRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            FanSpeed fs = FanSpeedMapper.ToDomain(new AirConditionerGetByIdQuery(_repository).Execute(id).FanSpeed);
            if (fs == FanSpeed.Medium)
                return true;
            return false;
        }
    }
}
