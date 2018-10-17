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
    public class ParishionersController : Controller
    {
        private readonly AppDbContext dbContext;

        public ParishionersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Parishioners
        [HttpGet]
        public IEnumerable<Parishioner> GetParishioners()
        {
            return dbContext.Parishioners.Include(p => p.GroupMemberships).ThenInclude(gm => gm.Group);
        }

        // GET: api/Parishioners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParishioner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parishioner = await dbContext.Parishioners.FindAsync(id);

            if (parishioner == null)
            {
                return NotFound();
            }

            return Ok(parishioner);
        }

        // PUT: api/Parishioners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParishioner([FromRoute] int id, [FromBody] Parishioner parishioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parishioner.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(parishioner).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParishionerExists(id))
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

        // POST: api/Parishioners
        [HttpPost]
        public async Task<IActionResult> PostParishioner([FromBody] Parishioner parishioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Parishioners.Add(parishioner);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetParishioner", new { id = parishioner.Id }, parishioner);
        }

        // DELETE: api/Parishioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParishioner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parishioner = await dbContext.Parishioners.FindAsync(id);
            if (parishioner == null)
            {
                return NotFound();
            }

            dbContext.Parishioners.Remove(parishioner);
            await dbContext.SaveChangesAsync();

            return Ok(parishioner);
        }

        private bool ParishionerExists(int id)
        {
            return dbContext.Parishioners.Any(e => e.Id == id);
        }
    }
}