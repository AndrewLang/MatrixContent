using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNet.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;

namespace MatrixContent.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds the extensions.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IExtensionBuilder AddExtensions(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var assemblyProvider = serviceProvider.GetService<IAssemblyProvider>();

            var types = assemblyProvider.CandidateAssemblies
                                        .SelectMany(x => x.GetTypes().Select(t => t.GetTypeInfo()))
                                        .Where(x => typeof(IExtension).GetTypeInfo().IsAssignableFrom(x) && !x.IsAbstract);

            foreach(var type in types)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IExtension),type.AsType()));
            }

            return new ExtensionBuilder(services);
        }
        /// <summary>
        /// Configures the extensions.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IExtensionBuilder ConfigureExtensions(this IExtensionBuilder builder)
        {
            var extensions = builder.ServiceProvider.GetServices<IExtension>();

            foreach(var item in extensions)
            {
                item.ConfigureServices(builder.Services);
            }

            return builder;
        }
        /// <summary>
        /// Configures the extension routes.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="routes">The routes.</param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureExtensionRoutes(this IApplicationBuilder app,IRouteBuilder routes)
        {
            var extensions = app.ApplicationServices.GetServices<IExtension>();

            foreach(var item in extensions)
            {
                item.ConfigureRoutes(routes);
            }

            return app;
        }
        /// <summary>
        /// Uses the extensions.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseExtensions(this IApplicationBuilder app)
        {
            var extensions = app.ApplicationServices.GetServices<IExtension>();

            foreach(var item in extensions)
            {
                item.Configure(app);
            }

            return app;
        }
    }
}
