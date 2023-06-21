using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [MaxLength(32)]
        [Unicode]
        public string Number { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [MaxLength(32)]
        [Unicode]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public float MinBatchSize { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public float MaxBatchSize { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int MixTime { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int DryMixTime { get; set; }

        public AnimalGroup? AnimalGroup { get; set; }
        public int? AnimalGroupId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public DateTime LastChange { get; set; }
    }
}