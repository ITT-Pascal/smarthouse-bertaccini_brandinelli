using SmartHouse.Application.Devices.Abstraction.Mapper;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Queries
{
    public class ThermostatCheckIsOnQuery
    {
        private readonly IThermostatRepository _repository;

        public ThermostatCheckIsOnQuery(IThermostatRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            DeviceStatus status = DeviceStatusMapper.ToDomain(new ThermostatGetByIdQuery(_repository).Execute(id).Status);
            if (status == DeviceStatus.On)
                return true;
            return false;
        }
    }
}
