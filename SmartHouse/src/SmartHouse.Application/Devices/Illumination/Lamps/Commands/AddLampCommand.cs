using SmartHouse.Domain.Illumination;
using SmartHouse.Domain.IlluminationDevice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Application.Devices.Illumination.Lamps.Commands
{
    internal class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public AddLampCommand(ILampRepository lamprepository)
        {
            _lampRepository = lamprepository;
        }

        public void Execute(string lampname)
        {           
            _lampRepository.Add(new Lamp(lampname));
        }
    }
}
