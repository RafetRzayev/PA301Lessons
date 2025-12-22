using Academy.DataAccessLayer.Models;

namespace Academy.DataAccessLayer.DataContext;

public class AcademyDataBase
{
    public static List<Group> Groups { get; set; } = [];
    public static List<Student> Students { get; set; } = [];
    public static List<Teacher> Teachers { get; set; } = [];

    static AcademyDataBase()
    {
        var groupA = new Group { Id = 1, Name = "A" };
        var groupB = new Group { Id = 2, Name = "B" };

        Groups.AddRange([groupA, groupB]);

        var student1 = new Student {Id = 1, FirstName = "John", LastName = "Doe", Group = groupA };
        var student2 = new Student {Id = 2, FirstName = "Jane", LastName = "Smith", Group = groupB };
        var student3 = new Student {Id = 2, FirstName = "GYh", LastName = "Smith", Group = groupB };
        var student4 = new Student {Id = 2, FirstName = "Mello", LastName = "Smith", Group = groupB };
        Students.AddRange([student1, student2, student3, student4]);

        var teacher1 = new Teacher("Emily", "Davis");
        teacher1.Groups.Add(groupA);
        var teacher2 = new Teacher("Michael", "Wilson");
        teacher2.Groups.Add(groupB);
        Teachers.AddRange([teacher1, teacher2]);
    }
}
