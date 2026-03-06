using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;

namespace SmartHouse.Domain.Illumination
{
    public sealed class Lamp : AbstractLamp
    {       
        Brightness ThisMinBrightness { get; init; } = Brightness.Create(0, 0, 100);
        Brightness ThisDefaultBrightness { get; init; } = Brightness.Create(50, 0, 100);
        Brightness ThisMaxBrightness { get; init; } = Brightness.Create(100, 0, 100);

        public override Brightness MaxBrightness => ThisMaxBrightness;
        public override Brightness MinBrightness => ThisMinBrightness;
        public override Brightness DefaultBrightness => ThisDefaultBrightness;

        public Lamp(string name) : base(name) { }
        public Lamp(Guid id, string name, DeviceStatus status, Brightness brightness, DateTime creationtime, DateTime lastupdatetime) : base(name)
        {
            Id = id;
            Status = status;
            Brightness = brightness;
            CreationTime = creationtime;
            LastUpdateTime = lastupdatetime;
        }
    }
}
