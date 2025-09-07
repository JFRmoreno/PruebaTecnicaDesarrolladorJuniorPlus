using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetListProduct();
        Task<Product?> GetToProduct(string name);
        Task<Product?> UpdateProduct(int id);
    }
}
