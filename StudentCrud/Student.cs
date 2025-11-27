using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud
{
    internal class Student
    {
        public Student(string name, int age, char grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
            Id = _autoIncrementId++;
        }

        private static int _autoIncrementId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Grade { get; set; }
    }
}
