using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        
        //private TimeSpan Timer = new TimeSpan(0, 1, 30, 0); // 0 day, 1 hours, 30 minutes, 0 seconds
        //private DateTime ShutOffHour;

        const int ThisMinBrightness = 0;
        const int ThisDefaultBrightness = 30;
        const int ThisMaxBrightness = 70;

        public override int MaxBrightness => ThisMaxBrightness;
        public override int MinBrightness => ThisMinBrightness;
        public override int DefaultBrightness => ThisDefaultBrightness;

        public EcoLamp(string name): base(name)
        {
        }
        //public void EcoTimer()
        //{           
        //    //ShutOffHour = DateTime.UtcNow.Add(Timer);

        //    //if (!IsOn)
        //    //{
        //    //    IsOn = true;            
        //    //}

        //    //while (DateTime.UtcNow <= ShutOffHour)
        //    //{
        //    //    if (DateTime.UtcNow == ShutOffHour)
        //    //        IsOn = false;
        //    //}
        //}

       

    }
}
