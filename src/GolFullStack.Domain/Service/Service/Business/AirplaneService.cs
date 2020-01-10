using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GolFullStack.Domain.Repository.Interface.Business;
using GolFullStack.Domain.Service.Interface.Business;
using GolFullStack.Domain.Validation.Business;
using GolFullStack.Domain.Validation.GolValidation.Interface;
using GolFullStack.Entity.Entities.Business;

namespace GolFullStack.Domain.Service.Service.Business
{
    public class AirplaneService : BaseService, IAirplaneService
    {
        private readonly IAirplaneRepository _repository;

        public AirplaneService(INotification notifier,
                               IAirplaneRepository repository) : base(notifier)
        {

            _repository = repository;

        }


        //List Airplane

        public Task<List<Airplane>> GetAll()        {            return _repository.GetAll();        }        public Task<List<Airplane>> GetAllByFilter(Expression<Func<Airplane, bool>> predicate)        {            return _repository.GetAllByFilter(predicate);        }        public Task<Airplane> GetByFilter(Expression<Func<Airplane, bool>> predicate)        {            return _repository.GetByFilter(predicate);        }


        // C.R.U.D

        public Task<Airplane> GetById(Guid id)        {            return _repository.GetById(id);        }        public async Task Add(Airplane entity)        {            if (!ExecuteValidation(new AirplaneValidation(), entity)) return;            await _repository.Add(entity);        }        public async Task Update(Airplane entity)        {            if (!ExecuteValidation(new AirplaneValidation(), entity)) return;            await _repository.Update(entity);        }        public async Task Delete(Guid id)        {            await _repository.Delete(id);        }        public void Dispose()        {            _repository?.Dispose();        }

    }
}
