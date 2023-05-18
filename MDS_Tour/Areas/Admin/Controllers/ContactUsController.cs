using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : BaseController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var data = _contactUsService.TGetListContactUsByStatusTrue();
            return View(data);
        }
    }
}
