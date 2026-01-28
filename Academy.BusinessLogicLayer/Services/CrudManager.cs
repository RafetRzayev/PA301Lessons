using Academy.BusinessLogicLayer.Mapping;
using Academy.BusinessLogicLayer.Services.Contracts;
using Academy.DataAccessLayer.Repositories.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq.Expressions;

namespace Academy.BusinessLogicLayer.Services;

public class CrudManager<TEntity, TDto, TCreateDto, TUpdateDto> : ICrudService<TEntity, TDto, TCreateDto, TUpdateDto>
{
    protected IRepository<TEntity> Repository;
    protected IMapper Mapper;

    public CrudManager(IRepository<TEntity> repository)
    {
        Repository = repository;
        Mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        }).CreateMapper();
    }

    public void Add(TCreateDto createDto)
    {
        var entity = Mapper.Map<TEntity>(createDto);

        Repository.Add(entity);
    }

    public void Delete(int id)
    {
        Repository.Delete(id);
    }

    public List<TDto> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, bool>>? predicate = null)
    {
        var entities = Repository.GetAll(include, predicate);
        var dtos = Mapper.Map<List<TDto>>(entities);

        return dtos;
    }

    public TDto? GetById(int id)
    {
        var entity = Repository.GetById(id);
        var dto = Mapper.Map<TDto>(entity);

        return dto;
    }

    public void Update(int id, TUpdateDto updateDto)
    {
        var updateEntity = Mapper.Map<TEntity>(updateDto);

        Repository.Update(id, updateEntity);
    }
}
