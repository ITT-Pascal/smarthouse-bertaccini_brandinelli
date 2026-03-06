using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class ThermostatSwitchOnCommand
    {
        private readonly IThermostatRepository _repository;

        public ThermostatSwitchOnCommand(IThermostatRepository repos)
        {
            _repository = repos;
        }

        public void Execute(Guid id)
        {
            var thermostat = _repository.GetById(id);
            if(thermostat != null)
            {
                thermostat.SwitchOn();
                _repository.Update(thermostat);
            }
        }
    }
}
