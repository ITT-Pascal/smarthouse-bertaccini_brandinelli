using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class SetCCTVVisionCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public SetCCTVVisionCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(Guid id, CCTVVisionType visionType)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            if (cctv != null)
            {
                cctv.SetVision(visionType);
                _CCTVRepository.Update(cctv);
            }
        }
    }
}
