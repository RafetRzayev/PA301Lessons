namespace Academy.DataAccessLayer.Models;

public class Student : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Group? Group { get; set; }
    public int GroupId { get; set; }

    public override string ToString()
    {
        return $"{Id,-6}{FirstName,-10}{LastName,-10}{GroupId,-6}"; 
    }
}