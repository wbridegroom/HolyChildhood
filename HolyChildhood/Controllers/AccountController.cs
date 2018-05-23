using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using HolyChildhood.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Register(UserViewModel user)
        {
            var appUser = new AppUser
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            await userManager.CreateAsync(appUser, user.Password);
            userManager.AddToRoleAsync(appUser, "User");
            foreach (var roleName in user.Roles)
            {
                userManager.AddToRoleAsync(appUser, roleName);
            }

            return NoContent();
        }
    }
}