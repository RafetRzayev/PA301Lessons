namespace DelegateTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, double> square = x => x * x;
            Func<int, double> cube = x => x * x * x;
            Func<int, double> root = x => Math.Sqrt(x);

            List<int> numbers = [1, 23, 234, 23, 53, 45, 2, 2, 4];
            ProcessNumbers(numbers, square,"Kvadrat");
            ProcessNumbers(numbers, cube, "Kub");
            ProcessNumbers(numbers, root, "KokAlti");
        }

        static void ProcessNumbers(List<int> numbers, Func<int, double> op, string title)
        {
            Console.WriteLine(title);

            foreach (int i in numbers)
            {
                var result = op.Invoke(i);

                Console.WriteLine($"{i}:{result}");
            }
        }
    }

}
