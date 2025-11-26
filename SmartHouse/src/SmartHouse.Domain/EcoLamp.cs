using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        
       

        const int ThisMinBrightness = 0;
        const int ThisDefaultBrightness = 30;
        const int ThisMaxBrightness = 70;

        public override int MaxBrightness => ThisMaxBrightness;
        public override int MinBrightness => ThisMinBrightness;
        public override int DefaultBrightness => ThisDefaultBrightness;

        public EcoLamp(string name): base(name)
        {
        }
       

       

    }
}
