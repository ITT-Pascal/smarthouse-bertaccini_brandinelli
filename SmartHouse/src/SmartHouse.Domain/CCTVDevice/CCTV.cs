using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Domain.CCTVDevice
{
    public class CCTV : AbstractDevice
    {
        public CCTVVisionType VisionType { get; set; }
        public double Zoom { get; set; }
        public const double MinZoom = 0.5;
        public const double DefaultZoom = 1.0;
        public const double MaxZoom = 10.0;
        public const double DefaultJump = 0.1;
        
        public CCTV(string name) : base(name)
        {
            VisionType = CCTVVisionType.DefaultVision;
            Zoom = DefaultZoom;
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
