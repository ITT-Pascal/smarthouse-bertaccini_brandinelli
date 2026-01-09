using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.IlluminationDevice;

namespace SmartHouse.Domain
{
    public abstract class AbstractLamp : AbstractDevice, ILamp
    {      
        public int Brightness { get; protected set; }      
        public abstract int MinBrightness {get; }
        public abstract int DefaultBrightness{ get; }
        public abstract int MaxBrightness { get; }

        private const int DefaultStep = 10;
        
        public AbstractLamp(string name) : base(name)
        {          
            Brightness = 0;          
        }

        public override void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                base.SwitchOn();
                Brightness = DefaultBrightness;
            }             
        }

        public override void SwitchOff()
        {
            if (Status == DeviceStatus.On)
            {
                base.SwitchOff();
                Brightness = MinBrightness;
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
