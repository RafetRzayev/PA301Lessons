using Academy.BusinessLogicLayer.Services.Contracts;
using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Repositories.Contracts;
using Academy.DataAccessLayer.Models;

namespace Academy.BusinessLogicLayer.Services;

public class GroupManager : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupManager(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public void AddGroup(CreateGroupDto createGroupDto)
    {
        _groupRepository.Add(new Group
        {
            Name = createGroupDto.Name
        });
    }

    public void DeleteGroup(int id)
    {
        _groupRepository.Delete(id);
    }

    public GroupDto? GetGroupById(int id)
    {
        var group = _groupRepository.GetById(id);

        if (group is null)
        {
            return null;
        }

        return new GroupDto
        {
            Id = group.Id,
            Name = group.Name
        };
    }

    public List<GroupDto> GetGroups()
    {
        var groups = _groupRepository.GetAll();

        return groups.Select(group => new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
        }).ToList();
    }

    public List<GroupDto> GetGroupsWithStudents()
    {
        var groups = _groupRepository.GetAll();

        return groups.Select(group => new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
            StudentNames = group.Students.Select(x => x.FirstName).ToList()
        }).ToList();
    }

    public void UpdateGroup(int id, UpdateGroupDto updateGroupDto)
    {
        var group = new Group
        {
            Name = updateGroupDto.Name
        };

        _groupRepository.Update(id, group);
    }
}