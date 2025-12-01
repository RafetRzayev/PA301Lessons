using BookManagmentSystem.Models;

namespace BookManagmentSystem.Services
{
    internal class AuthorService
    {
        private DataContext _dataContext;

        public AuthorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddAuthor()
        {
            Console.Write("Enter author name:");
            var authorName = Console.ReadLine();
            var author = new Author(authorName);
            _dataContext.Authors.Add(author);
            Console.WriteLine("Successfullyyy added");
        }

        public void ShowAuthors()
        {
            Console.WriteLine(new string('-', 40));
            foreach (var item in _dataContext.Authors)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 40));
        }

        public void ShowBooksByAuthor()
        {
            foreach (var author in _dataContext.Authors)
            {
                ShowBooks(author);
            }
        }

        private void ShowBooks(Author author)
        {
            bool hasBook = false;
            Console.WriteLine(author);
            foreach (var book in _dataContext.Books)
            {
                if (book.Authors.Find(x => x.Id == author.Id) != null)
                {
                    Console.WriteLine($"--{book.Name}");
                    hasBook = true;
                }
            }

            if (!hasBook)
                Console.WriteLine("Book not found");
        }
    }
}
