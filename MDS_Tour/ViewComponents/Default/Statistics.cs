using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Default
{
    public class Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.a1 = c.Destinations.Count();
            ViewBag.a2=c.Guidess.Count();
            ViewBag.a3 = "631";
            ViewBag.a4 = "56";
            return View();
        }

    }
}
