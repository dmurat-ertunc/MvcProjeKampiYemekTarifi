using System.ComponentModel.DataAnnotations;

namespace MvcProjeKampi.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Display(Name = "Eski Şifre")]
        [Required(ErrorMessage = "Eski Şifre alanı boş bırakılamaz")]
        public string OldPassword { get; set; }

        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Yeni Şifre alanı boş bırakılamaz")]
        public string NewPassword { get; set; }

        [Display(Name="Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Yeni Şifre Tekrar alanı boş bırakılamaz")]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler Uyşmuyor")]
        public string ConfirmNewPassword { get; set;}
    }
}
