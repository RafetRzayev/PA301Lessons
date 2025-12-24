namespace WorkingWithFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines("hello.txt");
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
        }
    }
}
