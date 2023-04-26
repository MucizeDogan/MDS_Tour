using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiHotelSearchController : Controller
    {
        public async Task <IActionResult> Index()
        {
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number=2&checkin_date=2023-09-27&filter_by_currency=EUR&dest_id=-1456928&locale=en-gb&checkout_date=2023-09-28&units=metric&room_number=1&dest_type=city&include_adjacency=true&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
				Headers =
	{
		{ "X-RapidAPI-Key", "8868911701mshb9d2852c3cd303fp1a5f0ejsnfb47c4ddeb29" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var bodyReplace = body.Replace(".", "");
				var data = JsonConvert.DeserializeObject<ApiHotelSearchModel>(bodyReplace);
				return View(data.results);
			}
		}


        [HttpGet]
		public IActionResult GetCityDestId()
        {
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> GetCityDestId(string p) // buradaki p parametresi id si alınacak şehrin ismi.. Yani biz şehir ismini gireceğiz ve onun id sini alacağız.
        {
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
				Headers =
	{
		{ "X-RapidAPI-Key", "8868911701mshb9d2852c3cd303fp1a5f0ejsnfb47c4ddeb29" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return View();
			}
		}
    }
}
