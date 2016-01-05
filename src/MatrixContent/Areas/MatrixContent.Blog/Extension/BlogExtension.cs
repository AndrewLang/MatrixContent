using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNet.Builder;

namespace MatrixContent.Blog
{
    /// <summary>
    /// Blog extension
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.Extension" />
    public class BlogExtension:Extension
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IDatabaseModelInitializer),typeof(BlogDatabaseInitializer)));
            services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IApiCommandProvider),typeof(BlogCommandsProvider)));
        }
        ///// <summary>
        ///// Configures the routes.
        ///// </summary>
        ///// <param name="routes">The routes.</param>
        //public override void ConfigureRoutes(IRouteBuilder routes)
        //{
        //    base.ConfigureRoutes(routes);

        //    routes.MapRoute(
        //       name: "blog",
        //       template: "{area}/{controller}/{action}",
        //       defaults: new { area = "blog",controller = "Post",action = "Index" });
        //}
    }
}
