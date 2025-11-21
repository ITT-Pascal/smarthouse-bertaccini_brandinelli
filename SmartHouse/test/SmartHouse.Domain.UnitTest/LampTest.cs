namespace SmartHouse.Domain.UnitTest
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
        public void When_BrightnessIsHigherThan100_BrightnessIs100()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOnOff();

            newLamp.ChangeBrightness(101);

            Assert.Equal(100, newLamp.Brightness);
        }

        [Fact]
        public void When_LampIsOnButBrightnessIs0_LampIsOff()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOnOff();

            newLamp.SwitchOnOff();

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
        public void When_TheLampIsOff_TheBrigthnessIsMinBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOn_TheBrigthnessIsDefaultBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();

            Assert.Equal(newLamp.DefaultBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_TheLampIsOnAndWantTurnOff_TheBrigthnessIsMinBrigthness()
        {
            Lamp newLamp = new Lamp("Stefano");

            newLamp.SwitchOn();
            newLamp.SwitchOff();

            Assert.Equal(newLamp.MinBrightness, newLamp.Brightness);
            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }
    }
}
