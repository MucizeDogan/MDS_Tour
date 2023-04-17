using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        //Concrete tarafında yapacağım business metotlarının imzalarını burada tanımlayacağız.
        void Tadd(T t);
        void Tdelete(T t);
        void Tupdate(T t);
        List<T> TGetList();
        T TgetById(int id);                  // id ye göre getirebilecek bir metot
        //List<T> GetListByIf(Expression<Func<T,bool>> filter);
        // Business a gelmeden önce business tarafında tanımlayacağım bütün metotlar burada generic service den geçecek sonra concrete e gelecek

    }
}
