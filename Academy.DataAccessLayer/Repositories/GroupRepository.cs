using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;

namespace Academy.DataAccessLayer.Repositories;

public class GroupRepository : IGroupRepository
{
    public void Add(Group entity)
    {
        AcademyDataBase.Groups.Add(entity);
    }

    public void Delete(int id)
    {
        var group = GetById(id);

        if (group is not null)
        {
            AcademyDataBase.Groups.Remove(group);
            return;
        }

        throw new Exception("Group not found");
    }

    public List<Group> GetAll()
    {
        return AcademyDataBase.Groups;
    }

    public Group? GetById(int id)
    {
        var group = AcademyDataBase.Groups.SingleOrDefault(g => g.Id == id);

        return group;
    }

    public List<Group> GetGroupsWithStudents()
    {
        var students = AcademyDataBase.Students;

        foreach (var group in AcademyDataBase.Groups)
        {
            foreach (var student in students)
            {
                if (student.Group?.Id == group.Id)
                {
                    group.Students.Add(student);
                }
            }
        }
        return AcademyDataBase.Groups;
    }

    public void Update(int id, Group entity)
    {
        var existingGroup = GetById(id);

        if (existingGroup is not null)
        {
            existingGroup.Name = entity.Name;
            return;
        }

        throw new Exception("Group not found");
    }
}
