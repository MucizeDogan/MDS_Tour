using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using EntityLayer.Concrete;
using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
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
            var data = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());  //Maplenecek bir hedef istiyor ancak biz öncelikle listeleme yapmak istdiğimiz için önce List<> diyoruz daha sonra Listeleyeceğimiz DTO yu yazmak gerekiyor. Bunun için yeni Bir ListDTO oluşturacağız normal modelden copy paste yapabilirz.

            return View(data);

            //  BURASI DTO VE MAPPER KULLANMADAN BİR TABLODA SADECE İSTENİLEN KISIMLARI GÖSTERMEK İÇİN.
            //List<Announcement> announcements = _announcementService.TGetList();
            //List<AnnouncementListModel> model = new List<AnnouncementListModel>();
            //foreach (var item in announcements)
            //{
            //    AnnouncementListModel announcementListModel = new AnnouncementListModel();
            //    announcementListModel.Id = item.AnnouncementId;
            //    announcementListModel.Title = item.Title;
            //    announcementListModel.Content = item.Content;
            //    model.Add(announcementListModel);
            //}
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto model) //AnnouncementAddDto dan model parametresi al
        {
            if(ModelState.IsValid)  //Eğer model geçerliyse
            {
                _announcementService.Tadd(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var data = _announcementService.TgetById(id);
            _announcementService.Tdelete(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var data = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TgetById(id));
            return View(data);

        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if(ModelState.IsValid)
            {
                _announcementService.Tupdate(new Announcement
                {
                    AnnouncementId = model.AnnouncementId,
                    Content = model.Content,
                    Title=model.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });    
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
    }
}
