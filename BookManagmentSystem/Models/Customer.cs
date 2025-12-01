namespace BookManagmentSystem.Models;

internal class Customer
{
    private static int _autoIncrementId = 1;

    public Customer(string name)
    {
        Name = name;
        Id = _autoIncrementId++;
    }

    public int Id {  get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}
