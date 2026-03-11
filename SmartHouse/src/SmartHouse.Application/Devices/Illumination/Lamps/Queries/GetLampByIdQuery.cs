using SmartHouse.Application.Devices.Illumination.Lamps.Dto;
using SmartHouse.Application.Devices.Illumination.Lamps.Mapper;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Queries
{
    public class GetLampByIdQuery
    {
        private readonly ILampRepository _lampRepository;

        public GetLampByIdQuery(ILampRepository repository)
        {
            _lampRepository = repository;
        }

        //To Do: to refactor with DTO (next lesson)

        public LampDto Execute(Guid id)
        {
            return LampMapper.ToDto(_lampRepository.GetById(id));
        }
    }
}
