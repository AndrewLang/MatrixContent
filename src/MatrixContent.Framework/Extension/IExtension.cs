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
    /// Represent an extension for the app
    /// </summary>
    public interface IExtension
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Configures the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        void ConfigureRoutes(IRouteBuilder routes);

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        void Configure(IApplicationBuilder app);
    }
}
