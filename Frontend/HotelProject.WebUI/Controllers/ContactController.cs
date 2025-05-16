using HotelProject.WebUI.Dtos.ContactDto;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Humanizer;
using HotelProject.WebUI.Dtos.MessageCategoryDto;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:34673/api/MessageCategory");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

            List<SelectListItem> categories = values
                .Select(x => new SelectListItem
                {
                    Text = x.MessageCategoryName,
                    Value = x.MessageCategoryID.ToString()
                })
                .ToList();

            ViewBag.categories = categories;

            return View();

          
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto dto)
        {
            dto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(
                jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:34673/api/Contact", stringContent);

            return RedirectToAction("Index", "Default");
        }
    }


}
