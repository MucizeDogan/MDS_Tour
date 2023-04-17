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
    public class TestimonialMenager : ITestimonialService
    {
        ITestImonialDal _testImonialDal;

        public TestimonialMenager(ITestImonialDal testImonialDal)
        {
            _testImonialDal = testImonialDal;
        }

        public void Tadd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public Testimonial TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetList()
        {
            return _testImonialDal.GetList();
        }

        public void Tupdate(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
