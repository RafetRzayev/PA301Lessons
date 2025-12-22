namespace Academy.DataAccessLayer.Models;

public class Student : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Group? Group { get; set; }
}