namespace BookManagmentSystem.Models;

internal class Book
{
    private static int _autoIncrementId = 1;

    public Book(string name, double price, List<Author> authors, Genre genre)
    {
        Name = name;
        Price = price;
        Authors = authors;
        Genre = genre;
        Id = _autoIncrementId++;
    }

    public int Id { get; set; }
    public string Name {  get; set; }
    public double Price {  get; set; }
    public List<Author> Authors { get; set; } = [];
    public Genre Genre { get; set; }

    public override string ToString()
    {
        var authorNames = new List<string>();
        foreach (var author in Authors)
            authorNames.Add(author.Name);
        return $"{Id} - {Name} - {Price} - {Genre.Name} - {string.Join(',', authorNames)}";
    }
}
