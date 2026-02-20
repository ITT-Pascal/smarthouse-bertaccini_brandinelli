using SmartHouse.Domain.TemperatureDevice;
using SmartHouse.Domain.TemperatureDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.ThermostatDevice.Queries
{
    public class ThermostatGetAllQuery
    {
        private readonly IThermostatRepository _repository;

        public ThermostatGetAllQuery(IThermostatRepository repos)
        {
            _repository = repos;
        }

        public List<Thermostat> Execute()
        {
            List<Thermostat> result = new List<Thermostat>();

            foreach(Thermostat t in _repository.GetAll())
            {
                if (t != null)
                    result.Add(t);
            }
            return result;
        }
    }
}
