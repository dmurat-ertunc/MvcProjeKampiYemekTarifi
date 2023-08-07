using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Tarifler
    {
        [Key]
        public int Id { get; set; }
        public string TarifAd { get; set; }
        public string Aciklama { get; set; }
        public string Tarif { get; set; }
        public string Foto { get; set; }
        public int KategoriId { get; set; }
        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
