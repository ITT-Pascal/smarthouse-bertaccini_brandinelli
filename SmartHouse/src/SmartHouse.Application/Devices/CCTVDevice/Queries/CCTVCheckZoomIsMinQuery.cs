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
    public class CCTVCheckZoomIsMinQuery
    {
        private readonly ICCTVRepository _repository;

        public CCTVCheckZoomIsMinQuery(ICCTVRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            Zoom zoom = CCTVMapper.ToDomain(new GetCCTVByIdQuery(_repository).Execute(id)).Zoom;
            if (zoom == new CCTV("Check").MinZoom)
                return true;
            return false;
        }
    }
}
