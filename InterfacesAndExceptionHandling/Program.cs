namespace InterfacesAndExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List of numbers
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };
            // List of strings
            var cities = new List<string> { "New York", "London", "Tokyo", "Paris", "Berlin", "Sydney", "Toronto", "Mumbai", "Barcelona" };
            // List of employees
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Smith", Department = "IT", Salary = 75000, Age = 28 },
                new Employee { Id = 2, Name = "Sarah Johnson", Department = "HR", Salary = 65000, Age = 32 },
                new Employee { Id = 3, Name = "Mike Wilson", Department = "IT", Salary = 85000, Age = 35 },
                new Employee { Id = 4, Name = "Emily Davis", Department = "Finance", Salary = 70000, Age = 29 },
                new Employee { Id = 5, Name = "David Brown", Department = "IT", Salary = 95000, Age = 40 },
                new Employee { Id = 6, Name = "Lisa Garcia", Department = "Marketing", Salary = 60000, Age = 26 },
                new Employee { Id = 7, Name = "Robert Taylor", Department = "Finance", Salary = 80000, Age = 38 },
                new Employee { Id = 8, Name = "Jennifer Lee", Department = "HR", Salary = 55000, Age = 24 }
            };
            // List of orders
            var orders = new List<Order>
            {
                new() { Id = 1, CustomerName = "Alice", Amount = 150.50m, OrderDate = new DateTime(2024, 1, 15) },
                new() { Id = 2, CustomerName = "Bob", Amount = 89.99m, OrderDate = new DateTime(2024, 2, 10) },
                new() { Id = 3, CustomerName = "Alice", Amount = 200.00m, OrderDate = new DateTime(2024, 1, 25) },
                new() { Id = 4, CustomerName = "Charlie", Amount = 75.25m, OrderDate = new DateTime(2024, 3, 5) },
                new() { Id = 5, CustomerName = "Bob", Amount = 120.75m, OrderDate = new DateTime(2024, 2, 20) },
                new() { Id = 6, CustomerName = "Diana", Amount = 300.00m, OrderDate = new DateTime(2024, 1, 30) }
            };

            var evenNumbers = numbers.Where(x => x % 2 == 0);
            var citiesWithStartTOrL = cities.Where(city => city.StartsWith("T") || city.StartsWith("L"));
            var employeesWithHighSalary = employees.Where(emp => emp.Salary > 70000);
            var youngEmployees = employees.Where(emp => emp.Age < 30);
            var squareNumbers = numbers.Select(x => x * x);
            var cityNameWithLengths = cities.Select(city => $"{city} ({city.Length})");
            var employeeNames = employees.Select(emp => emp.Name);
            var averageSalary = employees.Average(emp => emp.Salary);
            var employeeWithHighSalaryFromAverage = employees
                .Where(emp => emp.Salary > averageSalary)
                .Select(emp => new { emp.Name, emp.Department, emp.Salary });

            var orderedCities = cities.OrderBy(city => city);
            var orderedEmployeesBySalaryDesc = employees.OrderByDescending(emp => emp.Salary);
            var orderedEmployeesByDepartmentThenByAge = employees
                .OrderBy(emp => emp.Department)
                .ThenBy(emp => emp.Age);
            var descNumbers = numbers.OrderByDescending(x => x);

            var employeeCountByDepartment = employees
                .GroupBy(emp => emp.Department)
                .Select(group => new { Department = group.Key, Count = group.Count() });

            var myWhereEvenNumbers = numbers.MyWhere(x => x % 2 == 0).ToList();

        }
    }

    public static class Extensions
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            double sum = 0;
            int count = 0;
            foreach (var item in source)
            {
                sum += selector(item);
                count++;
            }
            if (count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            return sum / count;
        }
    }
}