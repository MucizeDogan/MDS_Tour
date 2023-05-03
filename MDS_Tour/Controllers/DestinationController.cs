using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());  //DestinationManager sınıfından bir nesne türettik paramaetre belediği içinde EfDestinationDal ı ekledil
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var data = destinationManager.TGetList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            var data2 = await _userManager.FindByNameAsync(User.Identity.Name);  //Kullanıcı adına göre bul bulduktan sonra bu bulduğun id yi ViewBag.userID ye yapıştır
            ViewBag.userId = data2.Id;
            var data = destinationManager.TGetDestinationWithGuideList(id);
            return View(data);
        }
        
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
