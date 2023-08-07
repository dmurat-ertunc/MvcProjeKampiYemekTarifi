using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yorumlar
    {
        [Key]
        public int Id { get; set; }
        public string Yorum { get; set; }
        public int TarifId { get; set; }
        public int KullaniciId { get; set; }
        

    }
}
