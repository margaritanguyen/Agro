using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class CurrentStateViewModel
    {
        public int Id { get; set; }

        public int ManufNr { get; set; }

        public int Priority { get; set; }

        public float BatchSize { get; set; }

        public int BatchCount { get; set; }

        public int InProcessBatchCount { get; set; }

        public int ReadyBatchCount { get; set; }
        public ProductRecipe? ProductRecipe { get; set; }
        public int ProductRecipeId { get; set; }

        public TaskMessage? TaskMessage { get; set; }
        public int TaskMessageId { get; set; }
    }
}