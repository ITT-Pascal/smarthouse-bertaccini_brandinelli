namespace SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {
        Lamp testLamp = new Lamp();
        Lamp testLamp2 = new Lamp();
        EcoLamp testEcoLamp = new EcoLamp();
        EcoLamp testEcoLamp2 = new EcoLamp();

        [Fact]
        public void When_TryToAddANewEcoLampAndTheNumberOfLampIsLessThan2_CanAddANewEcoLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            Assert.IsType<Lamp>(newTwoLampDevice.Lamp1);
            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamp2);
        }

        [Fact]
        public void When_TryToAddANewLampAndTheNumberOfLampIsLessThan2_CanAddANewLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            Assert.IsType<Lamp>(newTwoLampDevice.Lamp1);
            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamp2);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOff_ItCanTurnOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(1);

            Assert.True(newTwoLampDevice.Lamp1.IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs2AndItIsOff_ItCanTurnOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(2);

            Assert.True(newTwoLampDevice.Lamp2.IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(1);
            newTwoLampDevice.SwitchOnOff(1);

            Assert.False(newTwoLampDevice.Lamp1.IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs2AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(2);
            newTwoLampDevice.SwitchOnOff(2);

            Assert.False(newTwoLampDevice.Lamp2.IsOn);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1_ItCanChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(1);
            newTwoLampDevice.ChangeBrightness(25, 1);

            Assert.Equal(25, newTwoLampDevice.Lamp1.Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs2_ItCanChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(2);
            newTwoLampDevice.ChangeBrightness(25, 2);

            Assert.Equal(25, newTwoLampDevice.Lamp2.Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1ButIsOff_ItCannotChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.ChangeBrightness(25, 1);

            Assert.Equal(0, newTwoLampDevice.Lamp1.Brightness);
            Assert.False(newTwoLampDevice.Lamp1.IsOn);
        }
        
        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs2ButIsOff_ItCannotChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.ChangeBrightness(25, 2);

            Assert.Equal(0, newTwoLampDevice.Lamp2.Brightness);
            Assert.False(newTwoLampDevice.Lamp2.IsOn);
        }





    }
}
