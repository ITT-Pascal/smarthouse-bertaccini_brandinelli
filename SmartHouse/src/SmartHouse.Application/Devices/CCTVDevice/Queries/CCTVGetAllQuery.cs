using SmartHouse.Application.Devices.CCTVDevice.Dto;
using SmartHouse.Application.Devices.CCTVDevice.Mapper;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Queries
{
    public class CCTVGetAllQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVGetAllQuery(ICCTVRepository repos)
        {
            _repository = repos;
        }

        public List<CCTVDto> Execute()
        {
            List<CCTVDto> result = new List<CCTVDto>();

            foreach(CCTV c in _repository.GetAll())
            {
                if (c != null)
                    result.Add(CCTVMapper.ToDto(c));
            }
            return result;
        }
    }
}
