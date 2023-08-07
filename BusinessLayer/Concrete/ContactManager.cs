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
    public class ContactManager : IContactService
    {
        IContactDal contactDal;
        public ContactManager (IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }
        public void TAdd(Contact t)
        {
            contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            contactDal.Delete(t);
        }

        public Contact TGetById(int id)
        {
            return contactDal.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return contactDal.GetList();
        }
        public List<Contact> TGetList2()
        {
            //return tariflerDal.GetList();
            return contactDal.GetList().OrderByDescending(x => x.Id).Take(2).ToList();
        }

        public void TUpdate(Contact t)
        {
            contactDal.Update(t);
        }
    }
}
