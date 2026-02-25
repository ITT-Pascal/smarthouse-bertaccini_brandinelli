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
    public class AirConditionerGetAllQuery
    {
        private readonly IAirConditionerRepository _repository;

        public AirConditionerGetAllQuery(IAirConditionerRepository repos)
        {
            _repository = repos;
        }

        public List<AirConditionerDto> Execute()
        {
            List<AirConditionerDto> result = new List<AirConditionerDto>();

            foreach(AirConditioner a in _repository.GetAll())
            {
                if (a != null)
                    result.Add(AirConditionerMapper.ToDto(a));
            }
            return result;
        }
    }
}
