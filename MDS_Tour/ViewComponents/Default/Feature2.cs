using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Default
{
    public class Feature2 : ViewComponent
    {
        Feature2Manager feature2Manager = new Feature2Manager(new EfFeature2Dal());
        public IViewComponentResult Invoke()
        {
            var data = feature2Manager.GetList2();
            return View(data);
        }
    }

}
