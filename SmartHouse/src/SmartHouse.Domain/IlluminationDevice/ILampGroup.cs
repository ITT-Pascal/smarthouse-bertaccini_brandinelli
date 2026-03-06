using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice
{
    public interface ILampGroup
    {
        void AllSwitchOn();
        void AllSwitchOff();
        void AllLampsSwitchOnOff();
    }
}
