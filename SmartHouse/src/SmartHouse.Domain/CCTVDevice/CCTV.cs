using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Domain.CCTVDevice
{
    public sealed class CCTV : AbstractDevice, ILockable, ICCTV
    {
        public CCTVVisionType VisionType { get; set; }
        public double Zoom { get; set; }
        public const double MinZoom = 0.5;
        public const double DefaultZoom = 1.0;
        public const double MaxZoom = 10.0;
        public const double DefaultJump = 0.1;
        public Pin PIN { get; private set; }
        public bool IsLocked { get; private set; }
        
        public CCTV(string name) : base(name)
        {
            VisionType = CCTVVisionType.DefaultVision;
            Zoom = DefaultZoom;
            IsLocked = false;
        }

        public CCTV(string name, int pin) : base (name)
        {
            VisionType = CCTVVisionType.DefaultVision;
            Zoom = DefaultZoom;
            IsLocked = true;
            PIN = Pin.Create(pin);
        }

        public void Unlock(Pin pin)
        {
            if(IsLocked == true)
            {
                if(PIN == pin)
                {
                    IsLocked = false;
                    LastUpdateTime = DateTime.UtcNow;
                }
                else
                {
                    throw new ArgumentException("The wrong pin was inserted");
                }
            }
            else
            {
                throw new ArgumentException("The CCTV is alredy unlocked");
            }
        }

        public void Lock()
        {
            if(IsLocked == false && PIN != null)
            {
                IsLocked = true;
                LastUpdateTime = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentException("The CCTV is alredy locked or isn't lockable");
            }
        }

        public override void SwitchOn()
        {
            if (IsLocked == false)
            {
                base.SwitchOn();
                LastUpdateTime = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentException("The CCTV must be unlocked before being turned on");
            }
        }

       public void SetVision(CCTVVisionType type)
        {
            switch (type)
            {
                case CCTVVisionType.DefaultVision:
                    if(VisionType == type) { throw new ArgumentException("Vision type is alredy set at default"); }
                    VisionType = type;
                    LastUpdateTime = DateTime.UtcNow;
                    break;
                case CCTVVisionType.NightVision:
                    if (VisionType == type) { throw new ArgumentException("Vision type is alredy set at night vision"); }
                    VisionType = type;
                    LastUpdateTime = DateTime.UtcNow;
                    break;
                case CCTVVisionType.ThermalVision:
                    if (VisionType == type) { throw new ArgumentException("Vision type is alredy set at thermal vision"); }
                    VisionType = type;
                    LastUpdateTime = DateTime.UtcNow;
                    break;
                default:
                    throw new ArgumentException("Entered vision type does not exist");
            }

        }

        public void SetMinZoom()
        {
            if (Zoom == MinZoom)
                throw new ArgumentException("Zoom is already at minimum");

            Zoom = MinZoom;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SetDefaultZoom()
        {
            if (Zoom == DefaultZoom)
                throw new ArgumentException("Zoom is already at default");

            Zoom = DefaultZoom;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void SetMaxZoom()
        {
            if (Zoom == MaxZoom)
                throw new ArgumentException("Zoom is already at maximum");

            Zoom = MaxZoom;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void IncreaseZoom()
        {
            if (Zoom == MaxZoom)
                throw new ArgumentException("Zoom is already al maximum");

            Zoom += DefaultJump;
            LastUpdateTime = DateTime.UtcNow;
        }

        public void DecreaseZoom()
        {
            if (Zoom == MinZoom)
                throw new ArgumentException("Zoom is already al minimum");

            Zoom -= DefaultJump;
            LastUpdateTime = DateTime.UtcNow;
        }
    }
}
