using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("ListWithWorkLocation")]
        public IActionResult UserListWithWorkLocation()
        {
            var users = _appUserService.TUserListWithWorkLocation();
            var result = users.Select(user => new ResultAppUserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Country = user.Country,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                WorkDepartment = user.WorkDepartment,
                WorkLocationID = user.WorkLocationID,
                WorkLocationName = user.WorkLocation?.WorkLocationName
            }).ToList();

            return Ok(result);


        }

        [HttpGet]
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddAppUser(AppUser appUser)
        {
            _appUserService.TInsert(appUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppUser(int id)
        {
            var appUser = _appUserService.TGetByID(id);
            _appUserService.TDelete(appUser);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAppUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAppUser(int id)
        {
            var appUser = _appUserService.TGetByID(id);
            return Ok(appUser);
        }
    }
}
