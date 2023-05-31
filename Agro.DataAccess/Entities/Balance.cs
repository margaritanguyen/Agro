using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Agro.DataAccess.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Balance
    {
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        [Required]
        public float EmptyTolerance { get; set; }

        [Required]
        public float WeighTolerance { get; set; }

        [Required]
        public float MinWeight { get; set; }

        [Required]
        public float MaxWeight { get; set; }

        [Required]
        public int MaxDosingTime { get; set; }

        public Area Area { get; set; }
        public int AreaId { get; set; }

        [MaxLength(64)]
        [Unicode]
        [AllowNull]
        public string? Comment { get; set; }

        [Required]
        public DateTime LastChange { get; set; }

        public virtual ICollection<Silo> Silos { get; set; }

    }
}
