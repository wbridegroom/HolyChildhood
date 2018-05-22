using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageContentController : Controller
    {
        private readonly AppDbContext dbContext;

        public PageContentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IEnumerable<PageContent> List(int id)
        {
            return dbContext.PageContents.Where(pc => pc.Page.Id == id).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PageContent> Content(int id)
        {
            var content = dbContext.PageContents.Find(id);
            if (content == null)
            {
                return NotFound();
            }
            return content;
        }

        [HttpPost("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PageContent>> Create(int id, PageContent pageContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var page = dbContext.Pages.Find(id);
            if (page == null)
            {
                return NotFound();
            }

            pageContent.Page = page;
            dbContext.PageContents.AddAsync(pageContent);
            dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Content), new {id = pageContent.Id}, pageContent);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PageContent>> Update(PageContent pageContent)
        {
            var content = await dbContext.PageContents.FindAsync(pageContent.Id);
            if (content == null)
            {
                return NotFound();
            }

            content.Content = pageContent.Content;
            dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var content = await dbContext.PageContents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            dbContext.PageContents.Remove(content);
            dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}