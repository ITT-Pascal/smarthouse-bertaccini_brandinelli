namespace SmartHouse.Domain.UnitTest
{
    //Commit a
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

            newLamp.ChangeBrightness(101);

            Assert.Equal(100, newLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs0_LampIsOff()
        {
            Lamp newLamp = new Lamp();

            Assert.False(newLamp.IsOn);
        }

        [Fact]
        public void When_BrightnessIs50_LampIsOn()
        {
            Lamp newLamp = new Lamp();

            newLamp.ChangeBrightness(50);

            Assert.True(newLamp.IsOn);
            Assert.Equal(50, newLamp.Brightness);
        }
    }
}
