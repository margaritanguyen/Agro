using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.DataAccess.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Area
    {
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }

        public virtual ICollection<Silo> Silos { get; set; }

    }
}
