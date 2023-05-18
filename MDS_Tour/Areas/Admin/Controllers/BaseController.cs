using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MDS_Tour.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!User.IsInRole("Admin"))
            {
                // Eğer kullanıcı admin rolünde değilse, erişimi reddetmek için bir hata sayfasına yönlendirin.
                // İsterseniz başka bir işlem de yapabilirsiniz, örneğin kullanıcıyı ana sayfaya yönlendirebilirsiniz.
                context.Result = RedirectToMyArea();



            }

            base.OnActionExecuting(context);
        }

        protected IActionResult RedirectToMyArea()
        {
            object routeValues = null;
            return RedirectToPage("/AccessDenied/Index");
        }
    }
}
