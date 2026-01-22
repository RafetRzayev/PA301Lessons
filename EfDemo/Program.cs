using EfDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appDbContext = new AppDbContext();

            var studentWith2Id = appDbContext.Students.AsNoTracking().SingleOrDefault(x => x.Id == 3);
            appDbContext.Students.Remove(studentWith2Id);
            appDbContext.SaveChanges();
            var students = appDbContext.Students;
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }
        }
    }
}
