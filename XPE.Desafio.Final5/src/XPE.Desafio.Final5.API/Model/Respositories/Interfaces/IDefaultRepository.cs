using System.Linq.Expressions;
using XPE.Desafio.Final5.API.Model.Domains;

namespace XPE.Desafio.Final5.API.Model.Respositories.Interfaces
{
    public interface IDefaultRepository<T> : IDisposable where T : Entity
    {
        Task Create(T entity);
        Task Delete(Guid Id);
        Task Update(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<IList<T>> GetItemsByName(Expression<Func<T, bool>> condition);
    }
}
