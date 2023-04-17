using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;

namespace MDS_Tour.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
        
        public IViewComponentResult Invoke()
        {
            var data = subAboutManager.TGetList();
            return View(data);  
        }
    }
}
