using SmartHouse.Domain.AirConditionerDevice;
using SmartHouse.Domain.AirConditionerDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Infrastructure.Repositories.Devices.AirConditionerDevice.InMemory
{
    public class InMemoryAirConditionerRepository: IAirConditionerRepository
    {
        private readonly List<AirConditioner> _airConditioners;

        public InMemoryAirConditionerRepository()
        {
            _airConditioners = new List<AirConditioner>
            {
                new AirConditioner("Stefano"),
                new AirConditioner("Pasquale"),
                new AirConditioner("Giovanni")
            };
        }

        public List<AirConditioner> GetAll()
        {
            return _airConditioners;
        }

        public AirConditioner? GetById(Guid id)
        {
            AirConditioner? result = null;

            foreach (AirConditioner a in _airConditioners)
                if (a.Id == id)
                    result = a;

            return result;
        }

        public void Add(AirConditioner airConditioner)
        {
            if (airConditioner != null)
                _airConditioners.Add(airConditioner);
            else
                throw new ArgumentException("AirConditioner cannot be null");
        }

        public void Delete(Guid id)
        {
            var airConditioner = GetById(id);

            if (airConditioner != null)
                _airConditioners.Remove(airConditioner);
        }

        public void Update(AirConditioner airConditioner)
        {
            //To do
        }
    }
}
