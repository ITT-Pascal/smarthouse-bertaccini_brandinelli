using System;
using SmartHouse.Domain.IlluminationDevice;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Domain.Illumination;

namespace SmartHouse.Domain.UnitTest.IlluminationTest
{
    public class LampMatrixTest
    {
        [Fact]
        public void When_WantToAddANewLamp_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            Lamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);

            
        }
    }
}
