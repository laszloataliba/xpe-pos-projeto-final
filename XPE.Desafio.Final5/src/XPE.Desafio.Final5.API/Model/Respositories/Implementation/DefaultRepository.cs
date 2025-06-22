using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using XPE.Desafio.Final5.API.Model.Domains;
using XPE.Desafio.Final5.API.Model.Respositories.Data.Context;
using XPE.Desafio.Final5.API.Model.Respositories.Interfaces;

namespace XPE.Desafio.Final5.API.Model.Respositories.Implementation
{
    public class DefaultRepository<T> : IDefaultRepository<T> where T : Entity, new()
    {
        private readonly MyDbContext Db;
        private readonly DbSet<T> DbSet;

        public DefaultRepository(MyDbContext DbContext)
        {
            Db = DbContext;
            DbSet = Db.Set<T>();
        }

        public async Task Create(T entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await Db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAll() =>
            await DbSet.ToListAsync();

        public async Task<T> GetById(Guid id) =>
            await DbSet.FindAsync(id) ?? new T();

        public async Task<IList<T>> GetItemsByName(Expression<Func<T, bool>> condition)
        {
            var items = 
                await DbSet.AsNoTracking().Where(condition).AsQueryable().ToListAsync();

            return items;
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
