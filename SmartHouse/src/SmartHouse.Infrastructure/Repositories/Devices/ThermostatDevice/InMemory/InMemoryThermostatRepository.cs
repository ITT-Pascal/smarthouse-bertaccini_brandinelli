using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Repositories.Devices.ThermostatDevice.InMemory
{
    public class InMemoryThermostatRepository : IThermostatRepository
    {
        private readonly List<Thermostat> _thermostats;

        public InMemoryThermostatRepository()
        {
            _thermostats = new List<Thermostat>
            {
                new Thermostat("Franco"),
                new Thermostat("Matteo"),
                new Thermostat("Giacomo")
            };
        }

        public List<Thermostat> GetAll()
        {
            return _thermostats;
        }

        public Thermostat GetById(Guid id)
        {
            return _thermostats.FirstOrDefault(thermostat => thermostat.Id == id);
        }

        public void Add(Thermostat t)
        {
            if (t != null)
                _thermostats.Add(t);
            else
                throw new ArgumentException("Thermostat cannot be null");
        }

        public void Delete(Guid id)
        {
            var thermostat = GetById(id);

            if (thermostat != null)
                _thermostats.Remove(thermostat);
        }

        public void Update(Thermostat t)
        {
            //To do
        }
    }
}
