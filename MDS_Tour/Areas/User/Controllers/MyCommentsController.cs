using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    public class MyCommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public MyCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var userId = Convert.ToInt32(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value);
            var data = _commentService.TGetListCommentWithoutDestinationAndUser(userId,true);
            return View(data);
        }
    }
}
