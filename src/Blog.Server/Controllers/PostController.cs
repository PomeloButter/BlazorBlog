using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Common.Entity;
using Blog.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly BlogContext _blogContext;

        public PostController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> Get(string id, CancellationToken token = default)
        {
            return Json(await _blogContext.Posts.SingleOrDefaultAsync(s=>s.Url==id, token));
        }
        
    }
}