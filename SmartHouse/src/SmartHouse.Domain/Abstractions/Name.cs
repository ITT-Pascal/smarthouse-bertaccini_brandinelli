using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Abstractions
{
    public sealed record Name
    {
        public string _name { get; }
        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is not valid");
            else
                _name = name;
        }
    }
}
