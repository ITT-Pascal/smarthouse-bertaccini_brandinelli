using SmartHouse.Domain.Abstractions;

namespace SmartHouse.Domain.CCTVDevice
{
    public sealed class CCTV : AbstractDevice, ILockable, ICCTV
    {
        public CCTVVisionType VisionType { get; set; }
        public Zoom Zoom { get; private set; }
        public const Zoom MinZoom = 0.5;
        public const double DefaultZoom = 1.0;
        public const double MaxZoom = 10.0;
        public const double DefaultJump = 0.1;
        public Pin PIN { get; private set; }
        public bool IsLocked { get; private set; }

        public CCTV(string name) : base(name)
        {
            VisionType = CCTVVisionType.DefaultVision;
            Zoom = Zoom.Create(DefaultZoom);
            IsLocked = false;
        }

        public CCTV(string name, int pin) : base(name)
        {
            VisionType = CCTVVisionType.DefaultVision;
            Zoom = Zoom.Create(DefaultZoom);
            IsLocked = true;
            PIN = Pin.Create(pin);
        }

        public void Unlock(Pin pin)
        {
            if (IsLocked == true)
            {
                if (PIN == pin)
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
            if (IsLocked == false && PIN != null)
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
            if (IsLocked == false)
            {
                switch (type)
                {
                    case CCTVVisionType.DefaultVision:
                        if (VisionType == type) { throw new ArgumentException("Vision type is alredy set at default"); }
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

        }

        public void SetMinZoom()
        {
            if (!IsLocked)
            {
                if (Zoom.Equals(MinZoom))
                    throw new ArgumentException("Zoom is already at minimum");

                Zoom = Zoom.Create(MinZoom);
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void SetDefaultZoom()
        {
            if (!IsLocked)
            {
                if (Zoom.Equals(DefaultZoom))
                    throw new ArgumentException("Zoom is already at default");
                Zoom = Zoom.Create(DefaultZoom);
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void SetMaxZoom()
        {
            if (!IsLocked)
            {
                if (Zoom.Equals(MaxZoom))
                    throw new ArgumentException("Zoom is already at maximum");

                Zoom = Zoom.Create(MaxZoom);
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void IncreaseZoom()
        {
            if (!IsLocked)
            {
                Zoom += DefaultJump;
                LastUpdateTime = DateTime.UtcNow;
            }
        }

        public void DecreaseZoom()
        {
            if (!IsLocked)
            {
                Zoom -= DefaultJump;
                LastUpdateTime = DateTime.UtcNow;
            }
        }
    }
}
