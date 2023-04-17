using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Default
{
    public class SliderPartial : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
