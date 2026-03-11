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
    public class ChangePinCCTVCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public ChangePinCCTVCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(Guid id, int currentPin, int newPin)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            if (cctv != null)
            {
                cctv.ChangePIN(currentPin, newPin);
                _CCTVRepository.Update(cctv);
            }
        }
    }
}
