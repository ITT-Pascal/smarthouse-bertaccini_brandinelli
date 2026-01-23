using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.ThermostastDevice
{
    public sealed record Temperature
    {

        public double _temp { get; init; }

        private Temperature(double value)
        {
            _temp = value;
        }

        public static Temperature Create(double value)
        {
            return new Temperature(Math.Clamp(value, Thermostat.MinTemperature, Thermostat.MaxTemperature));
        }

        public static Temperature operator +(Temperature t, double d)
        {
            return Temperature.Create(t._temp + d);
        }

        public static Temperature operator -(Temperature t, double d)
        {
            return Temperature.Create(t._temp - d);
        }

    }
}
