using Agro.DataAccess.Entities;

namespace Agro.Models
{
    public class ProductRecipeImportViewModel
    {
        public List<Product> Products { get; set; }
        public List<Resource> Resources { get; set; }
        public List<ProductRecipe> ProductRecipes { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public ProductRecipeImportViewModel()
        {
            Products = new List<Product>();
            Resources = new List<Resource>();
            ProductRecipes = new List<ProductRecipe>();
            RecipeIngredients = new List<RecipeIngredient>();
        }
    }
}
