namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory<Person>();
            Person p = factory.CreateInstance();
            Console.WriteLine(p.Name); 
            // Output: Unknown
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        //public static void Swap(ref double a, ref double b)
        //{
        //    double tmp = a;
        //    a = b;
        //    b = tmp;
        //}
    }

    class MyList<T> where T : new()
    {
        private T[] _values = [];
        private int _count = 0;

        public int Count => _count;

        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        public void Add(T value)
        {
            if (_count == _values.Length)
            {
                var newValues = new T[_values.Length == 0 ? 1 : _values.Length * 2];
                Array.Copy(_values, newValues, _count);
                _values = newValues;
            }


            _values[_count] = value;
            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0  || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            for(int i =  index; i < _count - 1; i++)
            {
                _values[i] = _values[i + 1];
            }

            _count--;
        }

        public void Clear()
        {
            _values = [];
            _count = 0;
        }
    }

    class A
    {

    }

    class B: A
    {

    }

    class C: A
    {

    }

    public class Factory<T> where T : new()
    {
        public T CreateInstance()
        {
            return new T(); // Allowed because of `new()` constraint
        }
    }

    public class Person
    {
        public string Name { get; set; }

        // Must have a public parameterless constructor
        public Person(string name)
        {
            Name = "Unknown";
        }
    }

}
