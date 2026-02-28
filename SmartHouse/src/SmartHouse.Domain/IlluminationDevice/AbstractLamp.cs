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
        public Brightness Brightness { get; protected set; }      
        public abstract Brightness MinBrightness {get; }
        public abstract Brightness DefaultBrightness{ get; }
        public abstract Brightness MaxBrightness { get; }

        private const int DefaultStep = 10;
        
        public AbstractLamp(string name) : base(name)
        {          
            Brightness = Brightness.Create(0, MinBrightness._brightness, MaxBrightness._brightness);          
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
                Brightness = Brightness.Create(Brightness._brightness - DefaultStep, MinBrightness._brightness, MaxBrightness._brightness);
                LastUpdateTime = DateTime.UtcNow;
            }  
        }

        public virtual void Brighten()
        {
            if (Status == DeviceStatus.On)
            {
                Brightness = Brightness.Create(Brightness._brightness + DefaultStep, MinBrightness._brightness, MaxBrightness._brightness);
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
            if (Status == DeviceStatus.On)
            {
                Brightness = Brightness.Create(newBrightness, MinBrightness._brightness, MaxBrightness._brightness);
                LastUpdateTime = DateTime.UtcNow;
            }
        }
        
    }
}
