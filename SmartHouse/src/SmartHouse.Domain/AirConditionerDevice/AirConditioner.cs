using SmartHouse.Domain.Abstractions;
using SmartHouse.Domain.Doors;
using SmartHouse.Domain.ThermostastDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.AirConditionerDevice
{
    public class AirConditioner: AbstractDevice 
    {
        public FanSpeed FanSpeed { get; set; }

        public AirConditioner(string name): base(name)
        {
            FanSpeed = FanSpeed.Medium;
        }

        public void SetFanSpeedLow()
        {
            if (Status == DeviceStatus.On)
                FanSpeed = FanSpeed.Low;
            else
                throw new ArgumentException("Before setting the fan speed to low you must turn on the air conditioner");
        }

        public void SetFanSpeedMedium()
        {
            if (Status == DeviceStatus.On)
                FanSpeed = FanSpeed.Medium;
            else
                throw new ArgumentException("Before setting the fan speed to medium you must turn on the air conditioner");
        }

        public void SetFanSpeedHigh()
        {
            if (Status == DeviceStatus.On)
                FanSpeed = FanSpeed.High;
            else
                throw new ArgumentException("Before setting the fan speed to high you must turn on the air conditioner");
        }

        public void IncreaseFanSpeed()
        {
            if (Status == DeviceStatus.On)
                if (FanSpeed == FanSpeed.Low)
                    FanSpeed = FanSpeed.Medium;
                else if (FanSpeed == FanSpeed.Medium)
                    FanSpeed = FanSpeed.High;
                else
                    throw new ArgumentException("The fan speed is already at maximum");
            else
                throw new ArgumentException("Before increasing the fan speed you must turn on the air conditioner");

            
        }

        public void DecreaseFanSpeed()
        {
            if (Status == DeviceStatus.On)
                if (FanSpeed == FanSpeed.High)
                    FanSpeed = FanSpeed.Medium;
                else if (FanSpeed == FanSpeed.Medium)
                    FanSpeed = FanSpeed.Low;
                else
                    throw new ArgumentException("The fan speed is already at minimum");
            else
                throw new ArgumentException("Before decreasing the fan speed you must turn on the air conditioner");
            
        }     
    }
}
