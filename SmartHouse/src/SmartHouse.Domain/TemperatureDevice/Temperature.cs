using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.TemperatureDevice
{
    public sealed record Temperature
    {

        public double _temp { get; init; }
        private const double MinTemp = 15;
        private const double MaxTemp = 30;

        private Temperature(double value)
        {
            _temp = value;
        }

        public static Temperature Create(double value)
        {
            return new Temperature(Math.Clamp(value, MinTemp,MaxTemp));
        }

        public static Temperature operator +(Temperature t, double d)
        {
            return Temperature.Create(t._temp + d);
        }

        public static Temperature operator -(Temperature t, double d)
        {
            return Temperature.Create(t._temp - d);
        }

        public static bool operator ==(Temperature t, double d)
        {
            return t._temp == d;
        }

        public static bool operator !=(Temperature t, double d)
        {
            return t._temp != d;
        }
    }
}
