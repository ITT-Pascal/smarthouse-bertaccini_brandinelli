using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.ThermostastDevice
{
    public class Thermostat
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DeviceStatus Status { get; private set; }
        public double Temperature { get; private set; }

        public const double MinTemperature = 15;
        public const double DefaultTemperature = 20;
        public const double MaxTemperature = 30;
        public const double DefaultJump = 0.1;

        public Thermostat(string name)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name isn't valid");
            else
                Name = name;
            Status = DeviceStatus.On;
            Temperature = DefaultTemperature;
        }

        public void IncreaseTemperature()
        {
            if (Temperature == MaxTemperature)
                throw new ArgumentException("The temperature is alredy at the maximum limit");

            Temperature += DefaultJump;
        }

        public void DecreaseTemperature()
        {
            if (Temperature == MinTemperature)
                throw new ArgumentException("The temperature is alredy at the minimum limit");

            Temperature -= DefaultJump;
        }

        public void SetTemperature(double newTemperature)
        {
            if (newTemperature < MinTemperature || newTemperature > MaxTemperature)
                throw new ArgumentException("New temperature isn't valid");

            Temperature = newTemperature;
        }      

    }
}
