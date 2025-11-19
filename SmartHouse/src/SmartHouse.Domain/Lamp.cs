namespace SmartHouse.Domain
{
    //Commit ba
    public class Lamp : AbstractLamp
    {       

        const int MinBrightness = 0;
        const int DefaultBrightness = 50;
        const int MaxBrightness = 100;

        public Lamp(string name):base(name)
        {                       
        }

        public override void SwitchOnOff()
        {
            if (Status == DeviceStatus.Off) 
            {
                Status = DeviceStatus.On;
            }else if(Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
            }

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
