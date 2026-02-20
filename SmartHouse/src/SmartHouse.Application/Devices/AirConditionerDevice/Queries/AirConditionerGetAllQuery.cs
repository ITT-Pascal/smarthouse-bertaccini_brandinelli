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

        public List<AirConditioner> Execute()
        {
            List<AirConditioner> result = new List<AirConditioner>();

            foreach(AirConditioner a in _repository.GetAll())
            {
                if (a != null)
                    result.Add(a);
            }
            return result;
        }
    }
}
