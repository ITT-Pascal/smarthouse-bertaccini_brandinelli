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
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _lamprepository;

        public GetAllLampsQuery(ILampRepository lamprepository)
        {
            _lamprepository = lamprepository;
        }

        public List<LampDto> Execute()
        {
            List<LampDto> result = new List<LampDto>();

            foreach(Lamp l in _lamprepository.GetAll())
            {
                if(l != null)
                {
                    result.Add(LampMapper.ToDto(l));
                }
            }
            return result;
        }
    }
}
