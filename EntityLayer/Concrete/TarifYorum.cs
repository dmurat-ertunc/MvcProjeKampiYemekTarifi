using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TarifYorum
    {
        public IEnumerable<Tarifler> Deger1 { get; set; }
        public IEnumerable<Yorumlar> Deger2 { get; set; }
        public IEnumerable<AppUser> Deger3{ get; set; }
        public IEnumerable<YorumlarTmp2> Deger4{ get; set; }
    }
}
