using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HotelProject.WebUI.Dtos.BookingDto;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:34673/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpGet("/BookingAdmin/ApproveBooking/{id}")]
        public async Task<IActionResult> ApproveBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Get the full booking first
            var response = await client.GetAsync($"http://localhost:34673/api/Booking/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);

            if (booking == null)
                return NotFound();

            // Only update the status
            booking.Status = "Approved";

            var updatedJson = JsonConvert.SerializeObject(booking);
            var stringContent = new StringContent(updatedJson, Encoding.UTF8, "application/json");

            var updateResponse = await client.PutAsync("http://localhost:34673/api/Booking", stringContent);

            return RedirectToAction("Index");
        }

        [HttpGet("/BookingAdmin/SuspendBooking/{id}")]
        public async Task<IActionResult> SuspendBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Get the full booking first
            var response = await client.GetAsync($"http://localhost:34673/api/Booking/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var jsonData = await response.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);

            if (booking == null)
                return NotFound();

            // Only update the status
            booking.Status = "Suspended";

            var updatedJson = JsonConvert.SerializeObject(booking);
            var stringContent = new StringContent(updatedJson, Encoding.UTF8, "application/json");

            var updateResponse = await client.PutAsync("http://localhost:34673/api/Booking", stringContent);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"http://localhost:34673/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:34673/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(
                jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:34673/api/Booking/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}

