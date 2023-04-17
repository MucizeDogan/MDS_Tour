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
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal subAboutDal;
        

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            this.subAboutDal = subAboutDal;
        }

       

        public void Tadd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public SubAbout TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetList()
        {
           return subAboutDal.GetList();
        }

        public void Tupdate(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
