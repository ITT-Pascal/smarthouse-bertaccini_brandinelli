using SmartHouse.Domain.Doors;
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

            newAirConditioner.TurnOn();

            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOn_CanTurnOffIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.TurnOff();

            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseTemperature_CannotIncreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseTemperature());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseTemperature_CanIncreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.IncreaseTemperature();

            Assert.Equal(20.1, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseTemperature_CannotDecreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseTemperature());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseTemperature_CanDecreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.DecreaseTemperature();

            Assert.Equal(19.9, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseTemperatureTo22_CannotIncreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseTemperature(2.0));
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseTemperatureTo22_CanIncreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.IncreaseTemperature(2.0);

            Assert.Equal(22.0, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseTemperatureToTheMax_CanIncreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.IncreaseTemperature(20.0);

            Assert.Equal(newAirConditioner.MaxTemperature, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseTemperatureTo18_CannotDecreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseTemperature(2.0));
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseTemperatureTo18_CanDecreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.DecreaseTemperature(2.0);

            Assert.Equal(18.0, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseTemperatureToTheMin_CanDecreaseIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.DecreaseTemperature(20.0);

            Assert.Equal(newAirConditioner.MinTemperature, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnMaxTemperature_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetMaxTemperature());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnMaxTemperature_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.SetMaxTemperature();

            Assert.Equal(newAirConditioner.MaxTemperature, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnMinTemperature_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetMinTemperature());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnMinTemperature_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.SetMinTemperature();

            Assert.Equal(newAirConditioner.MinTemperature, newAirConditioner.Temperature);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnLowFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedLow());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnLowFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.SetFanSpeedLow();

            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnMediumFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedMedium());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnMediumFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.SetFanSpeedMedium();

            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToSetItOnHighFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.SetFanSpeedHigh());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToSetItOnHighFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.SetFanSpeedHigh();

            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToIncreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseFanSpeed());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.IncreaseFanSpeed();

            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToIncreaseFanSpeedButTheSpeedIsAlreadyAtMaximum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.IncreaseFanSpeed();

            Assert.Throws<ArgumentException>(() => newAirConditioner.IncreaseFanSpeed());
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.High, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToDecreaseFanSpeed_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseFanSpeed());
            Assert.Equal(AirConditionerStatus.Off, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Medium, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeed_CanDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.DecreaseFanSpeed();

            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToDecreaseFanSpeedButTheSpeedIsAlreadyAtMinimum_CannotDoIt()
        {
            AirConditioner newAirConditioner = new AirConditioner("Pino");

            newAirConditioner.TurnOn();
            newAirConditioner.DecreaseFanSpeed();

            Assert.Throws<ArgumentException>(() => newAirConditioner.DecreaseFanSpeed());
            Assert.Equal(AirConditionerStatus.On, newAirConditioner.Status);
            Assert.Equal(FanSpeed.Low, newAirConditioner.FanSpeed);
        }
    }
}
