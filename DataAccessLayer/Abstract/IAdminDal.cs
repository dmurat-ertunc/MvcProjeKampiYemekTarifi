using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //public interface IAdminDal
    //{                             // Normalde tek başına tanımlıycak olsak bu şekilde tanımlardık. ama IGenericDal'ı ortak olarak kullanıcaz
    //    void Insert(Admin admin);
    //    void Delete(Admin admin);
    //    void Update(Admin admin);
    //    List<Admin> GetList();
    //}
    public interface IAdminDal:IGenericDal<Admin>
    {
        
    }
}
