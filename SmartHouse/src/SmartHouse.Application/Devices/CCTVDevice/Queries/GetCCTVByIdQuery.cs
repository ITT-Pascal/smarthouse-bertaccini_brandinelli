using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Queries
{
    public class GetCCTVByIdQuery
    {
        private readonly ICCTVRepository _CCTVRepository;

        public GetCCTVByIdQuery(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public CCTV Execute(Guid id)
        {
            return _CCTVRepository.GetById(id);
        }
    }
}
