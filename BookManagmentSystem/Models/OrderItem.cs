namespace BookManagmentSystem.Models;

internal class OrderItem
{
    public OrderItem(Book book, int count)
    {
        Book = book;
        Count = count;
    }

    public Book Book { get; set; }
    public int Count {  get; set; }

    public override string ToString()
    {
        return $"{Book.Name} - {Count} -({Book.Price}x{Count})={Book.Price * Count}";
    }
}
