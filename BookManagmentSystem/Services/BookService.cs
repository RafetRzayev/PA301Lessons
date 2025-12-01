using BookManagmentSystem.Models;

namespace BookManagmentSystem.Services;

internal class BookService
{
    private DataContext _dataContext;
    private GenreService _genreService;
    private AuthorService _authorService;
    public BookService(DataContext dataContext, GenreService genreService, AuthorService authorService)
    {
        _dataContext = dataContext;
        _genreService = genreService;
        _authorService = authorService;
    }

    public void AddBook()
    {
        Console.Write("Enter book name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter book price:");
        var price = double.Parse(Console.ReadLine());
       
        Console.WriteLine("Choose genre id below list:");
        _genreService.ShowGenres();
        int id = int.Parse(Console.ReadLine());
        var genre = _dataContext.Genres.Find(x => x.Id == id);

        Console.WriteLine("Choose author ids below list:");
        _authorService.ShowAuthors();
        var ids = Console.ReadLine().Split(',');
        var authors = new List<Author>();

        foreach (var idInString in ids)
        {
            var authorId = int.Parse(idInString);
            var author = _dataContext.Authors.Find(x => x.Id == authorId);

            if (author == null) continue;

            authors.Add(author);
        }

        var book = new Book(name, price, authors, genre);
        _dataContext.Books.Add(book);
        Console.WriteLine("Successfully added");
    }

    public void ShowBooks()
    {
        Console.WriteLine(new string('-', 40));
        foreach (var item in _dataContext.Books)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(new string('-', 40));
    }
}
