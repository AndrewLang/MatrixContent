using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
