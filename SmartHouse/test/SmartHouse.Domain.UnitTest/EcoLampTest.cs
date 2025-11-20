namespace SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {

        [Fact]
        public void When_BrightnessIsNegative_BrightnessRemainsZero()
        {
            EcoLamp newEcoLamp = new EcoLamp("Lepri");

            newEcoLamp.ChangeBrightness(-1);

            Assert.Equal(0, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIsHigherThan50_BrightnessIs50()
        {
            EcoLamp newEcoLamp = new EcoLamp("Lepri");

            newEcoLamp.SwitchOnOff();

            newEcoLamp.ChangeBrightness(50);

            Assert.Equal(50, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_LampIsOnButBrightnessIs0_LampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp("Lepri");

            newEcoLamp.SwitchOnOff();

            newEcoLamp.SwitchOnOff();

            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }

        [Fact]
        public void When_BrightnessIs25AndLampIsOn_LampIsOn()
        {
            EcoLamp newEcoLamp = new EcoLamp("Lepri");

            newEcoLamp.SwitchOnOff();

            newEcoLamp.ChangeBrightness(25);

            Assert.Equal(DeviceStatus.On, newEcoLamp.Status);
            Assert.Equal(25, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs25ButLampIsOff_LampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp("Lepri");

            newEcoLamp.ChangeBrightness(25);

            Assert.Equal(DeviceStatus.Off, newEcoLamp.Status);
        }
              
       
    }

}