using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.DataAccess.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Silo
    {
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(32)]
        [Unicode]
        public string Number { get; set; }

        [Required]
        public float MaxCapacity { get; set; }

        [Required]
        public float RealStock { get; set; }

        [Required]
        public float MaxComponentSize { get; set; }

        [Required]
        public float FreeFall { get; set; }

        public Area Area { get; set; }
        public int AreaId { get; set; }

        public SiloType SiloType { get; set; }
        public int SiloTypeId { get; set; }

        public Resource Resource { get; set; }
        public int? ResourceId { get; set; }

        public Resource PreviousResource { get; set; }
        public int? PreviousResourceId { get; set; }

        public Balance DefaultBalance { get; set; }
        public int? DefaultBalanceId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required]
        public DateTime LastChange { get; set; }
    }
}
