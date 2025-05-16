using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetByID(id);
            _contactService.TDelete(contact);
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetContactMessage(int id)
        {
            var contact = _contactService.TGetByID(id);
            return Ok(contact);
        }

        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            var count = _contactService.TGetContactCount();
            return Ok(count);
        }
    }
}
