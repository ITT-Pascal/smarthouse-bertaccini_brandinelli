using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Abstraction.Mapper
{
    public class DeviceStatusMapper
    {

        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.Standby => "STANDBY",
                DeviceStatus.Unknown => "UNKNOWN",
                _ => "ERROR",
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "STANDBY" => DeviceStatus.Standby,
                "UNKNOWN" => DeviceStatus.Unknown,
                _ => DeviceStatus.Error,
            };
        }
    }
}
