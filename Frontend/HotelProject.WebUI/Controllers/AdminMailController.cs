using System.Text;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models;
using HotelProject.WebUI.Models.Mail;
using HotelProject.WebUI.Models.Mail.HotelProject.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController: Controller
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminMailController(IOptions<SmtpSettings> smtpOptions, IHttpClientFactory httpClientFactory)
        {
            _smtpSettings = smtpOptions.Value;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Index(AdminMailViewModel model, CreateSendMessageDto dto)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Hotel Admin", _smtpSettings.Mail));
            mimeMessage.To.Add(new MailboxAddress("User", model.ReceiverMail));

            var bodyBuilder = new BodyBuilder
            {
                TextBody = model.Body
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = model.Subject;

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(_smtpSettings.Mail, _smtpSettings.Key);
            client.Send(mimeMessage);
            client.Disconnect(true);

            dto.SenderName = "Hotel Admin";
            dto.SenderMail = _smtpSettings.Mail;
            dto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            dto.Title = model.Subject;
            dto.Content = model.Body;
            dto.ReceiverName = model.ReceiverMail.Substring(0, model.ReceiverMail.IndexOf("@"));
            dto.ReceiverMail = model.ReceiverMail;
            var httpClient = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(
                jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("http://localhost:34673/api/SendMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Sendbox","AdminContact");
            }

            return RedirectToAction("Index", "AdminMail");
        }
    }
}
