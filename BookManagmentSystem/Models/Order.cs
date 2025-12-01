namespace BookManagmentSystem.Models;

internal class Order
{
    private static int _autoIncrementId = 1;

    public Order(Customer customer, List<OrderItem> items)
    {
        Customer = customer;
        Items = items;
        Id = _autoIncrementId++;
    }

    public int Id { get; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = [];
    public DateTime OrderTime = DateTime.Now;
}