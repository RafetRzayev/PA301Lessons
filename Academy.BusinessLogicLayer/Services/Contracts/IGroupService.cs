using Academy.BusinessLogicLayer.Dtos;

namespace Academy.BusinessLogicLayer.Services.Contracts;

public interface IGroupService
{
    List<GroupDto> GetGroups();
    List<GroupDto> GetGroupsWithStudents();
    GroupDto? GetGroupById(int id);
    void AddGroup(CreateGroupDto createGroupDto);
    void UpdateGroup(int id, UpdateGroupDto updateGroupDto);
    void DeleteGroup(int id);
}