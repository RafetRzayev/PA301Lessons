using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;

namespace Academy.DataAccessLayer.Repositories;

public class TeacherWithEfRepository : EfCoreRepository<Teacher>, ITeacherRepository
{
    public TeacherWithEfRepository(AcademyDbContext context) : base(context)
    {
    }
}
