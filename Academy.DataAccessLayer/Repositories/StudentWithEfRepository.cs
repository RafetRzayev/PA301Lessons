using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Repositories
{
    public class StudentWithEfRepository : EfCoreRepository<Student>, IStudentRepository
    {
        public StudentWithEfRepository(AcademyDbContext context) : base(context)
        {
        }  
    }
}
