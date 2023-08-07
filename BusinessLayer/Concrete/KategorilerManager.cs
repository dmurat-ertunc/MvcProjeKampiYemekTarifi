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
    public class KategorilerManager : IKategorilerService
    {
        IKategorilerDal kategorilerDal;
        public KategorilerManager(IKategorilerDal kategorilerDal)
        {
            this.kategorilerDal = kategorilerDal;
        }

        public void TAdd(Kategoriler t)
        {
            kategorilerDal.Insert(t);
        }

        public void TDelete(Kategoriler t)
        {
            kategorilerDal.Delete(t);
        }

        public Kategoriler TGetById(int id)
        {
            return kategorilerDal.GetByID(id);
        }

        public List<Kategoriler> TGetList()
        {
            return kategorilerDal.GetList();
        }
        public List<Kategoriler> TGetList2()
        {
            //return tariflerDal.GetList();
            return kategorilerDal.GetList().OrderByDescending(x => x.Id).Take(2).ToList();
        }

        public void TUpdate(Kategoriler t)
        {
            kategorilerDal.Update(t);
        }
    }
}
