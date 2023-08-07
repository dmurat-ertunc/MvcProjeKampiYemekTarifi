using System.ComponentModel.DataAnnotations;

namespace MvcProjeKampi.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "email")]
        [Required(ErrorMessage = "E-Posta alanı boş bırakılamaz")]
        public string Email {  get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string Password { get; set; }
    }
}
