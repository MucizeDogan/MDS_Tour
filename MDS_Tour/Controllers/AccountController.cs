using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    public class AccountController : Controller
    {

        public async Task<IActionResult> LogOut()
        {
            // Kullanıcının oturumunu sonlandır
            await HttpContext.SignOutAsync();

            // SignIn sayfasına yönlendir
            return RedirectToAction("SignIn", "Login");
        }
    }
}
