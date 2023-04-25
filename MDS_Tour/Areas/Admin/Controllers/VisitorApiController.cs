using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS_Tour.Areas.Admin.Controllers
{
    public class VisitorApiController : Controller
    {
        // Burası bir api yi tüketen kullanan bir controller olacak.
        
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task <IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient(); // Client oluştruduk.
            var responseMessage = await client.GetAsync("http://localhost:5034/api/Visitor"); 
            if(responseMessage.IsSuccessStatusCode)         // Başarılı bir dönüş sağlanırsa
            {
                var jasonData = await responseMessage.Content.ReadAsStringAsync();            //Veriyi frontend tarafına taşıyoruz.
                var data=JsonConvert.DeserializeObject<List<VisitorModel>>(jasonData);
                return View(data);
            }
            return View();
        }
    }
}
