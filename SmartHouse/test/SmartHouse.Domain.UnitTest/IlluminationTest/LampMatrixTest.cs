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
            AbstractLamp newLamp = new Lamp("Stefano");
            LampMatrix newLampMatrix = new LampMatrix("Sasha", lamps);

            newLampMatrix.AddLamp(newLamp);

            Assert.Equal(newLamp, newLampMatrix.Lamps[0,0]);
        }

        [Fact]

        public void When_WantToAdd2NewLamps_CanDoIt()
        {
            AbstractLamp[,] lamps = new AbstractLamp[3, 3];
            AbstractLamp newLamp = new Lamp("Stefano");
            AbstractLamp newEcoLamp = new EcoLamp("Lepri");
            LampMatrix newlampMatrix = new LampMatrix("Sasha", lamps);

            newlampMatrix.AddLamp(newLamp);
            newlampMatrix.AddLamp(newEcoLamp);

            Assert.Equal(newLamp, newlampMatrix.Lamps[0, 0]);
            Assert.Equal(newEcoLamp, newlampMatrix.Lamps[0, 1]);
        }
    }
}
