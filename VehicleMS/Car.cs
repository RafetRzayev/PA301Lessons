namespace VehicleMS
{
    internal class Car : Vehicle
    {
        public int NumberOfDoors {  get; set; }

        public override string StartEngine()
        {
            return "Car engine started";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Number of doors:{NumberOfDoors}");
        }
    }
}
