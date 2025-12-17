namespace DelegateTasks
{
    class Storage<T>
    {
        private List<T> _items = [];

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Display()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

}
