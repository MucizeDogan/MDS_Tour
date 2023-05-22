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
            _appUserDal.Delete(t);
        }

        public AppUser TgetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public void Tupdate(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}
