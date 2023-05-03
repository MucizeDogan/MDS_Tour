using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal()); 
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            //var data = await _userManager.FindByNameAsync(User.Identity.Name);  //Kullanıcı adına göre bul bulduktan sonra bu bulduğun id yi ViewBag.userID ye yapıştır
            //ViewBag.userId = data.Id;
            //ViewBag.DestId=id;

            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommnentStatus = false;
            _commentManager.Tadd(p);
            
            return RedirectToAction("Index","Destination");
        }
    }
}
