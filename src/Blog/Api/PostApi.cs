using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api
{
    public partial class Api
    {
        public async Task<Post> GetPostByIdAsync(string id)
        {
            return await _context.Posts.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedViewModel<PostViewModel>> GetPostListAsync(string tag, string catalog,int pageIndex = 1,int pageSize = 2)
        {
            var list = new List<Post>();
            var count = 0;
            if (!string.IsNullOrEmpty(tag))
            {
                var tagEntity = await _context.Tags.SingleOrDefaultAsync(s => s.DisplayName == tag);
                var postTags = _context.PostTags.ToList().FindAll(s => s.TagId == tagEntity.Id);
                var list1 = list;
                postTags.ForEach(x => { list1.Add(_context.Posts.SingleOrDefault(s => s.Id == x.Id)); });
                list = list1.OrderByDescending(x => x.CreationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                    .ToList();
                count = postTags.Count;
            }
            else if (!string.IsNullOrEmpty(catalog))
            {
                var catalogEntity = await _context.Catalogs.SingleOrDefaultAsync(s => s.DisplayName == catalog);
                 list = _context.Posts.Where(s => s.CategoryId == catalogEntity.Id).ToList();
                 count = list.Count;
                list =list.OrderByDescending(x => x.CreationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                     .ToList();
               
            }
            else
            {
                list = _context.Posts.OrderByDescending(x => x.CreationTime).Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();
                count = _context.Posts.Count();
            }
            var pageCount = (count + pageSize - 1) / pageSize;
            var postModels = list.Select(x => new PostModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                CreationTime = Convert.ToDateTime(x.CreationTime)
                    .ToString("MMMM dd, yyyy HH:mm:ss", new CultureInfo("en-us")),
                Year = Convert.ToDateTime(x.CreationTime).Year
            });
            var result = new List<PostViewModel>();
            var group = postModels.GroupBy(x => x.Year).ToList();
            group.ForEach(x =>
            {
                result.Add(new PostViewModel
                {
                    Year = x.Key,
                    Posts = x.ToList()
                });
            });
            return new PagedViewModel<PostViewModel>
            {
                Data = result,
                CurrentPage = pageIndex,
                TotalCount = count,
                TotalPage = pageCount
            };
        }
    }
}