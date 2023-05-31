using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.DataAccess.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        [Unicode]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
