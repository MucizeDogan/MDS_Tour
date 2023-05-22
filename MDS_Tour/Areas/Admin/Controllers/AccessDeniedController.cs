using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
