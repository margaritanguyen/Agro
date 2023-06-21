using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class TaskMessageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [MaxLength(64)]
        [Unicode]
        public string Message { get; set; }
    }
}