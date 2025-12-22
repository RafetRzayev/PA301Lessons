namespace Academy.DataAccessLayer.Models;

public class Teacher : Entity
{
   public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Group> Groups { get; set; } = [];
}
