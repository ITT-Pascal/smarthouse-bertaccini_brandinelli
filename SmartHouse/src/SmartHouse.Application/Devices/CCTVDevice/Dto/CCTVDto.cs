using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.CCTVDevice.Dto
{
    public class CCTVDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string VisionType { get; set; }
        public double Zoom { get; set; }
        public int Pin { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Status: {Status}\n" +
                $"Pin: {Pin}\n" +
                $"VisionType: {VisionType}\n" +
                $"Zoom: {Zoom}\n" +
                $"IsLocked: {IsLocked}\n" +
                $"Created: {CreationTime}\n" +
                $"Last update: {LastUpdateTime}\n";
        }
    }
}
