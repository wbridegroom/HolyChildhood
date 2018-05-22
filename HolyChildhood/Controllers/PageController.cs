using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : Controller
    {
        private readonly AppDbContext dbContext;

        public PageController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Page> Get()
        {
            return dbContext.Pages;
        }

        [HttpGet("{id}")]
        public Page Get(int id)
        {
            return dbContext.Pages.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Page>> Create(Page page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dbContext.Pages.AddAsync(page);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = page.Id}, page);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var page = await dbContext.Pages.FindAsync(id);
            if(page == null)
            {
                return NotFound();
            }

            dbContext.Pages.Remove(page);
            dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}