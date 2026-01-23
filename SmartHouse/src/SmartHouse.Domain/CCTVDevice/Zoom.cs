using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.CCTVDevice
{
    public sealed record Zoom
    {
        public double _zoom { get; }

        private Zoom(double value)
        {
            _zoom = value;
        }

        public static Zoom Create(double value)
        {
            return new Zoom(Math.Clamp(value, CCTV.MinZoom, CCTV.MaxZoom));
        }

        public static Zoom operator +(Zoom zoom, double jump)
        {
            return Create(zoom._zoom + jump);
        }

        public static Zoom operator -(Zoom zoom, double jump)
        {
            return Create(zoom._zoom - jump);
        }
    }
}
