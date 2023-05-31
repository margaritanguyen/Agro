using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.DataAccess.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        public ProductRecipe ProductRecipe { get; set; }
        public int ProductRecipeId { get; set; }

        public Resource Resource { get; set; }
        public int ResourceId { get; set; }

        [Required]
        public float ResourceContent { get; set; }
 
        [Required]
        public int DosingPriority { get; set; }

    }
}
