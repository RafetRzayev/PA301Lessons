using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Services
{
    internal class MenuService
    {
        private readonly GenreService _genreService;
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        public MenuService(GenreService genreService, AuthorService authorService, BookService bookService, CustomerService customerService, OrderService orderService)
        {
            _genreService = genreService;
            _authorService = authorService;
            _bookService = bookService;
            _customerService = customerService;
            _orderService = orderService;
        }

        public void ShowMenu()
        {
            Console.WriteLine("*** BOOKSTORE SYSTEM ***\r\n\r\n1. Kitablar\r\n    1.1 Yeni Kitab Əlavə Et\r\n    1.2 Kitab Siyahısı\r\n    1.3 Kitab Axtar\r\n    1.4 Kitabı Redaktə Et\r\n    1.5 Kitabı Sil\r\n\r\n2. Müəlliflər\r\n    2.1 Yeni Müəllif Əlavə Et\r\n    2.2 Müəllif Siyahısı\r\n    2.3 Müəllifin Kitabları\r\n\r\n3. Janrlar\r\n    3.1 Yeni Janr Əlavə Et\r\n    3.2 Janr Siyahısı\r\n\r\n4. Müştərilər və Sifarişlər\r\n    4.1 Müştəri Qeydiyyatı\r\n    4.2 Yeni Sifariş\r\n    4.3 Sifarişlərə Baxış\r\n\r\n0. Çıxış\r\n\r\n");
        }

        public bool DoWork()
        {
            Console.Write("Choose command:");
            var command = Console.ReadLine();

            if (command == "1")
            {
                ShowBookMenu();
            }
            else if (command == "2")
            {
                ShowAuthorMenu();
            }
            else if (command == "3")
            {
                ShowGenreMenu();
            }
            else if (command == "4")
            {
                ShowCustomerMenu();
            }
            else if (command == "0")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Command is invalid");
            }

            return true;
        }

        private void ShowCustomerMenu()
        {
            Console.WriteLine("4.1. Yeni müştəri qeydiyyatı\r\n•\t4.2. Yeni sifariş yarat (müştəri seç, kitab seç, say seç)\r\n•\t4.3. Müştərinin sifarişlərini göstər\r\n•\t4.4. Sifariş detalları: tarix, cəmi məbləğ, kitablar\r\n");
            string command = "";

            while (true)
            {
                Console.Write("Enter customer command:");
                command = Console.ReadLine();

                if (command == "1")
                {
                    _customerService.AddCustomer();
                }
                else if (command == "2")
                {
                    _orderService.AddOrder();
                }
                else if (command == "4")
                {
                    _orderService.ShowOrders();
                }
                else
                {
                    ShowMenu();
                    return;
                }
            }
        }

        private void ShowBookMenu()
        {
            Console.WriteLine("1.1 Yeni Kitab Əlavə Et\r\n    1.2 Kitab Siyahısı\r\n    1.3 Kitab Axtar\r\n    1.4 Kitabı Redaktə Et\r\n    1.5 Kitabı Sil\r\n");

            string command = "";

            while (true)
            {
                Console.Write("Enter book command:");
                command = Console.ReadLine();

                if (command == "1")
                {
                    _bookService.AddBook();
                }
                else if (command == "2")
                {
                    _bookService.ShowBooks();
                }
                else
                {
                    ShowMenu();
                    return;
                }
            }
        }

        private void ShowAuthorMenu()
        {
            Console.WriteLine("2.1 Yeni Müəllif Əlavə Et\r\n    2.2 Müəllif Siyahısı\r\n    2.3 Müəllifin Kitabları\r\n");

            string command = "";

            while (true)
            {
                Console.Write("Enter author command:");
                command = Console.ReadLine();

                if (command == "1")
                {
                    _authorService.AddAuthor();
                }
                else if (command == "2")
                {
                    _authorService.ShowAuthors();
                }
                else
                {
                    ShowMenu();
                    return;
                }
            }

        }

        private void ShowGenreMenu()
        {
            Console.WriteLine("3.1 Yeni Janr Əlavə Et\r\n    3.2 Janr Siyahısı\r\n");
            string command = "";

            while (true)
            {
                Console.Write("Enter genre command:");
                command = Console.ReadLine();

                if (command == "1")
                {
                    _genreService.AddGenre();
                }
                else if(command == "2")
                {
                    _genreService.ShowGenres();
                }
                else
                {
                    ShowMenu();
                    return;
                }
            }
        }

        public void Start()
        {
            ShowMenu();

            while (true)
            {
                if (!DoWork())
                {
                    break;
                }
            }
        }
    }
}
