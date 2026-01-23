using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.ThermostastDevice
{
    public sealed class Thermostat
    {
        public double Temperature { get; private set; }

        public const double MinTemperature = 15;
        public const double DefaultTemperature = 20;
        public const double MaxTemperature = 30;
        public const double DefaultJump = 0.1;

        public Guid Id { get; private set; }
        public Name Name { get; private set; }        
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdateTime { get; private set; }

        public Thermostat(string name)
        {
            Id = Guid.NewGuid();
            Name = Name.Create(name);
            CreationTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
            Temperature = DefaultTemperature;
        }       

        public void IncreaseTemperature()
        {
            if (Temperature == MaxTemperature)
                throw new ArgumentException("The temperature is alredy at the maximum limit");

            Temperature += DefaultJump;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            if (Temperature == MinTemperature)
                throw new ArgumentException("The temperature is alredy at the minimum limit");

            Temperature -= DefaultJump;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SetTemperature(double newTemperature)
        {
            if (newTemperature < MinTemperature || newTemperature > MaxTemperature)
                throw new ArgumentException("New temperature isn't valid");

            Temperature = newTemperature;
            LastUpdateTime = DateTime.UtcNow;
        }      

    }
}
