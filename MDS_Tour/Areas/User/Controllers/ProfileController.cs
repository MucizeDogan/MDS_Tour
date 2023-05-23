using EntityLayer.Concrete;
using MDS_Tour.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _userManager.FindByNameAsync(User.Identity.Name);
            if (data == null)
                return NotFound();
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = data.Name;
            userEditViewModel.surname = data.Surname;
            userEditViewModel.phonenumber = data.PhoneNumber;

            userEditViewModel.imageurl = "/userimages/" + data.Image;

            userEditViewModel.mail = data.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {

                var resource = Directory.GetCurrentDirectory();             // Kaynak (Aktif)
                var extansion = Path.GetExtension(p.Image.FileName);        // Uzantı almak için
                var imagename = Guid.NewGuid() + extansion;                  // Resim ismş karışmaması için guidden aldık
                var savelocation = resource + "/wwwroot/userimages/" + imagename; // Resimin kaydedileceği konum
                var stream = new FileStream(savelocation, FileMode.Create);     //akış değeri oluşturacağız.
                await p.Image.CopyToAsync(stream);                              //Akıştan gelen değerine kopylayacaksın 
                user.Image = imagename;     //Kopyalama işleminden sonra user(sisteme authentice olan kullanıcının imageurl değerini imagename den gelen değer olarak ata 
            }

            user.Name = p.name;
            user.Surname = p.surname;
            user.PhoneNumber = p.phonenumber;
            if (!string.IsNullOrEmpty(p.password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            }
            //if (user.PasswordHash != null)
            //{
            var data = await _userManager.UpdateAsync(user);
            if (data.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            //}

            return View();
        }
    }
}
