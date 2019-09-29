using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api
{
    public partial class Api
    {
        public async Task<IList<TagViewModel>> GetTagListAsync()
        {
            return await _context.Tags.Select(x => new TagViewModel
            {
                TagName = x.TagName,
                DisplayName = x.DisplayName,
                Count = _context.PostTags.Count(s => s.TagId == x.Id)
            }).ToListAsync();
        }
    }
}