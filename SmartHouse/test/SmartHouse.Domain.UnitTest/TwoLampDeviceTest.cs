namespace SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {
        Lamp testLamp = new Lamp("Stefano");
        Lamp testLamp2 = new Lamp("Stefano");
        EcoLamp testEcoLamp = new EcoLamp("Lepri");
        EcoLamp testEcoLamp2 = new EcoLamp("Lepri");

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

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);
        }

        [Fact]
        public void When_TheSelectedLampIs2AndItIsOff_ItCanTurnOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(1);
            newTwoLampDevice.SwitchOnOff(1);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);
        }

        [Fact]
        public void When_TheSelectedLampIs2AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOnOff(2);
            newTwoLampDevice.SwitchOnOff(2);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
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
            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);
        }
        
        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs2ButIsOff_ItCannotChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.ChangeBrightness(25, 2);

            Assert.Equal(0, newTwoLampDevice.Lamp2.Brightness);
            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
        }





    }
}
