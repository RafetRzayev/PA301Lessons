namespace Academy.BusinessLogicLayer.Dtos;

public class GroupDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<string> StudentNames { get; set; } = [];
}

public class CreateGroupDto
{
    public required string Name { get; set; }
}

public class UpdateGroupDto
{
    public required string Name { get; set; }
}
