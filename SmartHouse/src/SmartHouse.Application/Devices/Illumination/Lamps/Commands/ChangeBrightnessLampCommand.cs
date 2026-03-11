using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class ChangeBrightnessLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public ChangeBrightnessLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid id, int newbrightness)
        {
            Lamp lamp = _lampRepository.GetById(id);
            if(lamp != null)
            {
                lamp.ChangeBrightness(newbrightness);
                _lampRepository.Update(lamp);
            }
        }
    }
}
