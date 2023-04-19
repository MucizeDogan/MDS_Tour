using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
namespace DataAccessLayer.Abstract
{
    public interface IGuidesDal : IGenericDal<Guides>
    {
        //public void ChangeGuideStatus(int id)
        //{
        //    Context c = new Context();
        //    var guide = c.Guidess.Find(id);

        //    //Bu tek satır kodda anlatılmak istenen: eğer guide durumu true ise false, false ise true yap demek.
        //    guide.Status = (bool)guide.Status ? false : true;

        //    c.SaveChanges();
        //}

        void ChangeToTrueStatus(int id);

        void ChangeToFalseStatus(int id);
        
    }
}
