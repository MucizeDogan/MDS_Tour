using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class CommentController : BaseController
    {
        //CommentManager _commentManager = new CommentManager(new EfCommentDal());  //Ef bağımlılığından kurtulmak için aşağıdaki refactoring yöntemini kullandık artık bnuna gerek yok...

        private readonly ICommentService _commentService; // ICommentService örnekle, commentService e atama yapabilmek için constructor a ihtiyacımız var bunun içindeCommentController ın üzerine gelip ctrl ile birlikte noktaya tıklayıp generate constructor a tıklıyoruz.

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var data = _commentService.TGetListCommentWithDestination();            /*var data=  _commentManager.TGetListCommentWithDestination();*/
            return View(data);
        }

        public IActionResult DeleteComment(int id)
        {
            var data = _commentService.TgetById(id);
            _commentService.Tdelete(data);
            return RedirectToAction("Index");
        }
    }
}
