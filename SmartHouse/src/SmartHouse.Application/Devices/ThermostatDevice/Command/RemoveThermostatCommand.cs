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
    public class RemoveThermostatCommand
    {
        private readonly IThermostatRepository _thermostatRepository;

        public RemoveThermostatCommand(IThermostatRepository thermostatRepository)
        {
            _thermostatRepository = thermostatRepository;
        }

        public void Execute(Guid thermostatId)
        {
            Thermostat thermostat = _thermostatRepository.GetById(thermostatId);
            if (thermostat != null)
            {
                _thermostatRepository.Delete(thermostatId);
                _thermostatRepository.Update(thermostat);
            }
        }
    }
}
