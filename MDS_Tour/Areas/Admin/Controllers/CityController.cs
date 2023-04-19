using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using MDS_Tour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.Tadd(destination);
            var data=JsonConvert.SerializeObject(destination); 
            return Json(data);
        }

        public IActionResult GetById(int DestinationId)
        {
            var data = _destinationService.TgetById(DestinationId);
            var jsonData= JsonConvert.SerializeObject(data);
            return Json(jsonData);
        }

    }
}
