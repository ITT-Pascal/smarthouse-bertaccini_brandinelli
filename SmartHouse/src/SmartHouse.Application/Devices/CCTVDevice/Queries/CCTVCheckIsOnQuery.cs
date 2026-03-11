using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Queries
{
    public class CCTVCheckIsOnQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckIsOnQuery(ICCTVRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            DeviceStatus status = DeviceStatusMapper.ToDomain(new GetCCTVByIdQuery(_repository).Execute(id).Status);
            if (status == DeviceStatus.On)
                return true;
            return false;
        }
    }
}
