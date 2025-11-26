using SmartHouse.Domain.Illumination;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
{
    public class LampTest
    {

        [Fact]
        public void When_BrightnessIsNegative_BrightnessRemainsZero()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.ChangeBrightness(-1);

            Assert.Equal(0, newLamp.Brightness);
        }

        [Fact]
        public void When_TheLampIsOffAndWantToToggle_TheLampTurnOn()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOnOff();

            Assert.Equal(newLamp.DefaultBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOnAndWantToToggle_TheLampTurnOff()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();

            newLamp.SwitchOnOff();

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_BrightnessIs50AndLampIsOn_LampIsOn()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOnOff();

            newLamp.ChangeBrightness(50);

            Assert.Equal(DeviceStatus.On, newLamp.Status);
            Assert.Equal(50, newLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs50ButLampIsOff_LampIsOff()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.ChangeBrightness(50);

            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOff_TheBrightnessIsMinBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOn_TheBrightnessIsDefaultBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();

            Assert.Equal(newLamp.DefaultBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOnAndWantTurnOff_TheBrightnessIsMinBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();
            newLamp.SwitchOff();

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOffAndWantToDimmer_TheBrightnessRemainsTheSame()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.Dimmer();

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOnAndWantToDimmer_TheBrightnessDiminishes()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();
            newLamp.Dimmer();

            Assert.Equal(40, newLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOffAndWantToBrighten_TheBrightnessRemainsTheSame()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.Brighten();

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOnAndWantToBrighten_TheBrightnessIncreases()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();
            newLamp.Brighten();

            Assert.Equal(60, newLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }
    }
}
