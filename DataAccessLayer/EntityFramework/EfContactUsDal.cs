using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactUsByStatusFalse()
        {
            using (var context = new Context())
            {
                var data = context.ContactUss.Where
                    (x => x.Status == false).ToList();
                return data;
            }
        }

        public List<ContactUs> GetListContactUsByStatusTrue()
        {
            using (var context = new Context())
            {
                var data = context.ContactUss.Where
                    (x => x.Status == true).ToList();
                return data;
            }
        }
    }
}
