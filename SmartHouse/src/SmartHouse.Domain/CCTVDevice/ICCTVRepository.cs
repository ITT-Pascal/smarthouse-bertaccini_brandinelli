using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.CCTVDevice
{
    public interface ICCTVRepository
    {
        void Create(CCTV newCCTV);
        void Update(CCTV newCCTV);
        void Delete(Guid id);
        CCTV GetById(Guid id);
        List<CCTV> GetAll();
    }
}
