using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;

namespace SmartHouse.Domain.Illumination
{
    public sealed class Lamp : AbstractLamp
    {       
        Brightness ThisMinBrightness = new Brightness(0);
        Brightness ThisDefaultBrightness = new Brightness(50);
        Brightness ThisMaxBrightness = new Brightness(100);

        public override Brightness MaxBrightness => ThisMaxBrightness;
        public override Brightness MinBrightness => ThisMinBrightness;
        public override Brightness DefaultBrightness => ThisDefaultBrightness;

        public Lamp(Name name) : base(name) { }
    }
}
