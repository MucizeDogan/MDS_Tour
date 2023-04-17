using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.ViewComponents.Default
{
    public class PopularDestinations : ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());  //DestinationManager sınıfından bir nesne türettik paramaetre belediği içinde EfDestinationDal ı ekledil
        public IViewComponentResult Invoke()
        {
            var data = destinationManager.TGetList();
            return View(data);
        }
    }
}
