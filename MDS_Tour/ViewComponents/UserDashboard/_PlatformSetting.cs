using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.UserDashboard
{
    public class _PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
