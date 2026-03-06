using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class ThermostatSwitchOffCommand
    {
        private readonly IThermostatRepository _repository;

        public ThermostatSwitchOffCommand(IThermostatRepository repos)
        {
            _repository = repos;
        }

        public void Execute(Guid id)
        {
            var thermostat = _repository.GetById(id);
            if (thermostat != null)
            {
                thermostat.SwitchOff();
                _repository.Update(thermostat);
            }
        }
    }
}
