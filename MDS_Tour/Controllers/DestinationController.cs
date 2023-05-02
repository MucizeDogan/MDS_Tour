using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());  //DestinationManager sınıfından bir nesne türettik paramaetre belediği içinde EfDestinationDal ı ekledil
        
        public IActionResult Index()
        {
            var data = destinationManager.TGetList();
            return View(data);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            
            var data = destinationManager.TgetById(id);
            return View(data);
        }
        
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
