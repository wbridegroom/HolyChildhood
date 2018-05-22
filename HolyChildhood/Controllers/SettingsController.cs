using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HolyChildhood.Models;
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
        private readonly ClaimsPrincipal user;
        private readonly AppDbContext dbContext;

        public SettingsController(AppDbContext dbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            user = httpContextAccessor.HttpContext.User;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<UserTest> Get()
        {
            var claims = new List<Claim>(user.Claims);
            return new UserTest {
                Name = claims.FirstOrDefault(c => c.Type == "name")?.Value,
                Email = claims.FirstOrDefault(c => c.Type == "emails")?.Value
            };
        }
    }

    public class UserTest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}