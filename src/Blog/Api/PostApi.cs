using System;
using System.Collections.Generic;
using System.Globalization;
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
      
        public async Task<Post> GetPostByIdAsync(string id)
        {
            return  await _context.Posts.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedViewModel<PostViewModel>> GetPostListAsync(int pageIndex=1,int pageSize=4)
        {
          var list=   _context.Posts.OrderByDescending(x=>x.CreationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
          var count =await _context.Posts.CountAsync();
          var pageCount= (count + pageSize - 1)/pageSize;
          var postModels = list.Select(x => new PostModel
          {
              Id = x.Id,
              Title = x.Title,
              Url = x.Url,
              CreationTime = Convert.ToDateTime(x.CreationTime).ToString("MMMM dd, yyyy HH:mm:ss", new CultureInfo("en-us")),
              Year = Convert.ToDateTime(x.CreationTime).Year
          });
          List<PostViewModel> result = new List<PostViewModel>();
          var group = postModels.GroupBy(x => x.Year).ToList();
          group.ForEach(x =>
          {
              result.Add(new PostViewModel
              {
                  Year = x.Key,
                  Posts = x.ToList()
              });
          });
            return new PagedViewModel<PostViewModel>()
          {
              Data = result,
              CurrentPage = pageIndex,
              TotalCount = count,
              TotalPage = pageCount
          };
        }
    }
}