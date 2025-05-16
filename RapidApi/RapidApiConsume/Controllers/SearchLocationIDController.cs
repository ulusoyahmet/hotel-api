using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            cityName = !string.IsNullOrEmpty(cityName) ? cityName : "Tokyo";
            
            List<BookingApiLocationViewModel> model = new();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
                Headers =
            {
                { "x-rapidapi-key", "4d8dcc0894mshad9b4f75ab601a8p1e3effjsn6b33c27c23e1" },
                { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<BookingApiLocationViewModel>>(body);
                return View(model.Take(1).ToList());
            }
           
            
        }
    }
}
