using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolyChildhood.Models;
using HolyChildhood.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly AppDbContext dbContext;

        public EventController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventViewModel> GetEvents()
        {
            var events = new List<EventViewModel>();
            foreach (var evt in dbContext.Events.OrderBy(e => e.BeginDate))
            {
                events.Add(new EventViewModel
                {
                    Id = evt.Id,
                    Start = evt.BeginDate,
                    End = evt.EndDate,
                    Title = evt.Title,
                    Description = evt.Description,
                    Location = evt.Location,
                    AllDay = evt.AllDay
                });
            }
            return events;
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await dbContext.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(@event).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Event
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(EventViewModel evt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEvent = new Event
            {
                Title = evt.Title,
                BeginDate = evt.Start.ToLocalTime(),
                EndDate = evt.End,
                Description = evt.Description,
                Location = evt.Location,
                AllDay = evt.AllDay
            };

            dbContext.Events.Add(newEvent);
            await dbContext.SaveChangesAsync();

            evt.Id = newEvent.Id;

            return CreatedAtAction("GetEvent", new { id = newEvent.Id }, evt);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await dbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            dbContext.Events.Remove(@event);
            await dbContext.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return dbContext.Events.Any(e => e.Id == id);
        }
    }
}