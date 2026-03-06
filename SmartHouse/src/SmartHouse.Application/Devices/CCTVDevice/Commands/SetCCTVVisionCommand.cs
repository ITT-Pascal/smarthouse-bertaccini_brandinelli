using SmartHouse.Application.Devices.CCTVDevice.Mapper;
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

        public bool Execute(Guid id, string visionchoice)
        {
            CCTV cctv = _CCTVRepository.GetById(id);
            CCTVVisionType visiontype;
            switch (visionchoice)
            {
                case "1":
                    visiontype = CCTVVisionType.DefaultVision;
                    break;
                case "2":
                    visiontype = CCTVVisionType.NightVision;
                    break;
                case "3":
                    visiontype = CCTVVisionType.ThermalVision;
                    break;
                default:
                    Console.WriteLine("Invalid vision type");
                    return false;
                    break;
            }
            if (cctv != null)
            {
                cctv.SetVision(visiontype);
                _CCTVRepository.Update(cctv);
                return true;
            }
            return false;
        }
    }
}
