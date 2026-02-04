using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Environment
{
    public class Room
    {
        public List<Thermostat> Thermostats { get; set; }
        public List<Door> Doors { get; set; }
        public List<AbstractLamp> Illuminations { get; set; }
        public List<CCTV> CCTVs { get; set; }
        public List<AirConditioner> AirConditioners { get; set; }
        public Name Name { get; set; }

        public Room(Name name)
        {
            Name = name;
            Thermostats = new List<Thermostat>();
            Doors = new List<Door>();
            Illuminations = new List<AbstractLamp>();
            CCTVs = new List<CCTV>();
            AirConditioners = new List<AirConditioner>();
        }


    }
}
