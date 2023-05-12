using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
