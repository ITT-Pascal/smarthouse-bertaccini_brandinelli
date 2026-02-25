using SmartHouse.Domain.DoorsDevice.Repositories;
using SmartHouse.Domain.DoorsDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Doors;
using SmartHouse.Application.Devices.DoorDevice.Mapper;
using SmartHouse.Application.Devices.DoorDevice.Dto;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorGetByIdQuery
    {
        private readonly IDoorRepository _doorRepository;

        public DoorGetByIdQuery(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public DoorDto Execute(Guid id)
        {
            return DoorMapper.ToDto(_doorRepository.GetById(id));
        }
    }
}
