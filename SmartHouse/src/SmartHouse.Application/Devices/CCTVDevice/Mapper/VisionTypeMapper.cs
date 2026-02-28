using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.CCTVDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Mapper
{
    public class VisionTypeMapper
    {

        public static string ToDto(CCTVVisionType visionType)
        {
            return visionType switch
            {
                CCTVVisionType.DefaultVision => "DEFAULT VISION",
                CCTVVisionType.NightVision => "NIGHT VISION",
                CCTVVisionType.ThermalVision => "THERMAL VISION",
                _ => throw new ArgumentException("Invalid vision type value")
            };
        }

        public static CCTVVisionType ToDomain(string status)
        {
            return status switch
            {
                "DEFAULT VISION" => CCTVVisionType.DefaultVision,
                "NIGHT VISION" => CCTVVisionType.NightVision,
                "THERMAL VISION" => CCTVVisionType.ThermalVision,
                _ => throw new ArgumentException("Invalid vision type value")
            };
        }
    }
}
