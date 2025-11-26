using SmartHouse.Domain.Illumination;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
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

        [Fact]
        public void When_AllLampSwitchOn_AllLampsAreSwitchedOn()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.AllSwitchOn();


            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);
            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[1].Status);


        }

        [Fact]
        public void When_AllLampSwitchOff_AllLampsAreSwitchedOff()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgo", lamps);


            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefano2");
            newLampsRow.AllSwitchOn();
            newLampsRow.AllSwitchOff();


            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);
            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[1].Status);


        }

        [Fact]
        public void When_WantToAddANewLampInAPosition_CanAddItOnThatPosition()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);
            AbstractLamp lamp = new Lamp("Lepri");

            newLampsRow.AddEcoLamp("Stefano");
            newLampsRow.AddEcoLamp("Stefan2");

            newLampsRow.AddLampInPosition(lamp, 1);

            Assert.Equal(lamp, lamps[1]);
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void When_WantToAddANewEcoLampInAPosition_CanAddItOnThatPosition()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);
            AbstractLamp ecoLamp = new EcoLamp("Lepri");

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddLamp("Stefan2");

            newLampsRow.AddLampInPosition(ecoLamp, 1);

            Assert.Equal(ecoLamp, lamps[1]);
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0WithItsIDButIsOff_ItCannotChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            Guid id = newLampsRow.Lamps[0].Id;
            newLampsRow.SingleLampChangeBrightness(25, id);

            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[0].Status);
            Assert.Equal(newLampsRow.Lamps[0].MinBrightness, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheLampSelectedIs0WithItsIDAndIsOn_ItCanChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            Guid id = newLampsRow.Lamps[0].Id;
            newLampsRow.SwitchOn(id);
            newLampsRow.SingleLampChangeBrightness(25, id);

            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[0].Status);
            Assert.Equal(25, newLampsRow.Lamps[0].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheEcoLampSelectedIs1WithItsIDButIsOff_ItCannotChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            Guid id = newLampsRow.Lamps[1].Id;
            newLampsRow.SingleLampChangeBrightness(25, id);

            Assert.Equal(DeviceStatus.Off, newLampsRow.Lamps[1].Status);
            Assert.Equal(newLampsRow.Lamps[1].MinBrightness, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]
        public void When_WantToChangeBrightnessTo25AndTheEcoLampSelectedIs0WithItsIDAndIsOn_ItCanChangeBrightness()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            Guid id = newLampsRow.Lamps[1].Id;
            newLampsRow.SwitchOn(id);
            newLampsRow.SingleLampChangeBrightness(25, id);

            Assert.Equal(DeviceStatus.On, newLampsRow.Lamps[1].Status);
            Assert.Equal(25, newLampsRow.Lamps[1].Brightness);
        }

        [Fact]

        public void When_LampsRowHas3LampsAndThe2HasTheHighestBrightness_Return2Lamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SingleLampChangeBrightness(65, "Lepri");

            Assert.Equal(newLampsRow.Lamps[1], newLampsRow.FindLampWithMaxBrightness());

        }

        [Fact]

        public void When_LampsRowHas3LampsAndThe3HasTheHighestBrightness_Return3Lamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(65, "Stefanetto");

            Assert.Equal(newLampsRow.Lamps[2], newLampsRow.FindLampWithMaxBrightness());

        }

        [Fact]

        public void When_LampsRowHas3LampsAndThe2HasTheLowestBrightness_Return2Lamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Stefanetto");

            Assert.Equal(newLampsRow.Lamps[1], newLampsRow.FindLampWithMinBrightness());

        }

        [Fact]

        public void When_LampsRowHas3LampsAndThe3HasTheLowestBrightness_Return3Lamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(25, "Stefanetto");

            Assert.Equal(newLampsRow.Lamps[2], newLampsRow.FindLampWithMinBrightness());

        }

        [Fact]

        public void When_LampsRowHas3LampsAnd2OfThemAreInsideTheBrightnessRange30_50_ReturnAListWithThose2Lamps()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(25, "Stefanetto");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[0], newLampsRow.Lamps[1] };

            Assert.Equal(lamp, newLampsRow.FindLampsByIntensityRange(30, 50));


        }


        [Fact]

        public void When_LampsRowHas3LampsAnd2OfThemAreInsideTheBrightnessRange20_30_ReturnAListWithThose2Lamps()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(25, "Stefanetto");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[1], newLampsRow.Lamps[2] };

            Assert.Equal(lamp, newLampsRow.FindLampsByIntensityRange(20, 30));


        }

        [Fact]

        public void When_LampsRowHas3LampsAnd2OfThemAreOn_ReturnAListWithThose2Lamps()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SwitchOn("Stefano");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[0], newLampsRow.Lamps[1] };

            Assert.Equal(lamp, newLampsRow.FindAllOn());
        }

        [Fact]

        public void When_LampsRowHas3LampsAnd1OfThemIsOff_ReturnAListWithThatLamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SwitchOn("Stefano");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[2]};

            Assert.Equal(lamp, newLampsRow.FindAllOff());
        }

        [Fact]

        public void When_FindLampById_ReturnCorrectLamp()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            Guid id = newLampsRow.Lamps[1].Id;

            Assert.Equal(newLampsRow.Lamps[1], newLampsRow.FindLampById(id));
        }

        [Fact]

        public void When_SortListInAscendingOrder_SortTheListCorrectly()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(85, "Stefanetto");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[1], newLampsRow.Lamps[0], newLampsRow.Lamps[2] };

            Assert.Equal(lamp, newLampsRow.SortByIntensity(false));
        }

        [Fact]

        public void When_SortListInDescendingOrder_SortTheListCorrectly()
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            LampsRow newLampsRow = new LampsRow("Giorgio", lamps);

            newLampsRow.AddLamp("Stefano");
            newLampsRow.AddEcoLamp("Lepri");
            newLampsRow.AddLamp("Stefanetto");
            newLampsRow.SwitchOn("Stefanetto");
            newLampsRow.SwitchOn("Stefano");
            newLampsRow.SwitchOn("Lepri");
            newLampsRow.SingleLampChangeBrightness(85, "Stefanetto");

            List<AbstractLamp> lamp = new List<AbstractLamp>() { newLampsRow.Lamps[2], newLampsRow.Lamps[0], newLampsRow.Lamps[1] };

            Assert.Equal(lamp, newLampsRow.SortByIntensity(true));
        }



    }
}
