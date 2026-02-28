using SmartHouse.Domain.TemperatureDevice;
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

        public void When_WnatToSetNewTemperatureAndNewTempIsValid_SetNewTempCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SwitchOn();
            newThemostat.SetTemperature(28);

            Assert.Equal(Temperature.Create(28), newThemostat.Temperature);
        }

        [Fact]

        public void When_WantToIncreaseTemperatureAndIsNotAlredyAtMaxTemperature_IncreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SwitchOn();
            newThemostat.SetTemperature(29.9);
            newThemostat.IncreaseTemperature();

            Assert.Equal(Temperature.Create(30), newThemostat.Temperature);
        }

        [Fact]

        public void When_WantToDecreaseTemperatureAndIsNotAlredyAtMaxTemperature_DecreaseTemperatureCorrectly()
        {
            Thermostat newThemostat = new Thermostat("Franco");

            newThemostat.SwitchOn();
            newThemostat.SetTemperature(15.1);
            newThemostat.DecreaseTemperature();

            Assert.Equal(Temperature.Create(15), newThemostat.Temperature);
        }
    }
}
