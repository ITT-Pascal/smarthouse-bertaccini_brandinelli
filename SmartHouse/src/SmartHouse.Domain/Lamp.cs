namespace SmartHouse.Domain
{
    //Commit ba
    public class Lamp
    {
        public bool IsOn => Brightness > 0;

        public int Brightness { get; private set; }

        const int MinBrightness = 0;
        const int MaxBrightness = 100;

        public Lamp()
        {           
            Brightness = 0;
        }


        public void ChangeBrightness(int newBrightness)
        {
            if(newBrightness >= MinBrightness)
                Brightness = Math.Min(newBrightness, MaxBrightness);

        }
        

    }
}
