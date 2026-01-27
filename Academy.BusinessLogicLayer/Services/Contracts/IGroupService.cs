using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Models;

namespace Academy.BusinessLogicLayer.Services.Contracts;

public interface IGroupService : ICrudService<Group, GroupDto, CreateGroupDto, UpdateGroupDto>
{
  
}