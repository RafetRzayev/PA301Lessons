using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class People
    {
        private Person[] _persons;

        public People()
        {
            _persons = new Person[]
            {
                new Person("Alice"),
                new Person("Bob"),
                new Person("Charlie")
            };
        }

        public void AddPerson(string name)
        {
            Array.Resize(ref _persons, _persons.Length + 1);
            _persons[^1] = new Person(name);
        }

        public Person GetPerson(int index)
        {
            if (index < 0 || index >= _persons.Length)
            {
                Console.WriteLine("Index is out of range.");
                return new Person("undefied");
            }

            return _persons[index];
        }

        public Person this[int index]
        {
            get
            {
                if (index < 0 || index >= _persons.Length)
                {
                    Console.WriteLine("Index is out of range.");
                    return new Person("undefied");
                }

                return _persons[index];
            }
            set
            {
                if (index < 0 || index >= _persons.Length)
                {
                    Console.WriteLine("Index is out of range.");
                    return;
                }
                _persons[index] = value;
            }
        }

        public void PrintAllPersons()
        {
            foreach (var person in _persons)
            {
                Console.WriteLine(person.Name);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }
}
