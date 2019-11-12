using System.ComponentModel.DataAnnotations;

namespace Posto.ApplicationCore.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Informe o login!")]
        public string login { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        public string password { get; set; }
    }
}