using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Pages.Where(p => p.Parent == null).Include(p => p.Children).ToList();
        }

        [HttpGet("{id}")]
        public Page Get(int id)
        {
            return dbContext.Pages.Include(p => p.Parent).FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Page>> Create(Page page)
        {
            var newPage = page;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (page.Parent != null)
                {
                    var parent = dbContext.Pages.Include(p => p.Children).FirstOrDefault(p => p.Id == page.Parent.Id);
                    newPage = new Page {Title = page.Title};
                    parent?.Children.Add(newPage);
                }
                else
                {
                    await dbContext.Pages.AddAsync(page);
                }
                
                await dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new {id = newPage.Id}, newPage);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Page>> Update(Page page)
        {
            var pageUpdate = await dbContext.Pages.FindAsync(page.Id);
            if (pageUpdate == null)
            {
                return NotFound();
            }

            pageUpdate.Title = page.Title;
            dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var page = await dbContext.Pages.FindAsync(id);
                if (page == null)
                {
                    return NotFound();
                }

                dbContext.Pages.Remove(page);
                dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }

            return NoContent();
        }
    }
}