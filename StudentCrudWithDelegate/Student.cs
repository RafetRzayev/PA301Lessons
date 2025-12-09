namespace StudentCrudWithDelegate
{
    class Student
    {
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static implicit operator int(Student a)
        {
            return a.Age;
        }
    }
}
