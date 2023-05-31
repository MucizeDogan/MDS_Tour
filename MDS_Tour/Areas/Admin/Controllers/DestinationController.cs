using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]

    public class DestinationController : Controller
    {
        
        IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;


        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

      
        public async Task <IActionResult> Index()
        {
           //var user =await _userManager.GetUserAsync(User);
           // if(await _userManager.IsInRoleAsync(user,"Admin"))
           // {
           //    var data = _destinationService.TGetList();
           //     return View(data);
           // }
           // else
           // {
           //     return RedirectToAction("Index","AccessDenied");
                
           // }

            var data = _destinationService.TGetList();
            return View(data);
            
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            if(!ModelState.IsValid)
            {
                return View(destination);
            }
            _destinationService.Tadd(destination);
            return RedirectToAction("Index");
        } 

        public IActionResult DeleteDestination(int id)
        {
            var data = _destinationService.TgetById(id);
            _destinationService.Tdelete(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var data = _destinationService.TgetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.Tupdate(destination);
            return RedirectToAction("Index");
        }
    }
}
