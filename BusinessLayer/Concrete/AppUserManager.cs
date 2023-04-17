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
    public class AppUserManager : IAppUserService 
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Tadd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void Tupdate(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
