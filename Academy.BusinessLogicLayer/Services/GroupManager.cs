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
}