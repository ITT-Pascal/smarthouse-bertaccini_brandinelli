using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        
       public abstract void SwitchOnOff();

       public abstract void ChangeBrightness(int newBrightness);
        


    }
}
