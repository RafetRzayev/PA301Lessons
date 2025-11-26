using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpSyntaxsis
{
    internal class TaskHelper
    {
        public void FindReverseNumberTask()
        {
            var number = int.Parse(Console.ReadLine());
            var reverse = GetReverseNumber(number);
            Console.WriteLine(reverse);
        }

        public void PalindromNumberTask()
        {
            var number = int.Parse(Console.ReadLine());
            if (IsPalindrom(number))
                Console.WriteLine("Palindorm");
            else
                Console.WriteLine("Deyil");
        }

        public void SwapTask()
        {
            int a = 64;
            int b = 45;

            //Console.WriteLine($"a:{a},b:{b}");
            Swap(ref a, ref b);
            Console.WriteLine($"a:{a},b:{b}");
        }

        public void RealAndPrecisionPartTask()
        {
            var number = decimal.Parse(Console.ReadLine());
            var real = GetRealAndPrecisionPart(number, out decimal precPart);
            Console.WriteLine(real);
            Console.WriteLine(precPart);
        }

        public bool IsPalindrom(int number)
        {
            var reverse = GetReverseNumber(number);

            return number == reverse;
        }

        public int GetReverseNumber(int n)
        {
            var reverse = 0;
            while (n != 0)
            {
                reverse = reverse * 10 + n % 10;
                n /= 10;
            }

            return reverse;
        }

        public void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public int GetRealAndPrecisionPart(decimal number, out decimal precisionPart)
        {
            int real = (int)number;
            precisionPart = number - real;

            return real;
        }
   

        public void NamedParameter(int a, string s)
        {

        }

        public void OptionalParameter(int a, bool optionalParam = false)
        {
        }
    }
}
