using System.Net.Http;
using System.Text;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            AppRole appRole = new AppRole()
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
      
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(appRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                RoleID = appRole.Id,
                RoleName = appRole.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);

            var result = await _roleManager.UpdateAsync(appRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
