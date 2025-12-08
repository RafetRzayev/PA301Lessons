namespace QuizExplain
{
    using System.Collections;
    using System.Text;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            List<int> arrayList=new List<int>();
            arrayList.Add(25);
            arrayList.Add(12);
            Console.WriteLine((int)arrayList[0] + (int)arrayList[1]);
        }

        internal static void ShowEvenNumber(int n)
        {
            while (n > 0)
            {
                int r = n % 10;
                n /= 10;
                if (r % 2 == 0)
                    Console.WriteLine(r);
            }
        }
    }
}
