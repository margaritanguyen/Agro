using Agro.DataAccess.DbPatterns.Interfaces;
using Agro.DataAccess.Entities;
using Agro.Services.Interfaces;

namespace Agro.Services.Services
{
    public class RecipeIngredientService : ServiceConstructor, IRecipeIngredientService
    {
        public RecipeIngredientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<RecipeIngredient> CreateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            return await UnitOfWork.RecipeIngredients.Create(recipeIngredient);
        }

        public async Task<IList<RecipeIngredient>> CreateRangeRecipeIngredient(IList<RecipeIngredient> recipeIngredients)
        {
            return await UnitOfWork.RecipeIngredients.CreateRange(recipeIngredients);
        }

        public async Task<RecipeIngredient> GetRecipeIngredient(int id)
        {
            return await UnitOfWork.RecipeIngredients.Get(id);
        }

        public async Task<IList<RecipeIngredient>> GetAllRecipeIngredients(int productRecipeId)
        {
            IList<RecipeIngredient> products = await UnitOfWork.RecipeIngredients.GetAll();
            return products.Where(x => x.ProductRecipeId == productRecipeId).ToList();
        }

        public async Task UpdateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            await UnitOfWork.RecipeIngredients.Update(recipeIngredient);
        }

        public async Task DeleteRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            await UnitOfWork.RecipeIngredients.Delete(recipeIngredient);
        }
    }
}
