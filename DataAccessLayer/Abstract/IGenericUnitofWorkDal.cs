using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericUnitofWorkDal<T> where T : class
    {
        void Insert(T t);   //T türünde bir t parametresi al
        void Update(T t);
        void MultiUpdate(List<T> t);        // MultiUpdate metodu sayesinde sayesinde birden fazla kaydı güncelleyebileceğiz.
        T GetById(int id);
        
    }
}
