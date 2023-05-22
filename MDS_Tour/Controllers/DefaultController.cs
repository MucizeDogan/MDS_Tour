using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        IDestinationService _destinationService;

        public DefaultController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            List<Destination> destinationList = new List<Destination>(_destinationService.TGetList());
            //List<string> strings = new List<string>() { "Ozan","Mucize"};
            return View(destinationList);
        }

        //[HttpGet]
        //public IActionResult Detay(int id)
        //{
        //    List<Destination> destinationList = new List<Destination>(_destinationService.TGetList());
        //    //List<string> strings = new List<string>() { "Ozan","Mucize"};
        //    return View(destinationList);
        //}
        //[HttpPost]
        //public IActionResult Detay(Destination destination)
        //{
        //    return RedirectPermanent("/Destination/DestinationDetails/");
        //}


        
    }
}
