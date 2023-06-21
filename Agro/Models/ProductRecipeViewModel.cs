using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class ProductRecipeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int Version { get; set; }

        public Product? Product { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DefaultValue(true)]
        public bool IsEnabled { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public DateTime LastChange { get; set; }
       
        public IList<RecipeIngredient>? RecipeIngredients { get; set; }
    }
}