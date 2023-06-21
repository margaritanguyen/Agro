using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class DosingTaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int ManufNr { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public float BatchSize { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int BatchCount { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DefaultValue(0)]
        public int InProcessBatchCount { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DefaultValue(0)]
        public int ReadyBatchCount { get; set; }

        public Silo? SiloOne { get; set; }
        public int? SiloOneId { get; set; }

        public Silo? SiloTwo { get; set; }
        public int? SiloTwoId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ProductRecipe? ProductRecipe { get; set; }
        public int ProductRecipeId { get; set; }

        public TaskMessage? TaskMessage { get; set; }
        public int TaskMessageId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DefaultValue(false)]
        public bool IsReady { get; set; }
    }
}