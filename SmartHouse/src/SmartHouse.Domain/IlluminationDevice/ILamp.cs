using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice
{
    public interface ILamp
    {
        void Dimmer();
        void Brighten();
        void SwitchOnOff();
        void ChangeBrightness(int newBrightness);
    }
}
