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

        private Pin(int pin)
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

        public static bool operator ==(Pin p1, int p2)
        {
            return p1.PIN == p2;
        }

        public static bool operator !=(Pin p1, int p2)
        {
            return p1.PIN != p2;
        }
       
    }
}

