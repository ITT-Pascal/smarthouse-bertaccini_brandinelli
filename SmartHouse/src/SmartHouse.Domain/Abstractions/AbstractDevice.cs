using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Abstractions
{
    public abstract class AbstractDevice : ISwitchable
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastUpdateTime { get; protected set; }

        public AbstractDevice(string name)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is not valid");
            else
                Name = name;

            Status = DeviceStatus.Off;
            CreationTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
        }

        public virtual void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
                LastUpdateTime = DateTime.UtcNow;
            }
        }
    }
}
