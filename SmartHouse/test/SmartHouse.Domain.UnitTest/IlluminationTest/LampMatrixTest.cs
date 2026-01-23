using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
{
    public class LampMatrixTest
    {
        [Fact]
        public void When_WantToAddANewLamp_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);

            Assert.Equal(newLamp, newLampMatrix.Lamps[0,0]);
        }

        [Fact]

        public void When_WantToAdd2NewLamps_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp newLamp = new Lamp(Name.Create("Stefano"));
            AbstractLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newlampMatrix = new LampMatrix("Sasha", lamps);

            newlampMatrix.AddLamp(newLamp);
            newlampMatrix.AddLamp(newEcoLamp);

            Assert.Equal(newLamp, newlampMatrix.Lamps[0, 0]);
            Assert.Equal(newEcoLamp, newlampMatrix.Lamps[0, 1]);
        }

        [Fact]
        public void When_WantToAddANewEcoLamp_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newEcoLamp);

            Assert.Equal(newEcoLamp, lamps[0, 0]);
        }

        [Fact]
        public void When_WantToAddNewLampButMatrixIsAlreadyFull_CannotDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[1, 1];
            Lamp newLamp = new Lamp(Name.Create("Stefano"));
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);

            Assert.Throws<ArgumentException>(() => newLampMatrix.AddLamp(newLamp));
        }

        [Fact]
        public void When_WantToAddNewEcoLampButMatrixIsAlreadyFull_CannotDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[1, 1];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newEcoLamp);

            Assert.Throws<ArgumentException>(() => newLampMatrix.AddLamp(newEcoLamp));
        }

        [Fact]
        public void When_WantToAddANewLampInADeterminedPosition_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp(Name.Create("Stefano"));
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newLamp, 2, 1);

            Assert.Equal(newLamp, lamps[2, 1]);
        }

        [Fact]
        public void When_WantToAddANewEcoLampInADeterminedPosition_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newEcoLamp, 2, 1);

            Assert.Equal(newEcoLamp, lamps[2, 1]);
        }

        [Fact]
        public void When_WantToAddANewLampInADeterminedPositionButMatrixIsAlreadyFull_CannotDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[1, 1];
            Lamp newLamp = new Lamp(Name.Create("Stefano"));
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newLamp, 0, 0);

            Assert.Throws<ArgumentException>(() => newLampMatrix.AddLampInPosition(newLamp, 0, 0));
        }

        [Fact]
        public void When_WantToAddANewEcoLampInADeterminedPositionButMatrixIsAlreadyFull_CannotDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[1, 1];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newEcoLamp, 0, 0);

            Assert.Throws<ArgumentException>(() => newLampMatrix.AddLampInPosition(newEcoLamp, 0, 0));
        }

        [Fact]
        public void When_WantToRemoveALampWithItsName_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.RemoveLamp("Stefano");

            Assert.Equal(null, newLampMatrix.Lamps[0, 0]);
        }

        [Fact]
        public void When_WantToRemoveAEcoLampWithItsName_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.RemoveLamp("Lepri");

            Assert.Equal(null, newLampMatrix.Lamps[0, 0]);
        }

        [Fact]
        public void When_WantToRemoveALampWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.RemoveLamp(newLamp.Id);

            Assert.Equal(null, newLampMatrix.Lamps[0, 0]);
        }

        [Fact]
        public void When_WantToRemoveAEcoLampWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.RemoveLamp(newEcoLamp.Id);

            Assert.Equal(null, newLampMatrix.Lamps[0, 0]);
        }

        [Fact]
        public void When_WantToRemoveALampWithItsPosition_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newLamp, 2, 1);
            newLampMatrix.RemoveLampInPosition(2, 1);

            Assert.Equal(null, newLampMatrix.Lamps[2, 1]);
        }

        [Fact]
        public void When_WantToRemoveAEcoLampWithItsPosition_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLampInPosition(newEcoLamp, 2, 1);
            newLampMatrix.RemoveLampInPosition(2, 1);

            Assert.Equal(null, newLampMatrix.Lamps[2, 1]);
        }

        [Fact]
        public void When_WantToTurnOnLampWithItsName_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SwitchOn("Stefano");

            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_WantToTurnOnLampWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SwitchOn(newLamp.Id);

            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_WantToTurnOffLampWithItsName_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SwitchOn("Stefano");
            newLampMatrix.SwitchOff("Stefano");

            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_WantToTurnOffLampWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SwitchOn(newLamp.Id);
            newLampMatrix.SwitchOff(newLamp.Id);

            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_WantToTurnAllLampOn_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp1 = new Lamp("Stefano");
            Lamp newLamp2 = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp1);
            newLampMatrix.AddLamp(newLamp2);
            newLampMatrix.AllSwitchOn();

            Assert.Equal(DeviceStatus.On, newLamp1.Status);
            Assert.Equal(DeviceStatus.On, newLamp2.Status);
        }

        [Fact]
        public void When_WantToTurnAllLampOff_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp1 = new Lamp("Stefano");
            Lamp newLamp2 = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp1);
            newLampMatrix.AddLamp(newLamp2);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.AllSwitchOff();

            Assert.Equal(DeviceStatus.Off, newLamp1.Status);
            Assert.Equal(DeviceStatus.Off, newLamp2.Status);
        }

        [Fact]
        public void When_WantToToggleLampOn_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SingleLampSwitchOnOff("Stefano");

            Assert.Equal(DeviceStatus.On, newLamp.Status);
        }

        [Fact]
        public void When_WantToToggleLampOff_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.SingleLampSwitchOnOff("Stefano");
            newLampMatrix.SingleLampSwitchOnOff("Stefano");

            Assert.Equal(DeviceStatus.Off, newLamp.Status);
        }

        [Fact]
        public void When_WantToToggleAllLampOn_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[4, 4];
            Lamp newLamp1 = new Lamp("Stefano");
            Lamp newLamp2 = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp1);
            newLampMatrix.AddLamp(newLamp2);
            newLampMatrix.AllLampsSwitchOnOff();

            Assert.Equal(DeviceStatus.On, newLamp1.Status);
            Assert.Equal(DeviceStatus.On, newLamp2.Status);
        }

        [Fact]
        public void When_WantToToggleAllLampOff_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp1 = new Lamp("Stefano");
            Lamp newLamp2 = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp1);
            newLampMatrix.AddLamp(newLamp2);
            newLampMatrix.AllLampsSwitchOnOff();
            newLampMatrix.AllLampsSwitchOnOff();

            Assert.Equal(DeviceStatus.Off, newLamp1.Status);
            Assert.Equal(DeviceStatus.Off, newLamp2.Status);
        }

        [Fact]
        public void When_WantToChangeAllLampBrightness_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp1 = new Lamp("Stefano");
            Lamp newLamp2 = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp1);
            newLampMatrix.AddLamp(newLamp2);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.AllLampsChangeBrightness(50);

            Assert.Equal(50, newLamp1.Brightness);
            Assert.Equal(50, newLamp2.Brightness);
        }

        [Fact]
        public void When_WantToChangeLampBrightnessWithItsName_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, "Stefano");

            Assert.Equal(50, newLampMatrix.Lamps[0,0].Brightness);
        }

        [Fact]
        public void When_WantToChangeLampBrightnessWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);

            Assert.Equal(50, newLamp.Brightness);
        }

        [Fact]
        public void When_WantToFindTheLampWithMaxBrightness_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.FindLampWithMaxBrightness();

            Assert.Equal(newLamp, newLampMatrix.FindLampWithMaxBrightness());
        }


        [Fact]
        public void When_WantToFindTheLampWithMinBrightness_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.FindLampWithMinBrightness();

            Assert.Equal(newEcoLamp, newLampMatrix.FindLampWithMinBrightness());
        }

        [Fact]
        public void When_WantToFindTheLampInADeterminedRangeOfBrightness_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = newLamp;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.FindLampByIntensityRange(20, 80);

            Assert.Equal(result, newLampMatrix.FindLampByIntensityRange(20, 80));
        }

        [Fact]
        public void When_WantToFindTheLampInADeterminedRangeOfBrightnessButOneIsNotInItTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.FindLampByIntensityRange(20, 40);

            Assert.Equal(result, newLampMatrix.FindLampByIntensityRange(20, 40));
        }

        [Fact]
        public void When_WantToFindTheLampInADeterminedRangeOfBrightnessButNoneIsNotInItTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = null;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.FindLampByIntensityRange(20, 40);

            Assert.Equal(result, newLampMatrix.FindLampByIntensityRange(20, 25));
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOn_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = newLamp;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.FindAllOn();

            Assert.Equal(result, newLampMatrix.FindAllOn());
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOnButOneIsNotOnTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.SwitchOn(newEcoLamp.Id);
            newLampMatrix.FindAllOn();

            Assert.Equal(result, newLampMatrix.FindAllOn());
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOnButNoneIsOnTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = null;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.FindAllOn();

            Assert.Equal(result, newLampMatrix.FindAllOn());
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOff_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = newLamp;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.FindAllOff();

            Assert.Equal(result, newLampMatrix.FindAllOff());
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOffButOneIsNotOffTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = newEcoLamp;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.SwitchOn(newLamp.Id);
            newLampMatrix.FindAllOff();

            Assert.Equal(result, newLampMatrix.FindAllOff());
        }

        [Fact]
        public void When_WantToFindAllTheLampWhichAreOffButNoneIsOffTheLatterIsNotInMatrix_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp[,] result = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result[0, 0] = null;
            result[0, 1] = null;

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.FindAllOff();

            Assert.Equal(result, newLampMatrix.FindAllOff());
        }

        [Fact]
        public void When_WantToFindTheLampWithItsId_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.FindLampById(newLamp.Id);

            Assert.Equal(newLamp, newLampMatrix.FindLampById(newLamp.Id));
        }

        [Fact]
        public void When_WantToSortTheLampsInADecreasingManner_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            List<AbstractLamp> result = new List<AbstractLamp>();
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result.Add(newLamp);
            result.Add(newEcoLamp);

            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.SortByIntensity(true);

            Assert.Equal(result, newLampMatrix.SortByIntensity(true));
        }

        [Fact]
        public void When_WantToSortTheLampsInAIncreasingManner_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            List<AbstractLamp> result = new List<AbstractLamp>();
            Lamp newLamp = new Lamp("Stefano");
            EcoLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);
            result.Add(newEcoLamp);
            result.Add(newLamp);

            newLampMatrix.AddLamp(newEcoLamp);
            newLampMatrix.AddLamp(newLamp);
            newLampMatrix.AllSwitchOn();
            newLampMatrix.SingleLampChangeBrightness(50, newLamp.Id);
            newLampMatrix.SingleLampChangeBrightness(30, newEcoLamp.Id);
            newLampMatrix.SortByIntensity(false);

            Assert.Equal(result, newLampMatrix.SortByIntensity(false));
        }
    }
}
