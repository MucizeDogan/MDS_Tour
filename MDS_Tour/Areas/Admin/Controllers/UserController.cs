using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var data = _appUserService.TGetList();
            return View(data);
        }

        public IActionResult DeleteUser(int id)
        {
            var data = _appUserService.TgetById(id);
            _appUserService.Tdelete(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var data = _appUserService.TgetById(id);
            return View(data);
            
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.Tupdate(appUser);
            return RedirectPermanent("/Admin/User/Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            
            var data = _reservationService.GetListReservationByOld(id);
            return View(data);

        }
    }
}
