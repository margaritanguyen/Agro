using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class ProductRecipeService : ServiceConstructor, IProductRecipeService
    {
        public ProductRecipeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ProductRecipe> CreateProductRecipe(ProductRecipe productRecipe)
        {
            return await UnitOfWork.ProductRecipes.Create(productRecipe);
        }

        public async Task<ProductRecipe> GetProductRecipe(int id)
        {
            return await UnitOfWork.ProductRecipes.Get(id);
        }

        public async Task<IList<ProductRecipe>> GetAllProductRecipes()
        {
            IList<ProductRecipe> productRecipes = await UnitOfWork.ProductRecipes.GetAll();
            return productRecipes;
        }

        public async Task<IList<ProductRecipe>> GetAllProductRecipesByProductId(int productId)
        {
            IList<ProductRecipe> productRecipes = await UnitOfWork.ProductRecipes.GetAll();
            return productRecipes.Where(x => x.ProductId == productId).ToList();
        }

        public async Task UpdateProductRecipe(ProductRecipe productRecipe)
        {
            await UnitOfWork.ProductRecipes.Update(productRecipe);
        }

        public async Task DeleteProductRecipe(ProductRecipe productRecipe)
        {
            await UnitOfWork.ProductRecipes.Delete(productRecipe);
        }
    }
}
