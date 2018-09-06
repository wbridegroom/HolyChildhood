using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HolyChildhood.Models;
using HolyChildhood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    //[Authorize]
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
        public IEnumerable<Setting> Get()
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = dbContext.Users.Find(userId);

            return dbContext.Settings.ToList();

            //return NotFound();
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Setting>> Update(Setting setting)
        {
            var updateSetting = await dbContext.Settings.FindAsync(setting.Id);
            if (updateSetting == null)
            {
                return NotFound();
            }

            updateSetting.Value = setting.Value;
            dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}