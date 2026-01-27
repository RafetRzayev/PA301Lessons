using Academy.DataAccessLayer.Models;

namespace Academy.DataAccessLayer.DataContext;

public class AcademyDataBase
{
    public static List<Group> Groups { get; set; } = [];
    public static List<Student> Students { get; set; } = [];
    public static List<Teacher> Teachers { get; set; } = [];

    static AcademyDataBase()
    {
       
    }
}
