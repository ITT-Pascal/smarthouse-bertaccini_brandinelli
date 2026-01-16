using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Domain.CCTVDevice
{
    public sealed class CCTV : AbstractDevice, ILockable
    {
        public CCTVVisionType VisionType { get; set; }
        public double Zoom { get; set; }
        public const double MinZoom = 0.5;
        public const double DefaultZoom = 1.0;
        public const double MaxZoom = 10.0;
        public const double DefaultJump = 0.1;
        public int? PIN { get; private set; }
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
            if (pin.ToString().Length < 4)
                throw new ArgumentException("PIN must have at least 4 digits");
            else
                PIN = pin;
        }

        public void Unlock(int pin)
        {
            if(IsLocked == true)
            {
                if(PIN == pin)
                {
                    IsLocked = false;
                }else
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
            }
            else
            {
                throw new ArgumentException("The CCTV must be unlocked before being turned on");
            }
        }

        public void SetDefaultVision()
        {
            if (VisionType == CCTVVisionType.DefaultVision)
                throw new ArgumentException("Vision type is already set as default");

            VisionType = CCTVVisionType.DefaultVision;
        }

        public void SetNightVision()
        {
            if (VisionType == CCTVVisionType.NightVision)
                throw new ArgumentException("Vision type is already set as night vision");

            VisionType = CCTVVisionType.NightVision;
        }

        public void SetThermalVision()
        {
            if (VisionType == CCTVVisionType.ThermalVision)
                throw new ArgumentException("Vision type is already set as thermal vision");

            VisionType = CCTVVisionType.ThermalVision;
        }

        public void SetMinZoom()
        {
            if (Zoom == MinZoom)
                throw new ArgumentException("Zoom is already at minimum");

            Zoom = MinZoom;
        }

        public void SetDefaultZoom()
        {
            if (Zoom == DefaultZoom)
                throw new ArgumentException("Zoom is already at default");

            Zoom = DefaultZoom;
        }

        public void SetMaxZoom()
        {
            if (Zoom == MaxZoom)
                throw new ArgumentException("Zoom is already at maximum");

            Zoom = MaxZoom;
        }

        public void IncreaseZoom()
        {
            if (Zoom == MaxZoom)
                throw new ArgumentException("Zoom is already al maximum");

            Zoom += DefaultJump;
        }

        public void DecreaseZoom()
        {
            if (Zoom == MinZoom)
                throw new ArgumentException("Zoom is already al minimum");

            Zoom -= DefaultJump;
        }
    }
}
