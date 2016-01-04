using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Builder;

namespace MatrixContent.Security
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.Extension" />
    public class SecurityExtension : Extension
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Add application services.
            services.AddTransient<IEmailSender,AuthMessageSender>();
            services.AddTransient<ISmsSender,AuthMessageSender>();
        }
        /// <summary>
        /// Configures the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public override void ConfigureRoutes(IRouteBuilder routes)
        {
            base.ConfigureRoutes(routes);

            routes.MapRoute(
                name: "login",
                template: "{area}/login",
                defaults: new { area="security", controller = "Account",action = "Login" });

            routes.MapRoute(
                name: "register",
                template: "{area}/register",
                defaults: new { area = "security",controller = "Account",action = "Register" });
        }
    }
}
