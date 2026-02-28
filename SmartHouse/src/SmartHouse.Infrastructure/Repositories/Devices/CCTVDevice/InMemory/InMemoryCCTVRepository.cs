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
    public class InMemoryCCTVRepository : ICCTVRepository
    {
        private readonly List<CCTV> _cctvs;

        public InMemoryCCTVRepository()
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

        public CCTV GetById(Guid id)
        {
            return _cctvs.FirstOrDefault(cctv => cctv.Id == id);
        }

        public void Add(CCTV cctv)
        {
            if (cctv != null)
                _cctvs.Add(cctv);
            else
                throw new ArgumentException("CCTV cannot be null");
        }

        public void Delete(Guid id)
        {
            var cctv = GetById(id);

            if (cctv != null)
                _cctvs.Remove(cctv);
        }

        public void Update(CCTV cctv)
        {
            //To do
        }
    }
}
