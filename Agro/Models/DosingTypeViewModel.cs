using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class DosingTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [MaxLength(64)]
        [Unicode]
        public string Name { get; set; }
    }
}