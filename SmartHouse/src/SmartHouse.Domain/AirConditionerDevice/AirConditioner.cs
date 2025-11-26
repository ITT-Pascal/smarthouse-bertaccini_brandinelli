using SmartHouse.Domain.Doors;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.AirConditionerDevice
{
    public class AirConditioner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AirConditionerStatus Status { get; set; }
        public double Temperature { get; set; }
        public FanSpeed FanSpeed { get; set; }

        public double MinTemperature { get; } = 16.0;
        public double DefaulTemperature { get; } = 20.0;
        public double MaxTemperature { get; } = 26.0;
        public double DefaultJump { get;}= 0.1;

        public AirConditioner(string name)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name isn't valid");
            else
                Name = name;
            Status = AirConditionerStatus.Off;
            Temperature = DefaulTemperature;
            FanSpeed = FanSpeed.Medium;
        }

        public void TurnOn() => Status = AirConditionerStatus.On;

        public void TurnOff() => Status = AirConditionerStatus.Off;

        public void IncreaseTemperature()
        {
            if (Status == AirConditionerStatus.On)
                Temperature += DefaultJump;
            else
                throw new ArgumentException("Before increasing the temperature you must turn on the air conditioner");
        }

        public void IncreaseTemperature(double temperature)
        {
            if (Status == AirConditionerStatus.On)
            {
                var increasedTemperature = Temperature + temperature;
                if (increasedTemperature >= MaxTemperature)
                    Temperature = MaxTemperature;
                else
                    Temperature = increasedTemperature;
            }
            else
                throw new ArgumentException("Before increasing the temperature you must turn on the air conditioner");
        }

        public void DecreaseTemperature(double temperature)
        {
            if (Status == AirConditionerStatus.On)
            {
                var decreasedTemperature = Temperature - temperature;
                if (decreasedTemperature <= MinTemperature)
                    Temperature = MinTemperature;
                else
                    Temperature = decreasedTemperature;
            }
            else
                throw new ArgumentException("Before decreasing the temperature you must turn on the air conditioner");
        }

        public void DecreaseTemperature()
        {
            if (Status == AirConditionerStatus.On)
                Temperature -= DefaultJump;
            else
                throw new ArgumentException("Before decreasing the temperature you must turn on the air conditioner");
        }

        public void SetMaxTemperature()
        {
            if (Status == AirConditionerStatus.On)
                Temperature = MaxTemperature;
            else
                throw new ArgumentException("Before setting to the max temperature you must turn on the air conditioner");
        }

        public void SetMinTemperature()
        {
            if (Status == AirConditionerStatus.On)
                Temperature = MinTemperature;
            else
                throw new ArgumentException("Before setting to the min temperature you must turn on the air conditioner");
        }

        public void SetFanSpeedLow()
        {
            if (Status == AirConditionerStatus.On)
                FanSpeed = FanSpeed.Low;
            else
                throw new ArgumentException("Before setting the fan speed to low you must turn on the air conditioner");
        }

        public void SetFanSpeedMedium()
        {
            if (Status == AirConditionerStatus.On)
                FanSpeed = FanSpeed.Medium;
            else
                throw new ArgumentException("Before setting the fan speed to medium you must turn on the air conditioner");
        }

        public void SetFanSpeedHigh()
        {
            if (Status == AirConditionerStatus.On)
                FanSpeed = FanSpeed.High;
            else
                throw new ArgumentException("Before setting the fan speed to high you must turn on the air conditioner");
        }

        public void IncreaseFanSpeed()
        {
            if (Status == AirConditionerStatus.On)
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
            if (Status == AirConditionerStatus.On)
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
