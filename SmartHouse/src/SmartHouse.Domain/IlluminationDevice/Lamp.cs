using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;

namespace SmartHouse.Domain.Illumination
{
    public sealed class Lamp : AbstractLamp
    {       
        Brightness ThisMinBrightness { get; init; } = Brightness.Create(0);
        Brightness ThisDefaultBrightness { get; init; } = Brightness.Create(50);
        Brightness ThisMaxBrightness { get; init; } = Brightness.Create(100);

        public override Brightness MaxBrightness => ThisMaxBrightness;
        public override Brightness MinBrightness => ThisMinBrightness;
        public override Brightness DefaultBrightness => ThisDefaultBrightness;

        public Lamp(string name) : base(name) { }
    }
}
