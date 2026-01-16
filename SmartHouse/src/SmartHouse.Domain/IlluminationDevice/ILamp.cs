using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice
{
    public interface ILamp : ISwitchable
    {
        void Dimmer();
        void Brighten();       
        void ChangeBrightness(int newBrightness);
    }
}
