namespace SmartHouse.Domain
{
    //Commit ba
    public class Lamp : AbstractLamp
    {

        public Guid Id = new Guid();
        public override bool IsOn { get; protected set; }

        public override int Brightness { get; protected set; }

        const int MinBrightness = 0;
        const int MaxBrightness = 100;

        public Lamp()
        {           
            Brightness = 0;
            IsOn = false;
            
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
