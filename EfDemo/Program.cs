using EfDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appDbContext = new AppDbContext();
            var teacher = new Teacher
            {
                Name = "New teacher 3",
                TeacherGroups = new List<TeacherGroup>
                {
                    new TeacherGroup
                    {
                        GroupId = 2
                    }
                }
            };

            appDbContext.Teachers.Add(teacher);
            appDbContext.SaveChanges();
        }
    }
}
