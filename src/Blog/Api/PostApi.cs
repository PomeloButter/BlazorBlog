using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api
{
    public partial class Api
    {
      
        public async Task<Post> GetPostByIdAsync(string id="1")
        {
            return  await _context.Posts.SingleOrDefaultAsync(s => s.Id == "1");
        }

        public async Task<PagedViewModel<Post>> GetPostListAsync(int pageIndex=1,int pageSize=2)
        {
          var list=   _context.Posts.OrderByDescending(x=>x.CreationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
          var count =await _context.Posts.CountAsync();
          var pageCount= (count + pageSize - 1)/pageSize;
          return new PagedViewModel<Post>()
          {
              Data = list,
              CurrentPage = pageIndex,
              TotalCount = count,
              TotalPage = pageCount
          };
        }
    }
}