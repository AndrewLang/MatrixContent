using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MatrixContent.Blog.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Mvc.Controller" />
    [Area(Consts.AreaName)]
    public class ViewsController : Controller
    {
        /// <summary>
        /// Gets the partia view.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IActionResult GetPartiaView( string name)
        {
            return PartialView($"_{name}View");
        }
    }
}
