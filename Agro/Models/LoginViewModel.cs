using System.ComponentModel.DataAnnotations;

namespace Agro.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "������������ ����.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "������������ ����.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}