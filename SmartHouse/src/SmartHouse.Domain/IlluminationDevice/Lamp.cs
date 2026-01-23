using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;

namespace SmartHouse.Domain.Illumination
{
    public sealed class Lamp : AbstractLamp
    {       
        Brightness ThisMinBrightness = Brightness.Create(0);
        Brightness ThisDefaultBrightness = Brightness.Create(50);
        Brightness ThisMaxBrightness = Brightness.Create(100);

        public override Brightness MaxBrightness => ThisMaxBrightness;
        public override Brightness MinBrightness => ThisMinBrightness;
        public override Brightness DefaultBrightness => ThisDefaultBrightness;

        public Lamp(Name name) : base(name) { }
    }
}
