using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
namespace MDS_Tour.ViewComponents.Default
{
    public class Feature : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());                  // feature tablosundan veri çekmek için 

        public IViewComponentResult Invoke()
        {
            var data = featureManager.test();


            return View(data);

            //if (feature.Status)
            //{
            //    data = featureManager.TGetList();
            //    return View(data);
            //}
            //else
            //{

            //    return View(data);
            //}

        }
    }
}
