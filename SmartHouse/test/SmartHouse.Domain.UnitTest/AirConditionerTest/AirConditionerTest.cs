using SmartHouse.Domain.Doors;
using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.AirConditionerTest
{
    public class AirConditionerTest
    {
        [Fact]
        public void When_TheNameOfTheAirConditionerIsEmpty_TheNameIsNotValid()
        {
            Assert.Throws<ArgumentException>(() => new AirConditioner(string.Empty));
        }

        [Fact]
        public void When_TheAirConditionerIsOff_CanTurnOnIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOn_CannotTurnOnIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();

            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchOn());
        }

        [Fact]
        public void When_TheAirConditionerIsOn_CanTurnOffIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SwitchOff();

            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOff_CannotTurnOffIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SwitchOff());
        }


        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnLowFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedLow());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnLowFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetFanSpeedLow();

            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnMediumFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedMedium());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnMediumFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetFanSpeedMedium();

            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnHighFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedHigh());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnHighFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.SetFanSpeedHigh();

            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseFanSpeed());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.IncreaseFanSpeed();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeedButTheSpeedIsAlreadyAtMaximum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.IncreaseFanSpeed();

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseFanSpeed());
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseFanSpeed());
            Assert.Equal(DeviceStatus.Off, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.DecreaseFanSpeed();

            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeedButTheSpeedIsAlreadyAtMinimum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.SwitchOn();
            newAirConditioner.DecreaseFanSpeed();

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseFanSpeed());
            Assert.Equal(DeviceStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
        }
    }
}
