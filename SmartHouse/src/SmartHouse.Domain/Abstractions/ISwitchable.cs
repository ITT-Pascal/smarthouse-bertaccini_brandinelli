using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Abstractions
{
    public interface ISwitchable
    {
        void SwitchOn();
        void SwitchOff();
        void SwitchOnOff();
    }
}
