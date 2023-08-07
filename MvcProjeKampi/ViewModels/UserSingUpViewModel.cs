using System.ComponentModel.DataAnnotations;

namespace MvcProjeKampi.ViewModels
{
    public class UserSingUpViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyad { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş geçilemez")]
        public string Cinsiyet { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Yaş alanı boş geçilemez")]
        public int Age { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
        public string UserName { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Telefon Numarası alanı boş geçilemez")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "E-Posta alanı boş geçilemez")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
