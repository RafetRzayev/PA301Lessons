using BookManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Services
{
    internal class OrderService
    {
        private DataContext _dataContext;
        private CustomerService _customerService;
        private BookService _bookService;

        public OrderService(DataContext dataContext, CustomerService customerService, BookService bookService)
        {
            _dataContext = dataContext;
            _customerService = customerService;
            _bookService = bookService;
        }

        public void AddOrder()
        {
            Console.WriteLine("Choose customer id below list");
            _customerService.ShowCustomers();
            int customerId = int.Parse(Console.ReadLine());
            var customer = _dataContext.Customers.Find(x => x.Id == customerId);
            Console.WriteLine("Choose book and its count below list");
            _bookService.ShowBooks();
            var orderItemsInput = Console.ReadLine().Split(',');
            var orderItems = new List<OrderItem>();
            for (int i = 0; i < orderItemsInput.Length - 1; i+=2)
            {
                var bookId = int.Parse(orderItemsInput[i]);
                var count = int.Parse(orderItemsInput[i + 1]);
                var book = _dataContext.Books.Find(x => x.Id == bookId);
                var orderItem = new OrderItem(book, count);
                orderItems.Add(orderItem);
            }

            var order = new Order(customer, orderItems);
            _dataContext.Orders.Add(order);
            Console.WriteLine("Succesfully added");
        }

        internal void ShowOrders()
        {
            foreach (var order in _dataContext.Orders)
            {
                Console.WriteLine(order.Customer.Name);

                foreach (var item in order.Items)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
