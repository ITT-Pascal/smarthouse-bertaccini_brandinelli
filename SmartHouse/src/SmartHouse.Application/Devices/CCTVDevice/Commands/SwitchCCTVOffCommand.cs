using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class SwitchCCTVOffCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public SwitchCCTVOffCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(Guid id)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            if (cctv != null)
            {
                cctv.SwitchOff();
                _CCTVRepository.Update(cctv);
            }
        }
    }
}
