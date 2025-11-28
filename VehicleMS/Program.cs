namespace VehicleMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[4];
            var car1 = new Car()
            {
                Brand = "sdf",
                Model = "safds",
                Year = 12,
                NumberOfDoors = 4
            };
            var car2 = new Car()
            {
                Brand = "fjhkb",
                Model = "sdgdf",
                Year = 5,
                NumberOfDoors = 4
            };
            var m1 = new Motorcycle
            {
                Brand = "wqesdff",
                Model = "ewdsfb",
                Year = 12,
                HasSideCar = true,
            };
            var m2 = new Motorcycle
            {
                Brand = "weqtrwet",
                Model = "65itygh",
                Year = 12,
                HasSideCar = false,
            };
            //var v1 = new Vehicle();
            vehicles[0] = m1;
            vehicles[1] = m2;
            vehicles[2] = car1;
            vehicles[3] = car2;

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.StartEngine());
                vehicle.DisplayInfo();
            }
        }
    }
}
