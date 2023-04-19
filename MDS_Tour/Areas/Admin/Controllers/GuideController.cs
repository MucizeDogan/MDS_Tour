using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Guide")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuidesService _guidesService;

        public GuideController(IGuidesService guidesService)
        {
            _guidesService = guidesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _guidesService.TGetList();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guides guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result=validationRules.Validate(guide);
            if(result.IsValid)
            {
                _guidesService.Tadd(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var data = _guidesService.TgetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditGuide(Guides guides)
        {
            _guidesService.Tupdate(guides);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        public IActionResult ChangeToStatusTrue(int id)
        {
            _guidesService.TChangeToTrueStatus(id);
            return RedirectToAction("Index","Guide", new {area="Admin"} );
        }
        public IActionResult ChangeToStatusFalse(int id)
        {
            _guidesService.TChangeToFalseStatus(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
