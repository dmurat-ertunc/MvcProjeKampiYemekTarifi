using System.ComponentModel.DataAnnotations;

namespace MvcProjeKampi.ViewModels
{
    public class MesajViewModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public int kullaniciId { get; set; }

        [Display(Name = "Konu")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Konu { get; set; }

        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Mesaj { get; set; }


    }
}
