using SmartHouse.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.CCTV
{
    public class CCTV : AbstractDevice
    {
        public CCTVVisionType VisionType { get; set; }
        public const double MinZoom = 0.5;
        public const double DefaultZoom = 1.0;
        public const double MaxZoom = 10.0;
        
        public CCTV(string name) : base(name)
        {
            VisionType = CCTVVisionType.DefaultVision;
        }

        public void SetDefaulVision()
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
    }
}
