using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Repositories
{
    public class GroupWithEfRepository : IGroupRepository
    {
        private readonly AcademyDbContext _context;

        public GroupWithEfRepository(AcademyDbContext context)
        {
            _context = context;
        }

        public void Add(Group entity)
        {
            _context.Groups.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var group = GetById(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
        }

        public List<Group> GetAll()
        {
            var groups = _context.Groups.ToList();

            return groups;
        }

        public Group? GetById(int id)
        {
            var group = _context.Groups.SingleOrDefault(g => g.Id == id);

            return group;
        }

        public List<Group> GetGroupsWithStudents()
        {
            var groups = _context.Groups
                .Include(g => g.Students)
                .ToList();

            return groups;
        }

        public void Update(int id, Group entity)
        {
            var existingGroup = GetById(id);

            if (existingGroup != null)
            {
                existingGroup.Name = entity.Name;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }
    }
}
