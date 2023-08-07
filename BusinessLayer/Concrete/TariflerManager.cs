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
    public class TariflerManager : ITariflerService
    {
        ITariflerDal tariflerDal;
        public TariflerManager(ITariflerDal tariflerDal)
        {
            this.tariflerDal = tariflerDal;
        }

        public void TAdd(Tarifler t)
        {
            tariflerDal.Insert(t);
        }

        public void TDelete(Tarifler t)
        {
            tariflerDal.Delete(t);
        }

        public Tarifler TGetById(int id)
        {
            return tariflerDal.GetByID(id);
        }

        public List<Tarifler> TGetList()
        {
            //return tariflerDal.GetList();
            return tariflerDal.GetList().OrderByDescending(x => x.Id).ToList();
        }
        public List<Tarifler> TGetList2()
        {
            //return tariflerDal.GetList();
            return tariflerDal.GetList2().OrderByDescending(x => x.Id).Take(2).ToList();
        }



        public void TUpdate(Tarifler t)
        {
            tariflerDal.Update(t);
        }
    }
}
