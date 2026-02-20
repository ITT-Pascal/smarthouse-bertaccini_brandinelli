using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class BrightenLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public BrightenLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id)
        {
            Lamp lamp = _lampRepository.GetById(id);
            if (lamp != null)
            {
                lamp.Brighten();
                _lampRepository.Update(lamp);
            }
        }
    }
}
