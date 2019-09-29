using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api
{
    public partial class Api
    {
        public async Task<IList<CatalogViewModel>> GetCatalogListAsync()
        {
            var catalogViewModels =await _context.Catalogs.Select(x=> new CatalogViewModel
            {
                DisplayName = x.DisplayName,
                CategoryName = x.CategoryName,
                Count =  _context.Posts.Count(s => s.CategoryId==x.Id)
            }).ToListAsync();
            return catalogViewModels;
        }
    }
}