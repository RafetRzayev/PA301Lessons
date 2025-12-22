using Academy.DataAccessLayer.Models;
namespace Academy.DataAccessLayer.Repositories.Contracts
{
    public interface IGroupRepository : IRepository<Group>
    {
        List<Group> GetGroupsWithStudents();
    }
}
