using SmartHouse.Domain.Doors;
using SmartHouse.Domain.DoorsDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class DoorGetAllQuery
    {
        private readonly IDoorRepository _repository;

        public DoorGetAllQuery(IDoorRepository repos)
        {
            _repository = repos;
        }

        public List<Door> Execute()
        {
            List<Door> result = new List<Door>();

            foreach(Door d in _repository.GetAll())
            {
                if (d != null)
                    result.Add(d);
            }
            return result;
        }
    }
}
