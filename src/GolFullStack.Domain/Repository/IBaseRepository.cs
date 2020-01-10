using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GolFullStack.Domain.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity.Entities.Entity    {        Task<List<TEntity>> GetAll();        Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> predicate);        Task<TEntity> GetById(Guid id);        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate);        Task Add(TEntity entity);        Task Update(TEntity entity);        Task Delete(Guid id);        Task<int> SaveChanges();    }
}
