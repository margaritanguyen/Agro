﻿using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IProductRecipeService
    {
        Task<ProductRecipe> CreateProductRecipe(ProductRecipe productRecipe);
        Task<ProductRecipe> GetProductRecipe(int id);
        Task<IList<ProductRecipe>> GetAllProductRecipes(int productId);
        Task UpdateProductRecipe(ProductRecipe productRecipe);
        Task DeleteProductRecipe(ProductRecipe productRecipe);
    }
}
