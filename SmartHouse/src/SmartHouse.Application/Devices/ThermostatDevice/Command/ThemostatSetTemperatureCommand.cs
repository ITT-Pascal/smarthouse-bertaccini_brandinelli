using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Command
{
    public class ThermostatSetTemperatureCommand
    {
        private IThermostatRepository _thermostarepository;

        public ThermostatSetTemperatureCommand(IThermostatRepository thermostatRepository)
        {
            _thermostarepository = thermostatRepository;
        }

        public void Execute(Guid id, double newtemp)
        {
            Thermostat t = _thermostarepository.GetById(id);
            if (t != null)
            {
                t.SetTemperature(newtemp);
                _thermostarepository.Update(t);
            }
        }
    }
}
