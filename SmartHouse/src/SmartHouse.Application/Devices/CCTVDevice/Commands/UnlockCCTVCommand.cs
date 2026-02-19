using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class UnlockCCTVCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public UnlockCCTVCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(Guid id, int pin)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            if (cctv != null)
            {
                cctv.Unlock(Pin.Create(pin));
                _CCTVRepository.Update(cctv);
            }
        }
    }
}
