namespace BookManagmentSystem.Models;

internal class Author
{
    private static int _autoIncrementId = 1;

    public Author(string name)
    {
        Name = name;
        Id = _autoIncrementId++;
    }

    public int Id { get; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}
