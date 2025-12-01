using BookManagmentSystem.Services;
using System.Data;

namespace BookManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var dataContext = new DataContext();    
            var genreService = new GenreService(dataContext);
            var authorService = new AuthorService(dataContext);
            var bookService = new BookService(dataContext, genreService, authorService);
            var customerService = new CustomerService(dataContext);
            var orderService = new OrderService(dataContext, customerService, bookService);

            var menuService = new MenuService(genreService, authorService, bookService, customerService, orderService);
            menuService.Start();
        }
    }
}
