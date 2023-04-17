using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);   //T türünde bir t parametresi al
        void Delete(T t);
        void Update(T t); 
        List<T> GetList();
        T GetById(int id);
        List<T> GetListByIf(Expression<Func<T,bool>>filter);
    }
}
 