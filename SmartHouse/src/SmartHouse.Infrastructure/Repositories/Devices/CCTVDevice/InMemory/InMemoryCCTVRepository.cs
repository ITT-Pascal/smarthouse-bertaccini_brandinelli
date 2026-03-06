using SmartHouse.Application.Devices.CCTVDevice.Dto;
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
                new Domain.CCTVDevice.CCTV("Stefano", 1234),
                new Domain.CCTVDevice.CCTV("Pasquale", 4321),
                new Domain.CCTVDevice.CCTV("Giovanni", 2143)
            };
        }

        public List<Domain.CCTVDevice.CCTV> GetAll()
        {
            return _cctvs;
        }

        public Domain.CCTVDevice.CCTV GetById(Guid id)
        {
            return _cctvs.FirstOrDefault(cctv => cctv.Id == id);
        }

        public void Add(Domain.CCTVDevice.CCTV cctv)
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

        public void Update(Domain.CCTVDevice.CCTV cctv)
        {
            //To do
        }
    }
}
