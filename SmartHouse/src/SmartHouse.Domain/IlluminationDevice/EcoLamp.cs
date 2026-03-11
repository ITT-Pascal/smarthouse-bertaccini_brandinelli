using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Illumination
{
    public sealed class EcoLamp : AbstractLamp
    {
        Brightness ThisMinBrightness { get; init; } = Brightness.Create(0, 0, 70);
        Brightness ThisDefaultBrightness { get; init; } = Brightness.Create(30, 0, 70);
        Brightness ThisMaxBrightness { get; init; } = Brightness.Create(70, 0, 70);

        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        public override Brightness MaxBrightness => ThisMaxBrightness;
        public override Brightness MinBrightness => ThisMinBrightness;
        public override Brightness DefaultBrightness => ThisDefaultBrightness;

        public EcoLamp(string name): base(name) { } 

        public override void SwitchOn()
        {
            SwitchOn(enableAutoOff: false);
        }

        public void SwitchOn(bool enableAutoOff)
        {
            base.SwitchOn();
            autoOffAtUtc = enableAutoOff
                ? DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes)
                : null;
        }

        public void SwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));

            base.SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }

        public override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }

        public override void ChangeBrightness(int newBrightness)
        {
            base.ChangeBrightness(newBrightness);
            ResetAutoOffIfNeeded();
        }

        public override void Dimmer()
        {
            base.Dimmer();
            ResetAutoOffIfNeeded();
        }

        public override void Brighten()
        {
            base.Brighten();
            ResetAutoOffIfNeeded();
        }

        public void CheckAutoOff()
        {
            if (Status == DeviceStatus.On &&
                autoOffAtUtc.HasValue &&
                DateTime.UtcNow >= autoOffAtUtc.Value)
            {
                SwitchOff();
            }
        }

        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }
    }
}
