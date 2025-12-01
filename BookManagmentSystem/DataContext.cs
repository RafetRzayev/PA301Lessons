using BookManagmentSystem.Models;

namespace BookManagmentSystem
{
    internal class DataContext
    {
        internal List<Book> Books { get; set; } = new List<Book>();
        internal List<Genre> Genres { get; set; } = new List<Genre>();
        internal List<Author> Authors { get; set; } = new List<Author>();
        internal List<Customer> Customers { get; set; } = new List<Customer>();
        internal List<Order> Orders { get; } = new List<Order>();
    }
}
