using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());


        public IViewComponentResult Invoke(int id)
        {
            var data = _commentManager.TGetListCommentWithoutDestinationAndUser(id, false);
            return View(data);
        }
    }
}
