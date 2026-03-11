using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorCheckIsOnQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsOnQuery(IDoorRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            DeviceStatus status = DeviceStatusMapper.ToDomain(new DoorGetByIdQuery(_repository).Execute(id).Status);
            if (status == DeviceStatus.On)
                return true;
            return false;
        }
    }
}
