using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GolFullStack.Domain.Repository;
using GolFullStack.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace GolFullStack.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity.Entities.Entity, new()    {        protected readonly GolContext Db;        protected readonly DbSet<TEntity> DbSet;        protected BaseRepository(GolContext db)        {            Db = db;            DbSet = db.Set<TEntity>();        }        public virtual async Task<List<TEntity>> GetAll()        {            return await DbSet.AsNoTracking().ToListAsync();        }        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> predicate)        {            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();        }        public virtual async Task<TEntity> GetById(Guid id)        {            return await DbSet.FindAsync(id);        }        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate)        {            return await DbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();        }        public virtual async Task Add(TEntity entity)        {            DbSet.Add(entity);            await SaveChanges();        }        public virtual async Task Update(TEntity entity)        {            DbSet.Update(entity);            await SaveChanges();        }        public virtual async Task Delete(Guid id)        {            DbSet.Remove(new TEntity { Id = id });            await SaveChanges();        }        public async Task<int> SaveChanges()        {            return await Db.SaveChangesAsync();        }        public void Dispose()        {            Db?.Dispose();        }    }
}
