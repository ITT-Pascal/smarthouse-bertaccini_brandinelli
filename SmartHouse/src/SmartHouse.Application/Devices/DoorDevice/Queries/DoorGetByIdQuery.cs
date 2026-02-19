using SmartHouse.Domain.DoorsDevice.Repositories;
using SmartHouse.Domain.DoorsDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Doors;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorGetByIdQuery
    {
        private readonly IDoorRepository _doorRepository;

        public DoorGetByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public Door Execute(Guid id)
        {
            return _doorRepository.GetById(id);
        }
    }
}
