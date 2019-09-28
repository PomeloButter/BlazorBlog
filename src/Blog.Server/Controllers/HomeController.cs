using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Common.ViewModel;
using Blog.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext _blogContext;

        public HomeController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

       
    }
}