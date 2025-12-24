using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Repositories
{
    public class GroupWithFileRepository : IGroupRepository
    {
        private const string PATH = "data\\group.txt";
        private readonly IStudentRepository _studentRepository;

        public GroupWithFileRepository(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Add(Group entity)
        {
            File.AppendAllLines(PATH, [entity.ToString()]);
        }

        public void Delete(int id)
        {
            var groups = GetAll();
            var existingGroup = groups.SingleOrDefault(x => x.Id == id);
            if (existingGroup != null)
            {
                groups.Remove(existingGroup);
                var lines = groups.Select(g => g.ToString());
                File.WriteAllLines(PATH, lines);
            }
            else
            {
                throw new Exception("Group not found");
            }
        }

        public List<Group> GetAll()
        {
            var groups = File.ReadAllLines(PATH);
            List<Group> result = new List<Group>();
            foreach (var group in groups)
            {
                var parts = group.Split();
                result.Add(new Group
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1]
                });
            }

            return result;
        }

        public Group? GetById(int id)
        {
            var groups = GetAll();
            var group = groups.Find(x => x.Id == id);

            return group;
        }

        public List<Group> GetGroupsWithStudents()
        {
            var students = _studentRepository.GetAll();
            var groups = GetAll();

            foreach (var group in groups)
            {
                foreach (var student in students)
                {
                    if (student.GroupId == group.Id)
                    {
                        group.Students.Add(student);
                    }
                }
            }

            return groups;
        }

        public void Update(int id, Group entity)
        {
            var groups = GetAll();
            var existingGroup = groups.SingleOrDefault(x => x.Id == id);
            if (existingGroup != null)
            {
                existingGroup.Name = entity.Name;
                var lines = groups.Select(g => g.ToString()).ToArray();
                File.WriteAllLines(PATH, lines);
            }
            else
            {
                throw new Exception("Group not found");
            }
        }
    }

}