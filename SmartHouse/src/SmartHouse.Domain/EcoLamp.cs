using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public override bool IsOn { get; protected set; }
        public override int Brightness { get;  protected set; }
        public override string Name { get; set; }
        //private TimeSpan Timer = new TimeSpan(0, 1, 30, 0); // 0 day, 1 hours, 30 minutes, 0 seconds
        //private DateTime ShutOffHour;

        const int MinBrightness = 0;
        const int MaxBrightness = 50;

        public EcoLamp(string name)
        {
            Brightness = 0;
            IsOn = false;
            Name = name;
        }
        public void EcoTimer()
        {           
            //ShutOffHour = DateTime.UtcNow.Add(Timer);

            if (!IsOn)
            {
                IsOn = true;            
            }

            //while (DateTime.UtcNow <= ShutOffHour)
            //{
            //    if (DateTime.UtcNow == ShutOffHour)
            //        IsOn = false;
            //}
        }

        public override void SwitchOnOff()
        {
            IsOn = !IsOn;
        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness > MinBrightness && IsOn == true)
                Brightness = Math.Min(newBrightness, MaxBrightness);
            else
                IsOn = false;
        }

    }
}
