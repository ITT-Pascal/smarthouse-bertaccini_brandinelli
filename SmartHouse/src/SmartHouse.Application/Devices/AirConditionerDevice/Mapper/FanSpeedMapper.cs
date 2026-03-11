using SmartHouse.Domain.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.AirConditionerDevice.Mapper
{
    public class FanSpeedMapper
    {
        public static string ToDto(FanSpeed fanSpeed)
        {
            return fanSpeed switch
            {
                FanSpeed.Low => "LOW",
                FanSpeed.Medium => "MEDIUM",
                FanSpeed.High => "HIGH",
                _ => throw new ArgumentException("Invalid fan speed value")
            };
        }

        public static FanSpeed ToDomain(string fanSpeed)
        {
            return fanSpeed switch
            {
                "LOW" => FanSpeed.Low,
                "MEDIUM" => FanSpeed.Medium,
                "HIGH" => FanSpeed.High,
                _ => throw new ArgumentException("Invalid fan speed value")
            };
        }
    }
}
