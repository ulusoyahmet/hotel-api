using System.Text;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Contact;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Context _context;

        int inboxCount;


        public AdminContactController(IHttpClientFactory httpClientFactory, Context context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
            inboxCount = _context.Contacts.Count();
        }
        public async Task<IActionResult> Inbox(SidebarContactViewModel model)
        {
            var inboxCount = _context.Contacts.Count();
            ViewBag.InboxCount = inboxCount;

            var sidebarModel = new SidebarContactViewModel
            {
                ActivePage = "Inbox",
                InboxCount = inboxCount
            };

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:34673/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View(sidebarModel);
        }

        public async Task<IActionResult> Sendbox()
        {
            inboxCount = _context.Contacts.Count();
            ViewBag.InboxCount = inboxCount;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:34673/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderName = "admin";
            model.SenderMail = "admin@gmail.com";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(
                jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:34673/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }

            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:34673/api/SendMessage/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }

            return View();

        }

        public async Task<IActionResult> MessageDetailsByContact(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:34673/api/Contact/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetContactByIDDto>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}
