namespace SmartHouse.Domain
{
    //Commit ba
    public class Lamp
    {
        public bool IsOn { get; private set; }

        public int Brightness { get; private set; }

        const int MinBrightness = 0;
        const int MaxBrightness = 100;

        public Lamp()
        {           
            Brightness = 0;
            IsOn = false;
            
        }

        public void SwitchOnOff()
        {
            IsOn = !IsOn;

        }

        public void ChangeBrightness(int newBrightness)
        {
            if (newBrightness > MinBrightness && IsOn == true)
                Brightness = Math.Min(newBrightness, MaxBrightness);
            else
                IsOn = false;
        }
        

    }
}
