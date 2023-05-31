using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class ProductService : ServiceConstructor, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await UnitOfWork.Products.Create(product);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await UnitOfWork.Products.Get(id);
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            IList<Product> products = await UnitOfWork.Products.GetAll();
            return products;
        }

        public async Task UpdateProduct(Product product)
        {
            await UnitOfWork.Products.Update(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await UnitOfWork.Products.Delete(product);
        }
    }
}
