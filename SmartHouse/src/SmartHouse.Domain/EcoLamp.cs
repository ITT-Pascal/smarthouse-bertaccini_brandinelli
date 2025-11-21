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

        const int MinBrightness = 0;
        const int DefautBrightness = 30;
        const int MaxBrightness = 70;

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

        public override void SwitchOnOff()
        {
            base.SwitchOnOff();
        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness > MinBrightness && Status == DeviceStatus.On)
                Brightness = Math.Min(newBrightness, MaxBrightness);
            else
                Status = DeviceStatus.Off;
        }

    }
}
