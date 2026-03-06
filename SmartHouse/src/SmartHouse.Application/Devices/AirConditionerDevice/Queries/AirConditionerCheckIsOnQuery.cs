using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Application.Devices.AirConditionerDevice.Mapper;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Queries
{
    public class AirConditionerCheckIsOnQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerCheckIsOnQuery(IAirConditionerRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            DeviceStatus status = DeviceStatusMapper.ToDomain(new AirConditionerGetByIdQuery(_repository).Execute(id).Status);
            if (status == DeviceStatus.On)
                return true;
            return false;
        }
    }
}
