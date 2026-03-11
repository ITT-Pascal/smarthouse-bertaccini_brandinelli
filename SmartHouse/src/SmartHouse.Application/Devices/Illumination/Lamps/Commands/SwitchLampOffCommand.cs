using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    public class SwitchLampOffCommand
    {
        private readonly ILampRepository _lamprepository;

        public SwitchLampOffCommand(ILampRepository lamprepository)
        {
            _lamprepository = lamprepository;
        }

        public void Execute(Guid lampId)
        {
            Lamp lamp = _lamprepository.GetById(lampId);
            if (lamp != null)
            {
                lamp.SwitchOff();
                _lamprepository.Update(lamp);
            }
        }
    }
}
