using BookManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Services
{
    internal class GenreService
    {
        private DataContext _dataContext;

        public GenreService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddGenre()
        {
            Console.Write("Enter genre name:");
            var genreName = Console.ReadLine();
            var genre = new Genre(genreName);
            _dataContext.Genres.Add(genre);
            Console.WriteLine("Successfullyyy added");
        }

        public void ShowGenres()
        {
            Console.WriteLine(new string('-', 40));
            foreach (var item in _dataContext.Genres)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 40));
        }

        public void ShowBooksByGenre()
        {
            foreach (var genre in _dataContext.Genres)
            {
                ShowBooks(genre);
            }
        }

        private void ShowBooks(Genre genre)
        {
            bool hasBook = false;
            Console.WriteLine(genre);
            foreach(var book in _dataContext.Books)
            {
                if (book.Genre == genre)
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
