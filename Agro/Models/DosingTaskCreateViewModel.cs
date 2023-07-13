using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class DosingTaskCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public float BatchSize { get; set; }

        [Required]
        public int BatchCount { get; set; }

        public Silo? SiloOne { get; set; }
        public int? SiloOneId { get; set; }

        public Silo? SiloTwo { get; set; }
        public int? SiloTwoId { get; set; }

        public ProductRecipe? ProductRecipe { get; set; }
        public int ProductRecipeId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? ClientName { get; set; }

        public Product? Product { get; set; }
        public int? ProductId { get; set; }

    }
}