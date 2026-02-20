using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class ThermostatDecreaseTemperatureCommand
    {
        private readonly IThermostatRepository _thermostarepository;

        public ThermostatDecreaseTemperatureCommand(IThermostatRepository thermostatRepository)
        {
            _thermostarepository = thermostatRepository;
        }

        public void Execute(Guid id)
        {
            Thermostat t = _thermostarepository.GetById(id);
            if (t != null)
            {
                t.DecreaseTemperature();
                _thermostarepository.Update(t);
            }
        }
    }
}
