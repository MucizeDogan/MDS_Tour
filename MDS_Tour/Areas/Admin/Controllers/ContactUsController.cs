using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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

        [HttpGet]
        public IActionResult Message(int id)
        {
            var data = _contactUsService.TgetById(id);
            return View(data);
        }
        public IActionResult Message(ContactUs contactUs)
        {
            return View();
        }

        public IActionResult DeleteMessage(int id)
        {
            var data = _contactUsService.TgetById(id);
            _contactUsService.Tdelete(data);
            return RedirectPermanent("/Admin/ContactUs/Index/");
        }

    }
}
