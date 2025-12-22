namespace Delegates
{
    internal class Program
    {
        public delegate void Delegates();
        static void Main(string[] args)
        {
            var t = Get();
            Console.WriteLine(t.Elebbas);
        }

        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        static dynamic Get()
        {
            var a = new { Name = "hello", Age = 12 };

            return a;
        }
    }

    class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;

            var pr = new Program();
        }

        public int Id {  get; set; }
        public string Name { get; set; }
    }
    public static class ExtensionMethods
    {
        public static List<T> MyWhere<T>(this List<T> list, Predicate<T> predic)
        {
            var result = new List<T>();   
            
            foreach (var item in list)
            {
                if (predic.Invoke(item))
                    result.Add(item);
            }

            return result;
        }

        public static T MyFind<T>(this List<T> list, Predicate<T> predic)
        {
            foreach (var item in list)
            {
                if (predic.Invoke(item))
                    return item;
            }

            return default;
        }

        public static List<T> MyFindAll<T>(this List<T> list, Predicate<T> predic)
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                if (predic.Invoke(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
