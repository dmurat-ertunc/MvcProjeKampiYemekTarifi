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
    public class YorumlarManager : IYorumlarService
    {
        IYorumlarDal yorumlarDal;
        public YorumlarManager(IYorumlarDal yorumlarDal)
        {
            this.yorumlarDal = yorumlarDal;
        }
        public void TAdd(Yorumlar t)
        {
            yorumlarDal.Insert(t);
        }

        public void TDelete(Yorumlar t)
        {
            yorumlarDal.Delete(t);
        }

        public Yorumlar TGetById(int id)
        {
            return yorumlarDal.GetByID(id);
        }

        public List<Yorumlar> TGetList()
        {
            return yorumlarDal.GetList();
        }
        public List<Yorumlar> TGetList2()
        {
            //return tariflerDal.GetList();
            return yorumlarDal.GetList().OrderByDescending(x => x.Id).Take(2).ToList();
        }

        public void TUpdate(Yorumlar t)
        {
            yorumlarDal.Update(t);
        }
    }
}
