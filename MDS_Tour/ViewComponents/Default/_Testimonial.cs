using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        TestimonialMenager testimonialMenager = new TestimonialMenager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var data = testimonialMenager.TGetList();
            return View(data); 
        }
    }
}
