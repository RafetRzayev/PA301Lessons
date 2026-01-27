using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Repositories
{
    public class TeacherWithEfRepository : ITeacherRepository
    {
        private readonly AcademyDbContext _context;

        public TeacherWithEfRepository(AcademyDbContext context)
        {
            _context = context;
        }

        public void Add(Teacher entity)
        {
            _context.Teachers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var teacher = GetById(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public List<Teacher> GetAll()
        {
            var teachers = _context.Teachers.ToList();
            return teachers;
        }

        public Teacher? GetById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            return teacher;
        }

        public void Update(int id, Teacher entity)
        {
            var existingTeacher = GetById(id);
            if (existingTeacher != null)
            {
                existingTeacher.FirstName = entity.FirstName;
                existingTeacher.LastName = entity.LastName;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}
