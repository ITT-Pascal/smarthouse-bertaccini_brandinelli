using SmartHouse.Domain.CCTVDevice;
using SmartHouse.Domain.CCTVDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHouse.Infrastructure.Repositories.Devices.CCTVDevice.InMemory
{
    public class InMemoryLampRepository : ICCTVRepository
    {
        private readonly List<CCTV> _cctvs;

        public InMemoryLampRepository()
        {
            _cctvs = new List<CCTV>
            {
                new CCTV("Stefano", 1234),
                new CCTV("Pasquale", 4321),
                new CCTV("Giovanni", 2143)
            };
        }

        public List<CCTV> GetAll()
        {
            return _cctvs;
        }

        public CCTV? GetById(Guid id)
        {
            CCTV? result = null;

            foreach (CCTV l in _cctvs)
                if (l.Id == id)
                    result = l;

            return result;
        }

        public void Add(CCTV lamp)
        {
            if (lamp != null)
                _cctvs.Add(lamp);
            else
                throw new ArgumentException("lamp cannot be null");
        }

        public void Delete(Guid id)
        {
            var lamp = GetById(id);

            if (lamp != null)
                _cctvs.Remove(lamp);
        }

        public void Update(CCTV lamp)
        {
            //To do
        }
    }
}
