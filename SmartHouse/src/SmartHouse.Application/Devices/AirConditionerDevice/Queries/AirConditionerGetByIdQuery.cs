using SmartHouse.Application.Devices.AirConditionerDevice.Dto;
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
    public class AirConditionerGetByIdQuery
    {
        private readonly IAirConditionerRepository _airconditionerrepository;

        public AirConditionerGetByIdQuery(IAirConditionerRepository airconditionerRepository)
        {
            _airconditionerrepository = airconditionerRepository;
        }

        public AirConditionerDto Execute(Guid id)
        {
            return AirConditionerMapper.ToDto(_airconditionerrepository.GetById(id));
        }
    }
}
