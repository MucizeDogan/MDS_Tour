using BusinessLayer.Abstract.AbstractUoW;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUnitofWork
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitofWorkDal _unitofWorkDal;

        public AccountManager(IAccountDal accountDal, IUnitofWorkDal unitofWorkDal)
        {
            _accountDal = accountDal;
            _unitofWorkDal = unitofWorkDal;
        }

        public Account TGetById(int id)
        {
            return _accountDal.GetById(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _unitofWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _unitofWorkDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _unitofWorkDal.Save();
        }
    }
}
