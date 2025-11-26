using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Illumination
{
    public enum DeviceStatus
    {
       Unknown = 0,
       Off = 1,
       On = 2,
       Standby = 3,
       Error = 4,
    }
}
