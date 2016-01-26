using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.AspNet.Mvc;


namespace MatrixContent.Blog.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Mvc.Controller" />
    [Area(Consts.AreaName)]
    public class PostController:Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PostController(IRepository repository)
        {
            
        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            if(page == null)
                page = 1;

            return View();
        }        
    }
}
