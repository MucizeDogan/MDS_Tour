using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager _guideManager = new GuideManager(new EfGuidesDal());
        public IActionResult Index()
        {
            var data = _guideManager.TGetList();
            return View(data);
        }
    }
}
