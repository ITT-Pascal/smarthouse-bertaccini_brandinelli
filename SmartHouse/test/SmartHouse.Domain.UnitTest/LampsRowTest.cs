namespace SmartHouse.Domain.UnitTest
{
    public class LampsRowTest
    {
        [Fact]
        public void When_TryToAddANewEcoLamp_CanAddANewEcoLamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddEcoLamp("Lepri");

            Assert.IsType<EcoLamp>(newLampsRow.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddANewLamp_CanAddANewLamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");

            Assert.IsType<Lamp>(newLampsRow.Lamps[0]);
        }

        [Fact]
        public void When_TryToAddTwoNewDifferentLamps_CanAddTwoNewDifferentLamps()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefano");

            Assert.Equal(2, newLampsRow.Lamps.Count);
            Assert.IsType<EcoLamp>(newLampsRow.Lamps[0]);
            Assert.IsType<Lamp>(newLampsRow.Lamps[1]);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOff_ItCanTurnOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.SingleLampSwitchOnOff("Stefano");

            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOff_ItCanTurnOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.SingleLampSwitchOnOff("Stefano");

            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[1].Status);
        }

        [Fact]
        public void When_TheSelectedLampIs0AndItIsOn_ItCanTurnOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.SingleLampSwitchOnOff("Stefano");
            newLampsRow.SingleLampSwitchOnOff("Stefano");

            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);
        }

        [Fact]
        public void When_TheSelectedLampIs1AndItIsOn_ItCanTurnOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.SingleLampSwitchOnOff("Stefano2");
            newLampsRow.SingleLampSwitchOnOff("Stefano2");

            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[1].Status);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0_ItCanChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.SingleLampSwitchOnOff("Stefano");
            newLampsRow.SingleLampChangeBrightness(25, "Stefano");

            Assert.Equal(25, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1_ItCanChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.SingleLampSwitchOnOff("Lepri");
            newLampsRow.SingleLampChangeBrightness(25, "Lepri");

            Assert.Equal(25, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0ButIsOff_ItCannotChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.SingleLampChangeBrightness(25, "Lepri");

            Assert.Equal(0, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs1ButIsOff_ItCannotChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.SingleLampChangeBrightness(25, "Stefano");

            Assert.Equal(0, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_SelectBothLampsAndTheyAreOff_TheyCanTurnOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.AllLampsSwitchOnOff();

            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);
            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[1].Status);
        }

        [Fact]
        public void When_SelectBothLampsAndTheyAreOn_TheyCanTurnOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.AllLampsSwitchOnOff();
            newLampsRow.AllLampsSwitchOnOff();

            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);
            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[1].Status);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndSelectBothLamps_TheyCanChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.AllLampsSwitchOnOff();
            newLampsRow.AllLampsChangeBrightness(25);

            Assert.Equal(25, newLampsRow.Lamps[0].Brightness);
            Assert.Equal(25, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndSelectBothLampsButAreOff_TheyCannotChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.AllLampsChangeBrightness(25);

            Assert.Equal(0, newLampsRow.Lamps[0].Brightness);
            Assert.Equal(0, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]

        public void When_RemoveLampIsGivenAName_RemoveLampWithThatName()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);
            

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.RemoveLamp("Stefano");


            Assert.Equal("Stefano2", newLampsRow.Lamps[0].Name);

        }

        [Fact]

        public void When_RemoveLampIsGivenAName_RemoveAllLampsWithThatName()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.AddLamp("Stefano");
            newLampsRow.RemoveLamp("Stefano");


            Assert.Equal(1, newLampsRow.Lamps.Count);

        }

        [Fact]

        public void When_RemoveLampIsGivenAnId_RemoveLampWithThatId()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            Guid id = newLampsRow.Lamps[0].Id;
            newLampsRow.RemoveLamp(id);


            Assert.Equal("Stefano2", newLampsRow.Lamps[0].Name);

        }

        [Fact]

        public void When_RemoveLampIsGivenAPosition_RemoveLampInThatPosition()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.RemoveLampInPosition("Stefano", 0);


            Assert.Equal("Stefano2", newLampsRow.Lamps[0].Name);

        }

        [Fact]

        public void When_SwitchOnIsGivenAnId_LampWithThatIdIsSwitchedOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            Guid id = newLampsRow.Lamps[0].Id;
            newLampsRow.SwitchOn(id);


            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);

        }

        [Fact]
        public void When_SwitchOffIsGivenAnId_LampWithThatIdIsSwitchedOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            Guid id = newLampsRow.Lamps[0].Id;
            newLampsRow.AllLampsSwitchOnOff();
            newLampsRow.SwitchOff(id);


            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);

        }

        [Fact]
        public void When_SwitchOnIsGivenAName_LampWithThatNameIsSwitchedOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");           
            newLampsRow.SwitchOn("Stefano");


            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);

        }

        [Fact]
        public void When_SwitchOffIsGivenAName_LampWithThatNameIsSwitchedOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.SwitchOff("Stefano");


            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);

        }


    }
}
