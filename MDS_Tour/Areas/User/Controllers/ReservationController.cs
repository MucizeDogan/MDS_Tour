using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyActiveReservation()
        {
           
            var data =await _userManager.FindByNameAsync(User.Identity.Name);
            var datalist = _reservationManager.GetListReservationByAccepted(data.Id);
          
            return View(datalist);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var data = await _userManager.FindByNameAsync(User.Identity.Name);
            var dataList = _reservationManager.GetListReservationByOld(data.Id);
            return View(dataList);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var data = await _userManager.FindByNameAsync(User.Identity.Name);
            var dataList = _reservationManager.GetListReservationByWaitApproval(data.Id);
            Reservation reservation = new Reservation();
            reservation.Status = "Waiting";
            return View(dataList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> data = (from x in _destinationManager.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.City,
                                             Value = x.DestinationId.ToString()
                                         }).ToList();
            ViewBag.v = data;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            //if (!ModelState.IsValid)
            //{
            //    List<SelectListItem> data = (from x in _destinationManager.TGetList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = x.City,
            //                                     Value = x.DestinationId.ToString()
            //                                 }).ToList();
            //    ViewBag.v = data;
            //    return View(p);
            //}

            var userIdentity = (ClaimsIdentity)User.Identity;

            p.AppUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.Status = "Waiting";
            _reservationManager.Tadd(p);
            //ViewBag.v = p.DestinationId;
            return RedirectToAction("MyApprovalReservation");
        }
    }
}
