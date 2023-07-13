using Agro.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class UserViewModel
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
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        public UserRole? UserRole { get; set; }
        public int UserRoleId { get; set; }

    }
}