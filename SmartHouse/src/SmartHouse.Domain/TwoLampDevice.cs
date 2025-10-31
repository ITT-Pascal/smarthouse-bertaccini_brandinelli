using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class TwoLampDevice
    {

        public int SelectedLamp { get; private set; }

        public List<Lamp> Lamps { get; private set; } 

        public List<EcoLamp> EcoLamps { get; private set; }

        




    }
}
