using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace MatrixContent.Framework
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.IExtension" />
    public abstract class Extension:IExtension
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public virtual void Configure(IApplicationBuilder app)
        {

        }

        /// <summary>
        /// Configures the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public virtual void ConfigureRoutes(IRouteBuilder routes)
        {

        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public virtual void ConfigureServices(IServiceCollection services)
        {

        }

        /// <summary>
        /// Extensions the resource path.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected virtual string ExtensionResourcePath(IApplicationBuilder app,string name)
        {
            var appEnv = app.ApplicationServices.GetService<IApplicationEnvironment>();
            return Path.Combine(appEnv.ApplicationBasePath,$"areas\\{name}\\wwwroot");
        }
    }
}
