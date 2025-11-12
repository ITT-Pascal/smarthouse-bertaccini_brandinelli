namespace SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {
        [Fact]
        public void When_TryToAddANewEcoLamp_CanAddANewEcoLamp()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddEcoLamp();

            Assert.IsType<EcoLamp>(newLampsRow.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddANewLamp_CanAddANewLamp()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();

            Assert.IsType<Lamp>(newLampsRow.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddTwoNewDifferentLamps_CanAddTwoNewDifferentLamps()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddEcoLamp();
            newLampsRow.AddLamp();

            Assert.Equal(2, newLampsRow.Lamps.Count);
            Assert.IsType<EcoLamp>(newLampsRow.Lamps[0]);
            Assert.IsType<Lamp>(newLampsRow.Lamps[1]);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOff_ItCanTurnOn()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.SingleLampSwitchOnOff(0);

            Assert.True(newLampsRow.Lamps[0].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOff_ItCanTurnOn()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.SingleLampSwitchOnOff(1);

            Assert.True(newLampsRow.Lamps[1].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOn_ItCanTurnOff()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.SingleLampSwitchOnOff(0);
            newLampsRow.SingleLampSwitchOnOff(0);

            Assert.False(newLampsRow.Lamps[0].IsOn);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOn_ItCanTurnOff()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.SingleLampSwitchOnOff(1);
            newLampsRow.SingleLampSwitchOnOff(1);

            Assert.False(newLampsRow.Lamps[1].IsOn);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0_ItCanChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.SingleLampSwitchOnOff(0);
            newLampsRow.SingleLampChangeBrightness(25, 0);

            Assert.Equal(25, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1_ItCanChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddEcoLamp();
            newLampsRow.SingleLampSwitchOnOff(1);
            newLampsRow.SingleLampChangeBrightness(25, 1);

            Assert.Equal(25, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0ButIsOff_ItCannotChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddEcoLamp();
            newLampsRow.SingleLampChangeBrightness(25, 0);

            Assert.Equal(0, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1ButIsOff_ItCannotChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddEcoLamp();
            newLampsRow.AddLamp();
            newLampsRow.SingleLampChangeBrightness(25, 1);

            Assert.Equal(0, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_SelectBothLampsAndTheyAreOff_TheyCanTurnOn()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.AllLampsSwitchOnOff();

            Assert.True(newLampsRow.Lamps[0].IsOn);
            Assert.True(newLampsRow.Lamps[1].IsOn);
        }

        [Fact]
        public void When_SelectBothLampsAndTheyAreOn_TheyCanTurnOff()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.AllLampsSwitchOnOff();
            newLampsRow.AllLampsSwitchOnOff();

            Assert.False(newLampsRow.Lamps[0].IsOn);
            Assert.False(newLampsRow.Lamps[1].IsOn);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndSelectBothLamps_TheyCanChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.AllLampsSwitchOnOff();
            newLampsRow.AllLampsChangeBrightness(25);

            Assert.Equal(25, newLampsRow.Lamps[0].Brightness);
            Assert.Equal(25, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndSelectBothLampsButAreOff_TheyCannotChangeBrightness()
        {
            LampsRow newLampsRow = new LampsRow();

            newLampsRow.AddLamp();
            newLampsRow.AddLamp();
            newLampsRow.AllLampsChangeBrightness(25);

            Assert.Equal(0, newLampsRow.Lamps[0].Brightness);
            Assert.Equal(0, newLampsRow.Lamps[1].Brightness);
        }
    }
}
