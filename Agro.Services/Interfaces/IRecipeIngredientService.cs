using Agro.DataAccess.Entities;

namespace Agro.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<RecipeIngredient> CreateRecipeIngredient(RecipeIngredient recipeIngredient);
        Task<IList<RecipeIngredient>> CreateRangeRecipeIngredient(IList<RecipeIngredient> recipeIngredients);
        Task<RecipeIngredient> GetRecipeIngredient(int id);
        Task<IList<RecipeIngredient>> GetAllRecipeIngredients(int productRecipeId);
        Task UpdateRecipeIngredient(RecipeIngredient recipeIngredient);
        Task DeleteRecipeIngredient(RecipeIngredient recipeIngredient);
    }
}
