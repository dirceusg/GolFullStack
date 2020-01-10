using System;
using GolFullStack.Domain.Repository.Interface.Business;
using GolFullStack.Entity.Entities.Business;
using GolFullStack.Repository.Context;

namespace GolFullStack.Repository.Repository.Business
{
    public class AirplaneRepository : BaseRepository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(GolContext context) : base(context)
        {
        }
    }
}
