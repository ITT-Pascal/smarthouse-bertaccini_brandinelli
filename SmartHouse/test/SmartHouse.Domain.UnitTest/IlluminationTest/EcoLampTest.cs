using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
{
    public class EcoLampTest
    {

        

        [Fact]
        public void When_BrightnessIsNegative_BrightnessRemainsZero()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.ChangeBrightness(-1);

            Assert.Equal(0, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_TheEcoLampIsOffAndWantToToggle_TheEcoLampTurnOn()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOnOff();

            Assert.Equal(newEcoLamp.DefaultBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOnAndWantToToggle_TheEcoLampTurnOff()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOn();

            newEcoLamp.SwitchOnOff();

            Assert.Equal(newEcoLamp.MinBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_BrightnessIs50AndEcoLampIsOn_EcoLampIsOn()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOnOff();

            newEcoLamp.ChangeBrightness(50);

            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
            Assert.Equal(50, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs50ButEcoLampIsOff_EcoLampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.ChangeBrightness(50);

            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOff_TheBrightnessIsMinBrigthness()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            Assert.Equal(newEcoLamp.MinBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOn_TheBrightnessIsDefaultBrigthness()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOn();

            Assert.Equal(newEcoLamp.DefaultBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOnAndWantTurnOff_TheBrightnessIsMinBrigthness()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOn();
            newEcoLamp.SwitchOff();

            Assert.Equal(newEcoLamp.MinBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOffAndWantToDimmer_TheBrightnessRemainsTheSame()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.Dimmer();

            Assert.Equal(newEcoLamp.MinBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOnAndWantToDimmer_TheBrightnessDiminishes()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOn();
            newEcoLamp.Dimmer();

            Assert.Equal(20, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOffAndWantToBrighten_TheBrightnessRemainsTheSame()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.Brighten();

            Assert.Equal(newEcoLamp.MinBrightness, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_TheEcoLampIsOnAndWantToBrighten_TheBrightnessIncreases()
        {
            EcoLamp newEcoLamp = new EcoLamp("Stefano");

            newEcoLamp.SwitchOn();
            newEcoLamp.Brighten();

            Assert.Equal(40, newEcoLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
        }

        [Fact]
        public void CheckAutoOff_ShouldTurnOff_WhenTimeHasElapsed()
        {
            var lamp = new EcoLamp("Eco Lamp");
            lamp.SwitchOn();

            typeof(EcoLamp)
                .GetField("autoOffAtUtc", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(lamp, DateTime.UtcNow.AddMinutes(-1));

            lamp.CheckAutoOff();

            Assert.Equal(DeviceStatus.Off, lamp.Status);
            Assert.Equal(lamp.MinBrightness, lamp.Brightness);
        }

        [Fact]
        public void CheckAutoOff_ShouldNotTurnOff_WhenTimeNotElapsed()
        {
            var lamp = new EcoLamp("Eco Lamp");
            lamp.SwitchOn();

            lamp.CheckAutoOff();

            Assert.Equal(DeviceStatus.On, lamp.Status);
            Assert.Equal(lamp.DefaultBrightness, lamp.Brightness);
        }


    }

}