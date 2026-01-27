using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;

namespace Academy.DataAccessLayer.Repositories;

public class GroupWithEfRepository : EfCoreRepository<Group>, IGroupRepository
{
    public GroupWithEfRepository(AcademyDbContext context) : base(context)
    {
    }
}
