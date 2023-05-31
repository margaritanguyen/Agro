using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<RecipeIngredient> CreateRecipeIngredient(RecipeIngredient product);
        Task<RecipeIngredient> GetRecipeIngredient(int id);
        Task<IList<RecipeIngredient>> GetAllRecipeIngredients(int recipeId);
        Task UpdateRecipeIngredient(RecipeIngredient product);
        Task DeleteRecipeIngredient(RecipeIngredient product);
    }
}
