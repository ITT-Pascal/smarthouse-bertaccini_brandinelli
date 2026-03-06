using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class IncreaseCCTVZoomCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public IncreaseCCTVZoomCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(Guid id)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            if (cctv != null)
            {
                cctv.IncreaseZoom();
                _CCTVRepository.Update(cctv);
            }
        }
    }
}
