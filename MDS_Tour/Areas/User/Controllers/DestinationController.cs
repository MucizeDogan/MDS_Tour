using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());


        public IActionResult Index()
        {
            var data = _destinationManager.TGetList().ToList();
            return View(data);
        }

        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"]=searchString;
            var data = from x in _destinationManager.TGetList() select x;
            if(!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(y=>y.City.Contains(searchString));
            }
            return View(data.ToList());
        }
    }
}
