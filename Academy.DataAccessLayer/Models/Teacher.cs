namespace Academy.DataAccessLayer.Models;

public class Teacher : Entity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<TeacherGroup> TeacherGroups { get; set; } = [];
}
