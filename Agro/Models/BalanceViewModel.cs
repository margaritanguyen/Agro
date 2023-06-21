using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class BalanceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float EmptyTolerance { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float WeighTolerance { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float MinWeight { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float MaxWeight { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int MaxDosingTime { get; set; }

        public Area? Area { get; set; }
        public int AreaId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required]
        public DateTime LastChange { get; set; }
    }
}