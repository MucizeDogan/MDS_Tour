using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
                var data = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
                var values = await _userManager.FindByNameAsync(User.Identity.Name);

                if (values != null)
                {
                    ViewBag.userName = values.Name +" "+ values.Surname;
                    ViewBag.userImage = values.Image;
                }

                return View(data);
        }
    }
}
