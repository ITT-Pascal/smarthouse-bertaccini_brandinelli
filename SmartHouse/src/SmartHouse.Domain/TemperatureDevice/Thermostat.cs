using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.TemperatureDevice
{
    public sealed class Thermostat: AbstractDevice
    {
        public Temperature Temperature { get; private set; }

        public const double MinTemperature = 15;
        public const double DefaultTemperature = 20;
        public const double MaxTemperature = 30;
        public const double DefaultJump = 0.1;

       

        public Thermostat(string name) : base(name)
        {           
            Temperature = Temperature.Create(DefaultTemperature);
        }       

        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                Temperature += DefaultJump;
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.On)
            {
                Temperature -= DefaultJump;
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void SetTemperature(double newTemperature)
        {
            if (Status == DeviceStatus.On)
            {
                Temperature = Temperature.Create(newTemperature);
                LastUpdateTime = DateTime.UtcNow;
            }
        }      

    }
}
