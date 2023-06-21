using Agro.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class RecipeIngredientViewModel
    {
        public int Id { get; set; }

        public ProductRecipe? ProductRecipe { get; set; }
        public int ProductRecipeId { get; set; }

        public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float ResourceContent { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int DosingPriority { get; set; }


    }
}