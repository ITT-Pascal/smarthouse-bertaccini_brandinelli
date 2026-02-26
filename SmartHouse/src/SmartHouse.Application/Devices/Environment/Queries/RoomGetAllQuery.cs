using SmartHouse.Domain.Environment;
using SmartHouse.Domain.Environment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Environment.Queries
{
    public class RoomGetAllQuery
    {
        private readonly IRoomRepository _repository;

        public RoomGetAllQuery(IRoomRepository repos)
        {
            _repository = repos;
        }

        public List<RoomDto> Execute()
        {
            List<RoomDto> result = new List<RoomDto>();

            foreach (Room r in _repository.GetAll())
            {
                if (r != null)
                    result.Add(RoomMapper.ToDto(r));
            }
            return result;
        }
    }
}
