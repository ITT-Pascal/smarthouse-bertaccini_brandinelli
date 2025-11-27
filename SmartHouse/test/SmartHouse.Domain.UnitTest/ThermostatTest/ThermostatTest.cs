using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.UnitTest.ThermostatTest
{
    public class ThermostatTest
    {
        [Fact]

        public void When_GivenANullStringAsAName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Thermostat(null));
        }

        [Fact]

        public void When_GivenAnEmptyStringAsAName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Thermostat(string.Empty));           
        }

        [Fact]

        public void  When_GivenANameThatIsOnlySpaces_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Thermostat("    "));
        }

        [Fact]

        public void When_WnatToSetNewTemperatureButNewTempIsHigherThanMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThermostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThermostat.SetTemperature(30.1));
        }

        [Fact]

        public void When_WnatToSetNewTemperatureButNewTempIsLowerThanMinTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            Assert.Throws<ArgumentException>(() => newThemostat.SetTemperature(14.9));
        }

        [Fact]

        public void When_WnatToSetNewTemperatureAndNewTempIsValid_SetNewTempCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(28);

            Assert.Equal(28, newThemostat.Temperature);
        }

        [Fact]

        public void When_WantToIncreaseTemperatureButIsAlredyAtMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(30);

            Assert.Throws<ArgumentException>(() => newThemostat.IncreaseTemperature());
        }

        [Fact]

        public void When_WantToIncreaseTemperatureAndIsNotAlredyAtMaxTemperature_IncreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(29.9);
            newThemostat.IncreaseTemperature();

            Assert.Equal(30, newThemostat.Temperature);
        }

        [Fact]

        public void When_WantToDecreaseTemperatureButIsAlredyAtMaxTemperature_ThrowArgumentException()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(15);

            Assert.Throws<ArgumentException>(() => newThemostat.DecreaseTemperature());
        }

        [Fact]

        public void When_WantToDecreaseTemperatureAndIsNotAlredyAtMaxTemperature_DecreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SetTemperature(15.1);
            newThemostat.DecreaseTemperature();

            Assert.Equal(15, newThemostat.Temperature);
        }
    }
}
