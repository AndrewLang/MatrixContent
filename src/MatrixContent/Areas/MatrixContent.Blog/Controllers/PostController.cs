using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MatrixContent.Blog.Controllers
{
    [Area("Blog")]
    public class PostController : Controller
    {
        public PostController(ApplicationDbContext context)
        {

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
