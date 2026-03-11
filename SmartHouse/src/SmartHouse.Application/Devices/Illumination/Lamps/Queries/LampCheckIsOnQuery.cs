using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Queries
{
    public class LampCheckIsOnQuery
    {
        private readonly ILampRepository _repository;

        public LampCheckIsOnQuery(ILampRepository repos)
        {
            _repository = repos;
        }

        public bool Execute(Guid id)
        {
            DeviceStatus status = DeviceStatusMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(id).Status);
            if (status == DeviceStatus.On)
                return true;
            return false;
        }
    }
}
