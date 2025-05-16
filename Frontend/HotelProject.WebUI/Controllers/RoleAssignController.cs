using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController: Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<(AppUser User, IList<string> Roles)>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add((user, roles));
            }

            return View(userRoles);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = roles.Select(role => new RoleAssignViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                RoleExists = userRoles.Contains(role.Name)
            }).ToList();

            ViewBag.userId = user.Id;
            ViewBag.userName = user.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model, int userId)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            foreach (var role in model)
            {
                if (role.RoleExists)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }

            return RedirectToAction("Index");
        }


    }

}
