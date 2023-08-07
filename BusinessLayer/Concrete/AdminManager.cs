using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramewoek;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void TAdd(Admin t)
        {
            adminDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            adminDal.Delete(t);
        }

        public Admin TGetById(int id)
        {
            return adminDal.GetByID(id);
        }

        public List<Admin> TGetList()
        {
            return adminDal.GetList();
        }
        public List<Admin> TGetList2()
        {
            //return tariflerDal.GetList();
            return adminDal.GetList().OrderByDescending(x => x.AdminId).Take(2).ToList();
        }

        public void TUpdate(Admin t)
        {
            adminDal.Update(t);
        }
    }
}
