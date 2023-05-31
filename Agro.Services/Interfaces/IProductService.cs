using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<IList<Product>> GetAllProducts();
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
