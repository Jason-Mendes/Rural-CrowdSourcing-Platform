using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rcsPlatform.Models;
using rcsPlatform;
using System.Security.Claims;
using System.Threading.Tasks;

namespace rcsPlatform.Controllers
{
    [Route("[controller]")]
    public class DevelopersController : Controller
    {
        private readonly rcsDbContext _dbContext;

        public DevelopersController(rcsDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
