namespace SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void When_TryToAddANewEcoLampAndTheNumberOfLampIsLessThan2_CanAddANewEcoLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddEcoLamp();

            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddANewEcoLampAndTheNumberOfLampIsGreaterThan2_CannotAddANewEcoLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.AddEcoLamp();

            Assert.Equal(2, newTwoLampDevice.Lamps.Count);
        }

        [Fact]
        public void When_TryToAddANewLampAndTheNumberOfLampIsLessThan2_CanAddANewLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();

            Assert.IsType<Lamp>(newTwoLampDevice.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddANewLampAndTheNumberOfLampIsGreaterThan2_CannotAddANewLamp()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.AddLamp();
            newTwoLampDevice.AddLamp();

            Assert.Equal(2, newTwoLampDevice.Lamps.Count);
        }

        [Fact]
        public void When_TryToAddTwoNewDifferentLamps_CanAddTwoNewDifferentLamps()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.AddLamp();

            Assert.Equal(2, newTwoLampDevice.Lamps.Count);
            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamps[0]);
            Assert.IsType<Lamp>(newTwoLampDevice.Lamps[1]);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOff_ItCanTurnOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.SwitchOnOff(0);

            Assert.True(newTwoLampDevice.Lamps[0].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOff_ItCanTurnOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.AddLamp();
            newTwoLampDevice.SwitchOnOff(1);

            Assert.True(newTwoLampDevice.Lamps[1].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.SwitchOnOff(0);
            newTwoLampDevice.SwitchOnOff(0);

            Assert.False(newTwoLampDevice.Lamps[0].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOn_ItCanTurnOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.AddLamp();
            newTwoLampDevice.SwitchOnOff(1);
            newTwoLampDevice.SwitchOnOff(1);

            Assert.False(newTwoLampDevice.Lamps[1].IsOn);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0_ItCanChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.SwitchOnOff(0);
            newTwoLampDevice.ChangeBrightness(25, 0);

            Assert.Equal(25, newTwoLampDevice.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1_ItCanChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddLamp();
            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.SwitchOnOff(1);
            newTwoLampDevice.ChangeBrightness(25, 1);

            Assert.Equal(25, newTwoLampDevice.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0ButIsOff_ItCannotChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.ChangeBrightness(25, 0);

            Assert.Equal(0, newTwoLampDevice.Lamps[0].Brightness);
        }
        
        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1ButIsOff_ItCannotChangeBrightness()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice();

            newTwoLampDevice.AddEcoLamp();
            newTwoLampDevice.AddLamp();
            newTwoLampDevice.ChangeBrightness(25, 1);

            Assert.Equal(0, newTwoLampDevice.Lamps[1].Brightness);
        }





    }
}
