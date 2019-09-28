using System.Threading.Tasks;
using Blog.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api
{
    public partial class Api
    {
        public async Task<Post> GetPostById(string id)
        {
            return  await _context.Posts.SingleOrDefaultAsync(s => s.Url == id);
        }
    }
}