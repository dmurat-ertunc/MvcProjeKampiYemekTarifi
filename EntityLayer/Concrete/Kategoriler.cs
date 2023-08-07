using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kategoriler
    {
        [Key]
        public int Id { get; set; }
        public string Cesit { get; set; }
        //public ICollection<Tarifler> TblTarifler { get; set; }

    }
}
