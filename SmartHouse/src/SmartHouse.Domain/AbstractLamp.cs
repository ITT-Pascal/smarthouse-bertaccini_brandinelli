using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public int Brightness { get; protected set; }
        public DeviceStatus Status {get; protected set;}
        public DateTime CreationTime { get; protected set; }
        public DateTime LastUpdateTime { get; protected set; }
        public abstract int MinBrightness {get; }
        public abstract int DefaultBrightness{ get; }
        public abstract int MaxBrightness { get; }

        private const int DefaultStep = 10;
        
        public AbstractLamp(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brightness = 0;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
        }

        public virtual void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                Brightness = DefaultBrightness;
                LastUpdateTime = DateTime.UtcNow;
            }
                            
        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
                Brightness = MinBrightness;
                LastUpdateTime = DateTime.UtcNow;
            }
                

           
        }

        public virtual void Dimmer()
        {
            if(Status == DeviceStatus.On)
            {
                Brightness = Math.Max(MinBrightness, Brightness - DefaultStep);
                LastUpdateTime = DateTime.UtcNow;
            }
               
        }

        public virtual void Brighten()
        {
            if (Status == DeviceStatus.On)
            {
                Brightness = Math.Min(MaxBrightness, Brightness + DefaultStep);
                LastUpdateTime = DateTime.UtcNow;
            }
                
        }

        public virtual void SwitchOnOff()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                Brightness = DefaultBrightness;
                LastUpdateTime = DateTime.UtcNow;
            }
            else if (Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
                Brightness = MinBrightness;
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public virtual void ChangeBrightness(int newBrightness)
        {
            if (newBrightness > MinBrightness && Status == DeviceStatus.On)
            {
                Brightness = Math.Min(newBrightness, MaxBrightness);
                LastUpdateTime = DateTime.UtcNow;
            }
                

        }

        
        


    }
}
