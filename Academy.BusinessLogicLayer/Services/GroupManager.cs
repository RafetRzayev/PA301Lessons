using Academy.BusinessLogicLayer.Services.Contracts;
using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Repositories.Contracts;
using Academy.DataAccessLayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;

namespace Academy.BusinessLogicLayer.Services;

public class GroupManager : CrudManager<Group, GroupDto, CreateGroupDto, UpdateGroupDto>, IGroupService
{
    public GroupManager(IRepository<Group> repository) : base(repository)
    {
    }

    public override List<GroupDto> GetAll(Func<IQueryable<Group>, IIncludableQueryable<Group, object>>? include = null)
    {
        IGroupRepository groupRepository = (IGroupRepository)Repository;
        var groups = groupRepository.GetAll(include);

        var groupDtos = groups.Select(g => new GroupDto
        {
            Id = g.Id,
            Name = g.Name,
            StudentNames = g.Students.Select(s => s.FirstName).ToList()
        }).ToList();

        return groupDtos;
    }
}