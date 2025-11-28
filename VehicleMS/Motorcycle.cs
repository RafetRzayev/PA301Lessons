namespace VehicleMS
{
    internal class Motorcycle: Vehicle
    {
        public bool HasSideCar {  get; set; }

        public override string StartEngine()
        {
            return "Motor engine started";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Has side car:{HasSideCar}");
        }
    }
}
