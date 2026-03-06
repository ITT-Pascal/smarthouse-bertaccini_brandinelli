using SmartHouse.Application.Devices.Illumination.Lamps.Mapper;
using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Queries
{
    public class LampCheckBrightnessIsMaxQuery
    {
        private readonly ILampRepository _repository;

        public LampCheckBrightnessIsMaxQuery(ILampRepository repos) { _repository = repos; }

        public bool Execute(Guid id)
        {
            Brightness brightness = LampMapper.ToDomain(new GetLampByIdQuery(_repository).Execute(id)).Brightness;

            if (brightness == new Lamp("Check").MaxBrightness)
                return true;
            return false;
        }
    }
}
