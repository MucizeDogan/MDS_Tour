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
        private readonly ICommentService _commentService;
        public UserController(IAppUserService appUserService, IReservationService reservationService, ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _commentService = commentService;
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
            return RedirectToAction("/Admin/User/Index/");
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
            var data = _commentService.TGetListCommentWithoutDestinationAndUser(id, true);
            return View(data);
        }
        public IActionResult DeleteComment(int id)
        {
            var data = _commentService.TgetById(id);
            _commentService.Tdelete(data);
            return RedirectPermanent("/Admin/User/Index/");
        }
        public IActionResult ReservationUser(int id)
        {
            
            var data = _reservationService.GetListReservationByOld(id);
            return View(data);

        }
    }
}
