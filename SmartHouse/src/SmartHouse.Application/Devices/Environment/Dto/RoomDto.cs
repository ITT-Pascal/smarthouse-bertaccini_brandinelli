using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public List<AbstractDevice> Devices { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"Devices: {Devices}\n" +
                $"Created: {CreationTime}\n" +
                $"Last update: {LastUpdateTime}\n";
        }
    }
}
