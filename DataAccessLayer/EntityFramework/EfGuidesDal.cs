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
    public class EfGuidesDal : GenericRepository<Guides>, IGuidesDal
    {
        Context context = new Context();
        public void ChangeToFalseStatus(int id)
        {
            var data = context.Guidess.Find(id);
            data.Status = false;
            context.SaveChanges();
        }

        public void ChangeToTrueStatus(int id)
        {
            var data = context.Guidess.Find(id);
            data.Status = true;
            context.SaveChanges();
        }
    }
}
