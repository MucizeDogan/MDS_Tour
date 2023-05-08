using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Models;
using SignalRApiForSql.Response;

namespace SignalRApiForSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public VisitorResponse CreateVisitor()
        {
            try
            {
                Random random = new Random();
                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {
                    foreach (ECity item in Enum.GetValues(typeof(ECity)))
                    {
                        var newVisitor = new Visitor
                        {
                            City = item,
                            CityVisitCount = random.Next(100, 2000),
                            VisitDate = DateTime.Now.AddDays(x)
                        };
                        _visitorService.SaveVisitor(newVisitor).Wait();
                        System.Threading.Thread.Sleep(1000);    //Her bir ekleme işlemini saniyede 1 kez gerçekleştir.
                    }
                });
                return new VisitorResponse { IsSuccessful = true, Message = "Successful ", Set = null };
            }
            catch (Exception exp)
            {
                return new VisitorResponse { IsSuccessful = false, Message = "Error", Set = exp.StackTrace };
            }

        }
    }
}
