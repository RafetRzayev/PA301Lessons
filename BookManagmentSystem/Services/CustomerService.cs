using BookManagmentSystem.Models;

namespace BookManagmentSystem.Services
{
    internal class CustomerService
    {
        private DataContext _dataContext;

        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddCustomer()
        {
            Console.Write("Enter customer name:");
            var customerName = Console.ReadLine();
            var customer = new Customer(customerName);
            _dataContext.Customers.Add(customer);
            Console.WriteLine("Successfullyyy added");
        }

        public void ShowCustomers()
        {
            Console.WriteLine(new string('-', 40));
            foreach (var item in _dataContext.Customers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
