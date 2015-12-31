using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        }
    }
}
