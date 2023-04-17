using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
