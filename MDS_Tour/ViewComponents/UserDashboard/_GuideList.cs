using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.UserDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EfGuidesDal());
        public IViewComponentResult Invoke()
        {
            var values = guideManager.TGetList();
            return View(values);
        }
    }
}
