using System.Net.Http.Headers;

namespace StudentCrudWithDelegate
{
    internal class Program
    {
        private static List<Student> _students =
        [
            new (1, "Alice", 20),
            new (2, "Bob", 22),
            new (3, "Charlie", 23)
        ];

        static void Main(string[] args)
        {
            Student student = new Student(1, "f,", 12);
            int a = student; // Implicit conversion from int to Student

            var commandDictionary = new Dictionary<string, Action>
            {
                { "1", Add },
                { "2", Print },
                { "3", Update },
                { "4", Delete }
            };

            string command;

            while (true)
            {
                PrintMenu();
                command = Console.ReadLine();

                if (commandDictionary.TryGetValue(command, out Action commandAction))
                {
                    commandAction.Invoke();
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }

        static void Add()
        {
            Console.Write("Enter student id: ");
            int id = int.Parse(Console.ReadLine());

            if (_students.Exists(s => s.Id == id))
            {
                Console.WriteLine("Student with this ID already exists");
                return;
            }

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            Student student = new Student(id, name, age);
            _students.Add(student);
            
            Console.WriteLine("Student added successfully");
        }

        static void Delete()
        {
            Console.Write("Enter student id to delete: ");
          
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Please enter a valid student ID.");
                return;
            }

            var student = _students.Find(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
                Console.WriteLine("Student deleted successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        static void Update()
        {
            Console.Write("Enter student id to update: ");
            int id = int.Parse(Console.ReadLine());
            var student = _students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter new student name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new student age: ");
                int age = int.Parse(Console.ReadLine());
                student.Name = name;
                student.Age = age;
                Console.WriteLine("Student updated successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        static void Print()
        {
            foreach (var item in _students)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. print students");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
        }
    }
}
