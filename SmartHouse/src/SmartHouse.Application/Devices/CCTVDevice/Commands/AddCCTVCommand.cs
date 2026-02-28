using SmartHouse.Domain.CCTVDevice.Repositories;
using SmartHouse.Domain.CCTVDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _CCTVRepository;

        public AddCCTVCommand(ICCTVRepository CCTVRepository)
        {
            _CCTVRepository = CCTVRepository;
        }

        public void Execute(string name)
        {
            _CCTVRepository.Add(new CCTV(name));
        }
    }
}
