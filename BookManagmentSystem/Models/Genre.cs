namespace BookManagmentSystem.Models;

internal class Genre
{
    private static int _autoIncrementId = 1;

    public Genre(string name)
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
