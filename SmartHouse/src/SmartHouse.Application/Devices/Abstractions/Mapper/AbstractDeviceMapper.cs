using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Abstractions.Mapper
{
    public class AbstractDeviceMapper
    {
        public static Object ToObject(AbstractDevice abstractDevice)
        {
            return (Object)abstractDevice;
        }

        public static AbstractDevice ToAbstractDevice(Object newobject)
        {
            return (AbstractDevice)newobject;
        }
    }
}
