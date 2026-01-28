using Academy.BusinessLogicLayer.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BusinessLogicLayer.Services.Contracts
{
    public interface ICrudService<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        List<TDto> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Expression<Func<TEntity, bool>>? predicate = null);
        TDto? GetById(int id);
        void Add(TCreateDto createDto);
        void Update(int id, TUpdateDto updateDto);
        void Delete(int id);
    }
}
