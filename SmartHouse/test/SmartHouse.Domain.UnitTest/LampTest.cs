namespace SmartHouse.Domain.UnitTest
{
    //Commit aaa
    public class LampTest
    {

        [Fact]
        public void When_BrightnessIsNegative_BrightnessRemainsZero()
        {
            Lamp newLamp = new Lamp();

            newLamp.ChangeBrightness(-1);

            Assert.Equal(0, newLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIsHigherThan100_BrightnessIs100()
        {
            Lamp newLamp = new Lamp();

            newLamp.SwitchOnOff();

            newLamp.ChangeBrightness(101);

            Assert.Equal(100, newLamp.Brightness);
        }

        [Fact]
        public void When_LampIsOnButBrightnessIs0_LampIsOff()
        {
            Lamp newLamp = new Lamp();

            newLamp.SwitchOnOff();

            newLamp.SwitchOnOff();

            Assert.False(newLamp.IsOn);
        }

        [Fact]
        public void When_BrightnessIs50AndLampIsOn_LampIsOn()
        {
            Lamp newLamp = new Lamp();

            newLamp.SwitchOnOff();

            newLamp.ChangeBrightness(50);

            Assert.True(newLamp.IsOn);
            Assert.Equal(50, newLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs50ButLampIsOff_LampIsOff()
        {
            Lamp newLamp = new Lamp();

            newLamp.ChangeBrightness(50);

            Assert.False(newLamp.IsOn);
        }
    }
}
