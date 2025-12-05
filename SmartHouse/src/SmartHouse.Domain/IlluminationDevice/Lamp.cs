namespace SmartHouse.Domain.Illumination
{
    //Commit ba
    public class Lamp : AbstractLamp
    {       
        const int ThisMinBrightness = 0;
        const int ThisDefaultBrightness = 50;
        const int ThisMaxBrightness = 100;

        public override int MaxBrightness => ThisMaxBrightness;
        public override int MinBrightness => ThisMinBrightness;
        public override int DefaultBrightness => ThisDefaultBrightness;

        public Lamp(string name) : base(name) { }
    }
}
