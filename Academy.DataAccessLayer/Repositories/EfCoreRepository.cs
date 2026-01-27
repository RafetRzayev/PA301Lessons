using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Academy.DataAccessLayer.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : Entity
{
    protected readonly AcademyDbContext AppDbContext;

    public EfCoreRepository(AcademyDbContext context)
    {
        AppDbContext = context;
    }

    public virtual void Add(T entity)
    {
        AppDbContext.Set<T>().Add(entity);
        AppDbContext.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var entity = GetById(id);

        if (entity != null)
        {
            AppDbContext.Set<T>().Remove(entity);
            AppDbContext.SaveChanges();
        }
    }

    public List<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    {
        var query = AppDbContext.Set<T>().AsQueryable();

        if (include != null)
        {
            query = include(query);
        }

        return query.ToList();
    }

    public virtual T? GetById(int id)
    {
        var entity = AppDbContext.Set<T>().SingleOrDefault(e => e.Id == id);

        return entity;
    }

    public virtual void Update(int id, T entity)
    {
        var existingEntity = GetById(id);

        if (existingEntity != null)
        {
            AppDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            AppDbContext.SaveChanges();
        }
    }
}
