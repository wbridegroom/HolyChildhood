using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HolyChildhood.Models;
using HolyChildhood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        private readonly AppDbContext dbContext;

        public SettingsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<SettingsViewModel> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = dbContext.Users.Find(userId);
            if (user != null)
            {
                return new SettingsViewModel
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
            }

            return NotFound();
        }
    }

}