using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class AddThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;

        public AddThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(string thermostatName)
        {
            _thermostatRepository.Add(new Thermostat(thermostatName));
        }
    }
}
