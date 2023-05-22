using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : BaseController
    {
        IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var data = _reservationService.TGetAdminListReservationByWaiting();
            return View(data);
        }

        public IActionResult AdminAccepted()
        {
            var data = _reservationService.TGetAdminListReservationByAccepted();
            return View(data);
        }

        public IActionResult AdminOld()
        {
            var data = _reservationService.TGetAdminListReservationByOld();
            return View(data);
        }

        public IActionResult DeleteReservation(int id)
        {
            var data = _reservationService.TgetById(id);
            _reservationService.Tdelete(data);
            return RedirectPermanent("/Admin/Reservation/Index");

        }

        public IActionResult ChangeApproveStatus(int id)
        {
            _reservationService.TChangeToApproveStatus(id);
            return RedirectPermanent("/Admin/Reservation/Index");
        }

        public IActionResult ChangeOldStatus(int id)
        {
            _reservationService.TChangeToOldStatus(id);
            return RedirectPermanent("/Admin/Reservation/Index");
        }
    }
}
