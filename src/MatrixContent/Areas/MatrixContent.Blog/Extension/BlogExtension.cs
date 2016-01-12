using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.AspNet.StaticFiles;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Http;

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
        /// <summary>
        /// Configures the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public override void ConfigureRoutes(IRouteBuilder routes)
        {
            base.ConfigureRoutes(routes);

            routes.MapRoute(
              name: "blogHome",
              template: "{area}/posts",
              defaults: new { area = "blog", controller = "Post", action = "Index" });

            routes.MapRoute(
               name: "blogView",
               template: "{area}/view/{name}",
               defaults: new { area = "blog",controller = "Views",action = "GetPartiaView" });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);

            var areaPath = ExtensionResourcePath(app, Consts.AreaFolder); 

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(areaPath),
            });
        }
    }
}
