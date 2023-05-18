using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using MDS_Tour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class CityController : BaseController
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
            if(data==null)
            {
                return NotFound();
            }
            else
            {
                var jsonData = JsonConvert.SerializeObject(data);
                return Json(jsonData);
                
            }
            
        }
        public IActionResult DeleteDestination(int id)
        {
           
            var data = _destinationService.TgetById(id);
            _destinationService.Tdelete(data);
            return NoContent();
        }
        public IActionResult UpdateDestination(Destination destination)
        {
            var data = _destinationService.TgetById(destination.DestinationId);
            
            _destinationService.Tupdate(destination);
            var jsonData = JsonConvert.SerializeObject(destination);
            return Json(jsonData);
        }

    }
}
