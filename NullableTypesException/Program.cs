using System.Diagnostics;

namespace NullableTypesException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> f = x => x * 2;
            Func<int, int> g = x => x + 3;
            var h = f + g;
            Console.WriteLine(h(5));

        }

        static void ThrowIfNull(object? obj)
        {
            //djgneg
        }
    }
}
