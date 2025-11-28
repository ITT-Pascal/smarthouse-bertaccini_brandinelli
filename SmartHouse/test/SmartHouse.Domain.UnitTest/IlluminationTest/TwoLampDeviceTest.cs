using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.Abstractions;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
{
    public class TwoLampDeviceTest
    {
        Lamp testLamp = new Lamp("Stefano");
        Lamp testLamp2 = new Lamp("Stefano");
        EcoLamp testEcoLamp = new EcoLamp("Lepri");
        EcoLamp testEcoLamp2 = new EcoLamp("Lepri");

        [Fact]
        public void When_TryToConstructTwoLampDeviceWithOneLampAndOneEcoLamp_CanConstruct()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            Assert.IsType<Lamp>(newTwoLampDevice.Lamp1);
            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamp2);
        }

        [Fact]
        public void When_TryToConstructTwoLampDeviceWithTwoLamps_CanConstruct()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testLamp2);

            Assert.IsType<Lamp>(newTwoLampDevice.Lamp1);
            Assert.IsType<Lamp>(newTwoLampDevice.Lamp2);
        }

        [Fact]
        public void When_TryToConstructTwoLampDeviceWithTwoEcoLamps_CanConstruct()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamp1);
            Assert.IsType<EcoLamp>(newTwoLampDevice.Lamp2);
        }

        [Fact]

        public void When_SelectedLampIsSmallerThan1_Throw()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOnOff(0));

        }

        [Fact]

        public void When_SelectedLampIsHigherThan2_Throw()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOnOff(3));

        }

        [Fact]

        public void When_SelectedLampIsSmallerThan1_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.ChangeBrightness(10, 0));

        }

        [Fact]

        public void When_SelectedLampIsHigherThan2_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.ChangeBrightness(10, 3));

        }

        [Fact]

        public void When_SwitchOnAndSelectedLampIsSmallerThan1_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOn(0));

        }

        [Fact]

        public void When_SwitchOnAndSelectedLampIsHigherThan2_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOn(3));

        }

        [Fact]

        public void When_SwitchOffAndSelectedLampIsSmallerThan1_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOff(0));

        }

        [Fact]

        public void When_SwitchOffAndSelectedLampIsHigherThan2_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.SwitchOff(3));

        }

        [Fact]

        public void When_DimmerAndSelectedLampIsSmallerThan1_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.Dimmer(0));

        }

        [Fact]

        public void When_DimmerAndSelectedLampIsHigherThan2_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.Dimmer(3));

        }

        [Fact]

        public void When_BrightenAndSelectedLampIsSmallerThan1_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.Brighten(0));

        }

        [Fact]

        public void When_BrightenAndSelectedLampIsHigherThan2_ThrowArgumentException()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testEcoLamp, testEcoLamp2);

            Assert.Throws<ArgumentException>(() => newTwoLampDevice.Brighten(3));

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

        [Fact]

        public void When_WantToSwitchOnLamp1AndIsOff_TurnsOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);
        }

        [Fact]

        public void When_WantToSwitchOnLamp1AndIsAlredyOn_RemainsOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);

            newTwoLampDevice.SwitchOn(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);
        }

        [Fact]

        public void When_WantToSwitchOnLamp2AndIsOff_TurnsOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);
        }

        [Fact]

        public void When_WantToSwitchOnLamp2AndIsAlredyOn_RemainsOn()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);

            newTwoLampDevice.SwitchOn(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);
        }



        [Fact]

        public void When_WantToSwitchOffLamp1AndIsOn_TurnsOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);

            newTwoLampDevice.SwitchOff(1);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);
        }

        [Fact]

        public void When_WantToSwitchOffLamp1AndIsAlredyOff_RemainsOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);

            newTwoLampDevice.SwitchOff(1);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);         
        }

        [Fact]

        public void When_WantToSwitchOffLamp2AndIsOn_TurnsOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);

            newTwoLampDevice.SwitchOff(2);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
        }

        [Fact]

        public void When_WantToSwitchOffLamp2AndIsAlredyOff_RemainsOff()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);

            newTwoLampDevice.SwitchOff(2);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
        }       

        [Fact]

        public void When_WantToBrightenLamp1AndLampIsOn_Brighten()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);          

            newTwoLampDevice.SwitchOn(1);
            newTwoLampDevice.Brighten(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);
            Assert.Equal(60, newTwoLampDevice.Lamp1.Brightness);
        }

        [Fact]

        public void When_WantToBrightenLamp1AndLampIsOff_DoesNotBrighten()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.Brighten(1);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);
            Assert.Equal(newTwoLampDevice.Lamp1.MinBrightness, newTwoLampDevice.Lamp1.Brightness);
        }

        [Fact]

        public void When_WantToBrightenLamp2AndLampIsOn_Brighten()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(2);
            newTwoLampDevice.Brighten(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);
            Assert.Equal(40, newTwoLampDevice.Lamp2.Brightness);
        }

        [Fact]

        public void When_WantToBrightenLamp2AndLampIsOff_DoesNotBrighten()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.Brighten(2);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
            Assert.Equal(newTwoLampDevice.Lamp2.MinBrightness, newTwoLampDevice.Lamp2.Brightness);
        }


        [Fact]

        public void When_WantToDimmerLamp1AndLampIsOn_Dim()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(1);
            newTwoLampDevice.Dimmer(1);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp1.Status);
            Assert.Equal(40, newTwoLampDevice.Lamp1.Brightness);
        }

        [Fact]

        public void When_WantToDimmerLamp1AndLampIsOff_DoesNotDim()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.Dimmer(1);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp1.Status);
            Assert.Equal(newTwoLampDevice.Lamp1.MinBrightness, newTwoLampDevice.Lamp1.Brightness);
        }

        [Fact]

        public void When_WantToDimmerLamp2AndLampIsOn_Dim()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.SwitchOn(2);
            newTwoLampDevice.Dimmer(2);

            Assert.Equal(DeviceStatus.On, newTwoLampDevice.Lamp2.Status);
            Assert.Equal(20, newTwoLampDevice.Lamp2.Brightness);
        }

        [Fact]

        public void When_WantToDimmerLamp2AndLampIsOff_DoesNotDim()
        {
            TwoLampDevice newTwoLampDevice = new TwoLampDevice(testLamp, testEcoLamp);

            newTwoLampDevice.Dimmer(2);

            Assert.Equal(DeviceStatus.Off, newTwoLampDevice.Lamp2.Status);
            Assert.Equal(newTwoLampDevice.Lamp2.MinBrightness, newTwoLampDevice.Lamp2.Brightness);
        }










    }
}
