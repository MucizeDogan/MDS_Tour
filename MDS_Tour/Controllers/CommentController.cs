using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal()); 
        [HttpGet]
        public PartialViewResult AddComment()
        {
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
