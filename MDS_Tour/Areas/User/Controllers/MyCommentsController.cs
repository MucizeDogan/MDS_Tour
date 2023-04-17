using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.User.Controllers
{
    public class MyCommentsController : Controller
    {
        [Area("User")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
