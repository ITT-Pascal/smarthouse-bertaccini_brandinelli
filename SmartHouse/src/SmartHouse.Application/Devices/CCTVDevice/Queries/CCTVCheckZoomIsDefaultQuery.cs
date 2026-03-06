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
    public class CCTVCheckZoomIsDefaultQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckZoomIsDefaultQuery(ICCTVRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            Zoom zoom = CCTVMapper.ToDomain(new GetCCTVByIdQuery(_repository).Execute(id)).Zoom;
            if (zoom == new CCTV("Check").DefaultZoom)
                return true;
            return false;
        }
    }
}
