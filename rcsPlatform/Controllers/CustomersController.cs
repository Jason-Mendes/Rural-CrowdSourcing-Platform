using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using rcsPlatform.Models;

namespace rcsPlatform.Controllers
{
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly rcsDbContext _dbContext;

        public CustomersController(IWebHostEnvironment env, rcsDbContext dbContext)
        {
            _env = env;
            _dbContext = dbContext;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "MyStaticFiles", file.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            // Save the file info to your database here

            return Ok();
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment(int modelId, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var comment = new Comment
            {
                UserId = userId,
                ModelId = modelId,
                Text = text,
            };

            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getComments/{modelId}")]
        public async Task<IActionResult> GetComments(int modelId)
        {
            var comments = await _dbContext.Comments
                .Where(c => c.ModelId == modelId)
                .ToListAsync();

            return Ok(comments);
        }

        [HttpGet("download")]
        public IActionResult Download(string filename)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "MyStaticFiles", filename);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            return PhysicalFile(filePath, "application/octet-stream", filename);
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var files = Directory.GetFiles(Path.Combine(_env.ContentRootPath, "MyStaticFiles"))
                .Select(Path.GetFileName);

            return Ok(files);
        }
    }
}
