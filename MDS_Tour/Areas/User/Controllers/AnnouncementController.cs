using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var data = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(data);

        }
    }
}
