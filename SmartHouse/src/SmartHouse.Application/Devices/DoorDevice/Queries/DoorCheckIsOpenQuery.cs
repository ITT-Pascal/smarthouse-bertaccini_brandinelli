using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorCheckIsOpenQuery
    {
        private readonly IDoorRepository _repository;

        public DoorCheckIsOpenQuery(IDoorRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            bool isopen = new DoorGetByIdQuery(_repository).Execute(id).IsOpen;
            if (isopen)
                return true;
            return false;
        }
    }
}
