namespace StudentCrud
{
    internal class Program
    {
        private static Student[] _students = new Student[1];
        private static int _count = 0;

        static void Main(string[] args)
        {
            string command;

            while (true)
            {
                PrintMenu();
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        Print();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }

        private static void Delete()
        {
            Print();

            Console.Write("Enter student id:");
            var id = int.Parse(Console.ReadLine());

            for (int i = 0; i < _count; i++)
            {
                if (_students[i].Id == id)
                {
                    var deletedStudent = _students[i];

                    for (int j = i; j < _count - 1; j++)
                    {
                        _students[j] = _students[j + 1];
                    }

                    _students[_count - 1] = default;
                    _count--;
                    Console.WriteLine($"Student ’{deletedStudent.Name}’ was deleted");
                    return;
                }
            }

            Console.WriteLine("Not found");
        }

        private static void Update()
        {
            Print();

            Console.Write("Enter student id:");
            
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id");
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_students[i].Id == id)
                {
                    Console.Write("Want change name, y/n :");
                    var input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Write("Enter new name:");
                        var name = Console.ReadLine();
                        _students[i].Name = name;
                    }

                    Console.Write("Want change age, y/n :");
                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Write("Enter new age:");
                        var age = int.Parse(Console.ReadLine());
                        _students[i].Age = age;
                    }

                    Console.Write("Want change grade, y/n :");
                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Write("Enter new grade:");
                        var grade = char.Parse(Console.ReadLine());
                        _students[i].Grade = grade;
                    }
                    Console.WriteLine("Updated");
                    return;
                }
            }

            Console.WriteLine("Not found");
        }

        private static void Print()
        {
            if (_count == 0)
            {
                Console.WriteLine("Student not found");
                return;
            }

            var line = new string('-', 40);
            Console.WriteLine($"{"Id",-4} {"Name",-20} {"Age",-4} {"Grade",-2}");
            Console.WriteLine(line);
            for (int i = 0; i < _count; i++)
            {
                var student = _students[i];
                Console.WriteLine($"{student.Id, -4} {student.Name, -20} {student.Age, -4} {student.Grade, -2}");
                Console.WriteLine(line);
            }
        }

        private static void Add()
        {
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();
            Console.Write("Enter student age: ");

            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Age invalid");
                return;
            }

            Console.Write("Enter student grade: ");

            if (!char.TryParse(Console.ReadLine(), out char grade))
            {
                Console.WriteLine("Invalid grade");
                return;
            }

            if (grade < 'A' || grade > 'F')
            {
                Console.WriteLine("Invalid grade");
                return;
            }

            if (_count == _students.Length)
            {
                var newArray = new Student[_count * 2];
                Array.Copy(_students, newArray, _students.Length);
                _students = newArray;
            }

            var student = new Student(name, age, grade);
            _students[_count++] = student;
            Console.WriteLine("Added");
        }

        private static void PrintMenu()
        {
            var line = new string('-', 40);
            Console.WriteLine(line);
            Console.WriteLine("Student Managment System");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. View all student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Exit student");
            Console.WriteLine(line);
        }
    }
}
