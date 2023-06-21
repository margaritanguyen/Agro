using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}