namespace Academy.DataAccessLayer.Models;

public class Group : Entity
{
    public required string Name { get; set; }
    public List<Student> Students { get; set; } = [];

    public override string ToString()
    {
        return $"{Id} {Name}";
    }
}
