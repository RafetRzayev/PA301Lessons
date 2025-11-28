namespace VehicleMS
{
    internal abstract class Vehicle
    {
        public string Brand {  get; set; }
        public string Model {  get; set; }
        public int Year {  get; set; }

        public virtual string StartEngine()
        {
            return "Vehicle start engine";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Brand:{Brand}, Model:{Model}, Year:{Year}");
        }
    }
}
