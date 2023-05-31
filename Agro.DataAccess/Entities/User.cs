using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.DataAccess.Entities
{
    [Index(nameof(UserName), IsUnique = true)]

    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(32)]
        [Unicode]
        public string UserName { get; set; }

        [Required]
        [MaxLength(64)]
        [Unicode]
        public string FullName { get; set; }

        [Required]
        [MaxLength(85)]
        public string PasswordHash { get; set; }

        public UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }

    }
}
