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
    public class AboutManager : IAboutService 
    {
        // Bizim AboutDal a bir şekilde ulaşmamaız gerekiyor çnkü interface imde değerler aboutDal da (DataAccessLayer da Abstract da) 
        IAboutDal _aboutDal;        //Amacımız şu gelen entity i karşılamak gelen entity e ait repolara ulaşmak için Dependency injection dediğimiz kod bloğunu kullanmamız gerekiyor bunun içinde bizim bir constructor metoda ihtiyacımız var 
        // ctor oluşturup aboutDal a bir atama yapmam gerekiyor

        public AboutManager(IAboutDal aboutDal) // IAboutDal a bağlı olarak aboutDal isimli parametre alabilriz.
        {
            _aboutDal=aboutDal; // artık _aboutDal a değer ataması yapabilirz.
        }
        // Böylece constructor mtot aracağılıyla atama yapmış olduğumuz field a (_aboutDal) üzrinden ilgili interfacedeki metotlara erişim sağlayabilirz.

        public void Tadd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void Tdelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void Tupdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
