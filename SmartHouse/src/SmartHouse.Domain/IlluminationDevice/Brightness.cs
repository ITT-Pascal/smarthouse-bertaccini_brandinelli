using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.IlluminationDevice
{
    public sealed record Brightness
    {
        public int _brightness { get; }

        public Brightness(int brightness)
        {
            if (brightness < 0 || brightness > 100)
            {
                throw new ArgumentException("brightness must be contained in the 0 to 100 range");
            }
            else
                _brightness = brightness;
        }

        public static Brightness operator -(Brightness b, int i)
        {
            return new Brightness(b._brightness - i);
        }

        public static Brightness operator +(Brightness b, int i)
        {
            return new Brightness(b._brightness + i);
        }

        public static bool operator >(Brightness b1, Brightness b2)
        {
            return b1._brightness > b2._brightness;
        }

        public static bool operator <(Brightness b1, Brightness b2)
        {
            return b1._brightness < b2._brightness;
        }

        public static bool operator >(Brightness b1, int i)
        {
            return b1._brightness > i;
        }

        public static bool operator <(Brightness b1, int i)
        {
            return b1._brightness < i;
        }

        public static bool operator >=(Brightness b1, Brightness b2)
        {
            return b1._brightness >= b2._brightness;
        }

        public static bool operator <=(Brightness b1, Brightness b2)
        {
            return b1._brightness <= b2._brightness;
        }

        public static bool operator >=(Brightness b1, int i)
        {
            return b1._brightness >= i;
        }

        public static bool operator <=(Brightness b1, int i)
        {
            return b1._brightness <= i;
        }
    }
}
