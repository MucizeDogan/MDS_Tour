using MDS_Tour.CQRS.Commands.GuideCommands;
using MDS_Tour.CQRS.Queries.GuideQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [AllowAnonymous]
    [Authorize(Roles = "Admin")]

    // BURADA MEDIATR(MEDIATOR) KULLANARAK HER HANDLE İÇİN TEK TEK CONSTR TANIMLAMAMAZIA GEREK KALMIYOR.
    public class GuideMediatRController : BaseController
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAllGuideQuery()); // Burada handle ı çağırmıyoruz artık Irequest in miras aldığı sınıfı çapırıyoruz.
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var data = await _mediator.Send(new GetGuideByIdQuery(id));// Burada handle ı çağırmıyoruz artık Irequest in miras aldığı sınıfı çapırıyoruz.Yani query sınıfını..
            return View(data);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

    }
}
