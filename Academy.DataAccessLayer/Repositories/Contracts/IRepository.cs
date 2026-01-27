using Academy.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Repositories.Contracts
{
    public interface IRepository<T>
    {
        List<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null);
        T? GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
    }
}
