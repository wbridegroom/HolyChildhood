using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.StaticFiles;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            var httpRequest = HttpContext.Request;
            var filesCount = httpRequest.Form.Files.Count;

            if (filesCount == 0) return NotFound();

            var file = httpRequest.Form.Files.GetFile("file");

            if (file == null) return NotFound();

            var name = GenerateFileName(file.FileName);

            var dir = new FileInfo("wwwroot/upload/" + name);
            dir.Directory?.Create();
            
            var stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            var writer = System.IO.File.Create(dir.FullName);
            stream.CopyTo(writer);
            writer.Dispose();

            return Json(new {link = "/api/image/" + name});
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = new List<object>();
            var path = "wwwroot/upload";

            var fileEntries = System.IO.Directory.GetFiles(path);
            foreach (var fileEntry in fileEntries)
            {
                var fileName = System.IO.Path.GetFileName(fileEntry);
                if (System.IO.File.Exists(fileEntry))
                {
                    string mimeType;
                    new FileExtensionContentTypeProvider().TryGetContentType(fileEntry, out mimeType);
                    if (mimeType == null)
                    {
                        mimeType = "application/octet-stream";
                    }
                    response.Add(new
                    {
                        url = "upload/" + fileName,
                        thumb = "upload/" + fileName,
                        name = "fileName"
                    });
                }
            }

            return Json(response);
        }

        [HttpGet("{imageFile}")]
        public async Task<ActionResult> Get(string imageFile)
        {
            var path = "wwwroot/upload/" + imageFile;
            if (!System.IO.File.Exists(path)) return NotFound();

            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }

        [HttpDelete("{imageFile}")]
        public async Task<ActionResult> Delete(string imageFile)
        {
            try
            {
                var path = "wwwroot/upload/" + imageFile;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception e)
            {
                return Json(e);
            }

            return Json(true);
        }

        private static string GenerateFileName(string fileName)
        {
            var extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString()));
            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb + "." + extension;
        }


    }
}