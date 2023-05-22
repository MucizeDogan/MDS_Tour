using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void Tadd(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(ContactUs t)
        {
            _contactUsDal.Delete(t);
        }

        public ContactUs TgetById(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListContactUsByStatusFalse()
        {
            return _contactUsDal.GetListContactUsByStatusFalse();
        }

        public List<ContactUs> TGetListContactUsByStatusTrue()
        {
           return _contactUsDal.GetListContactUsByStatusTrue();
        }

        public void Tupdate(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}
