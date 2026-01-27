using Microsoft.EntityFrameworkCore;
using Academy.DataAccessLayer.Models;

namespace Academy.DataAccessLayer.DataContext
{
    public class AcademyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<TeacherGroup> TeacherGroups { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=AcademyDemoDb;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
