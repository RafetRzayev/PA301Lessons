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
    public class StudentWithEfRepository : IStudentRepository
    {
        private readonly AcademyDbContext _context;

        public StudentWithEfRepository(AcademyDbContext context)
        {
            _context = context;
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public Student? GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public void Update(int id, Student entity)
        {
            var existingStudent = GetById(id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = entity.FirstName;
                existingStudent.LastName = entity.LastName;
                existingStudent.GroupId = entity.GroupId;
                _context.SaveChanges();
            }
        }
    }
}
