using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolyChildhood.Models;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly AppDbContext dbContext;

        public GroupsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<Group> GetGroups()
        {
            return dbContext.Groups.Include(g => g.Members).ThenInclude(m => m.Parishioner);
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await dbContext.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return Ok(@group);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup([FromRoute] int id, [FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @group.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(@group).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Groups.Add(@group);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await dbContext.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            dbContext.Groups.Remove(@group);
            await dbContext.SaveChangesAsync();

            return Ok(@group);
        }

        private bool GroupExists(int id)
        {
            return dbContext.Groups.Any(e => e.Id == id);
        }
    }
}