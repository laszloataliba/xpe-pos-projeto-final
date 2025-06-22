using System.Linq.Expressions;
using XPE.Desafio.Final5.API.Model.Domains;
using XPE.Desafio.Final5.API.Model.Respositories.Interfaces;
using XPE.Desafio.Final5.API.Model.Services.Interfaces;

namespace XPE.Desafio.Final5.API.Model.Services.Implementation
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task Create(Product entity) =>
            await productRepository.Create(entity);

        public async Task Delete(Guid Id) =>
            await productRepository.Delete(Id);

        public async Task<IList<Product>> GetAll() =>
            await productRepository.GetAll();

        public async Task<Product> GetById(Guid id) =>
            await productRepository.GetById(id);

        public async Task Update(Product entity) =>
            await productRepository.Update(entity);
        public async Task<IList<Product>> GetItemsByName(Expression<Func<Product, bool>> condition) => 
            await productRepository.GetItemsByName(condition);

        public void Dispose()
        {
            productRepository?.Dispose();
        }
    }
}
