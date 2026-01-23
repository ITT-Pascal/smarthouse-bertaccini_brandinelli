using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Abstractions
{
    public sealed record Pin
    {
        public int PIN { get; }

        public Pin(int pin)
        {                      
                PIN = pin;
        }

        public static Pin Create(int pin)
        {
            if (pin.ToString().Length < 4)
            {
                throw new ArgumentException("Pin can't be shorter than 4 digits");
            }

            return new Pin(pin);
        }
       
    }
}

