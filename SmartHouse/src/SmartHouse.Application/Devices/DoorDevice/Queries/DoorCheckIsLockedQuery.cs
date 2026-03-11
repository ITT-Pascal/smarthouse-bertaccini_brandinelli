using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorCheckIsLockedQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsLockedQuery(IDoorRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            bool islocked = new DoorGetByIdQuery(_repository).Execute(id).IsLocked;
            if (islocked)
                return true;
            return false;
        }
    }
}
