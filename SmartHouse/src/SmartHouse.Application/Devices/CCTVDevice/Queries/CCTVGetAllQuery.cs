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

        public List<CCTV> Execute()
        {
            List<CCTV> result = new List<CCTV>();

            foreach(CCTV c in _repository.GetAll())
            {
                if (c != null)
                    result.Add(c);
            }
            return result;
        }
    }
}
