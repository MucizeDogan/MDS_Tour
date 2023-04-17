using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AppBrandDemePartial()
        {
            return PartialView();
        }

        public PartialViewResult LeftSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}
