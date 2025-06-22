using System.Linq.Expressions;
using XPE.Desafio.Final5.API.Model.Domains;
using XPE.Desafio.Final5.API.Model.Respositories.Interfaces;

namespace XPE.Desafio.Final5.API.Model.Respositories.Implementation
{
    public class ProductRepository(IDefaultRepository<Product> repository) : IProductRepository
    {
        public async Task Create(Product entity) =>
            await repository.Create(entity);

        public async Task Delete(Guid id) =>
            await repository.Delete(id);

        public async Task<IList<Product>> GetAll() =>
            await repository.GetAll();

        public async Task<Product> GetById(Guid id) =>
            await repository.GetById(id);

        public async Task Update(Product entity) =>
            await repository.Update(entity);
        public async Task<IList<Product>> GetItemsByName(Expression<Func<Product, bool>> condition) => 
            await repository.GetItemsByName(condition);

        public void Dispose()
        {
            repository?.Dispose();
        }
    }
}
