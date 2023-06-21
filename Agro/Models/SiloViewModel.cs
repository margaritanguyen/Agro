using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.Models
{
    public class SiloViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [MaxLength(32)]
        [Unicode]
        public string Number { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float MaxCapacity { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float RealStock { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float MaxComponentSize { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public float FreeFall { get; set; }

        public Area? Area { get; set; }
        public int AreaId { get; set; }

        public SiloType? SiloType { get; set; }
        public int SiloTypeId { get; set; }

        public Resource? Resource { get; set; }
        public int? ResourceId { get; set; }

        public Resource? PreviousResource { get; set; }
        public int? PreviousResourceId { get; set; }

        public Balance? DefaultBalance { get; set; }
        public int? DefaultBalanceId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public DateTime LastChange { get; set; }
    }
}