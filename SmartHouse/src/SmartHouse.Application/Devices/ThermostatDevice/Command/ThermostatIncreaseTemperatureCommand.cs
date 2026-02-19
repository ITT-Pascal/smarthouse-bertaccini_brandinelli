using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class ThermostatIncreaseTemperatureCommand
    {
        private IThermostatRepository _thermostarepository;

        public ThermostatIncreaseTemperatureCommand(IThermostatRepository thermostatRepository)
        {
            _thermostarepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            Thermostat t = _thermostarepository.GetById(id);
            if(t != null)
            {
                t.IncreaseTemperature();
                _thermostarepository.Update(t);
            }
        }
    }
}
