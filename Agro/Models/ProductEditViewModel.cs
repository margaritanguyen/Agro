using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        [Unicode]
        public string Number { get; set; }

        [Required]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        [Unicode]
        public string ShortName { get; set; }

        [Required]
        public float MinBatchSize { get; set; }

        [Required]
        public float MaxBatchSize { get; set; }

        [Required]
        public int MixTime { get; set; }

        [Required]
        public int DryMixTime { get; set; }

        public AnimalGroup? AnimalGroup { get; set; }
        public int? AnimalGroupId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        public IList<ProductRecipe>? ProductRecipes { get; set; }
    }
}