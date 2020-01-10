using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GolFullStack.Entity.Entities.Business;

namespace GolFullStack.Domain.Service.Interface.Business
{
    public interface IAirplaneService : IDisposable
    {
        Task<List<Airplane>> GetAll();        Task<List<Airplane>> GetAllByFilter(Expression<Func<Airplane, bool>> predicate);        Task<Airplane> GetById(Guid id);        Task<Airplane> GetByFilter(Expression<Func<Airplane, bool>> predicate);        Task Add(Airplane entity);        Task Update(Airplane entity);        Task Delete(Guid id);
    }
}
