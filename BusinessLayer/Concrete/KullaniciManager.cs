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
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal) 
        {
            this.kullaniciDal = kullaniciDal;
        }
        public void TAdd(Kullanici t)
        {
            kullaniciDal.Insert(t);
        }

        public void TDelete(Kullanici t)
        {
            kullaniciDal.Delete(t);
        }

        public Kullanici TGetById(int id)
        {
            return kullaniciDal.GetByID(id);
        }

        public List<Kullanici> TGetList()
        {
            return kullaniciDal.GetList();
        }
        public List<Kullanici> TGetList2()
        {
            //return tariflerDal.GetList();
            return kullaniciDal.GetList().OrderByDescending(x => x.Id).Take(2).ToList();
        }

        public void TUpdate(Kullanici t)
        {
            kullaniciDal.Update(t);
        }
    }
}
