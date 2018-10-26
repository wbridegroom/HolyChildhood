using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly AppDbContext dbContext;

        public FileController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            var request = HttpContext.Request;
            var count = request.Form.Files.Count;
            if (count == 0) return NotFound();

            var file = request.Form.Files.GetFile("files");
            if (file == null) return NotFound();

            var extension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);

            var title = request.Form["name"].ToString();

            var dbFile = new Models.File
            {
                Title = title,
                Type = extension,
                CreatedAt = DateTime.Now
            };
            await dbContext.Files.AddAsync(dbFile);
            await dbContext.SaveChangesAsync();

            var name = dbFile.Id + "." + extension;

            var dir = new FileInfo("wwwroot/files/" + name);
            dir.Directory?.Create();

            var stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            var writer = System.IO.File.Create(dir.FullName);
            stream.CopyTo(writer);
            writer.Dispose();

            return Json(new {link = "/api/file/" + dbFile.Id});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var dbFile = dbContext.Files.Find(id);
            if (dbFile == null) return NotFound();

            var path = "wwwroot/files/" + dbFile.Id + "." + dbFile.Type;
            if (!System.IO.File.Exists(path)) return NotFound();

            var file = System.IO.File.OpenRead(path);
            return File(file, "application/pdf");
        }

        [HttpGet]
        public IEnumerable<Models.File> List()
        {
            return dbContext.Files.OrderByDescending(f => f.CreatedAt).ToList();
        }
    }
}