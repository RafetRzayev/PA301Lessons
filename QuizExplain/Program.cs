namespace QuizExplain
{
    using System.Collections;
    using System.Text;

    internal class Program
    {
        public delegate bool CarFilter(Car car);
        internal static void Main(string[] args)
        {
            var cars = new List<Car>();

            cars.Add(new Car("Toyota", 2012));
            cars.Add(new Car("Honda", 2015));
            cars.Add(new Car("Toyota", 2014));
            cars.Add(new Car("Honda", 1456));
            cars.Add(new Car("Honda", 2000));

            cars.RemoveAll(car => car.Name == "Toyota");



            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }
        }
    }

    class Car
    {
        public int Year { get; set; }
        public string Name { get; set; }

        public Car(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
