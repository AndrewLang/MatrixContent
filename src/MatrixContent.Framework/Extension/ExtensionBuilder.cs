using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MatrixContent.Framework
{
    /// <summary>
    /// Default implementation of <see cref="IExtensionBuilder"/>
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.IExtensionBuilder" />
    public class ExtensionBuilder:IExtensionBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionBuilder"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public ExtensionBuilder(IServiceCollection services)
        {
            Services = services;
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        public IServiceCollection Services { get; }
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>
        /// The service provider.
        /// </value>
        public IServiceProvider ServiceProvider { get; }
    }
}
