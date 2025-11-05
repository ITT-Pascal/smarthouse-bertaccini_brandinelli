namespace SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {

        [Fact]
        public void When_BrightnessIsNegative_BrightnessRemainsZero()
        {
            EcoLamp newEcoLamp = new EcoLamp();

            newEcoLamp.ChangeBrightness(-1);

            Assert.Equal(0, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIsHigherThan50_BrightnessIs50()
        {
            EcoLamp newEcoLamp = new EcoLamp();

            newEcoLamp.SwitchOnOff();

            newEcoLamp.ChangeBrightness(51);

            Assert.Equal(50, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_LampIsOnButBrightnessIs0_LampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp();

            newEcoLamp.SwitchOnOff();

            newEcoLamp.SwitchOnOff();

            Assert.False(newEcoLamp.IsOn);
        }

        [Fact]
        public void When_BrightnessIs25AndLampIsOn_LampIsOn()
        {
            EcoLamp newEcoLamp = new EcoLamp();

            newEcoLamp.SwitchOnOff();

            newEcoLamp.ChangeBrightness(25);

            Assert.True(newEcoLamp.IsOn);
            Assert.Equal(25, newEcoLamp.Brightness);
        }

        [Fact]
        public void When_BrightnessIs25ButLampIsOff_LampIsOff()
        {
            EcoLamp newEcoLamp = new EcoLamp();

            newEcoLamp.ChangeBrightness(25);

            Assert.False(newEcoLamp.IsOn);
        }

        [Fact]

        public void When_DateTimeIsEarlierThan8AndLampIsOff_LampCanTurnOn()
        {
            EcoLamp newlamp = new EcoLamp();

            DateTime Time = DateTime.Parse("2025-11-05 07:59 ");

            newlamp.SwitchOnOff();

            Assert.True(newlamp.IsOn);

        }

        [Fact]

        public void When_DateTimeIsLaterThan18AndLampIsOff_LampCanTurnOn()
        {
            EcoLamp newlamp = new EcoLamp();

            DateTime Time = DateTime.Parse("2025-11-05 18:01 ");

            newlamp.SwitchOnOff();

            Assert.True(newlamp.IsOn);

        }


        [Fact]

        public void When_DateTimeIsLaterThanBetween18And8AndLampIsOff_LampCannotTurnOn()
        {
            EcoLamp newlamp = new EcoLamp();

            DateTime Time = DateTime.Parse("2025-11-05 23:59 ");

            newlamp.SwitchOnOff();

            Assert.False(newlamp.IsOn);

        }


        [Fact]

        public void When_DateTimeIsBetween18And8AndLampIsOn_LampTurnsOff()
        {
            EcoLamp newlamp = new EcoLamp();

            newlamp.SwitchOnOff();

            DateTime Time = DateTime.Parse("2025-11-05 23:59 ");
        
            Assert.False(newlamp.IsOn);

        }
    }

}