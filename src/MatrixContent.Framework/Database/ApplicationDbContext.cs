using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MatrixContent.Framework
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        readonly IServiceProvider mServiceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ApplicationDbContext(IServiceProvider serviceProvider)
        {
            mServiceProvider = serviceProvider;
        }
        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var initializers = mServiceProvider.GetServices<IDatabaseModelInitializer>();
            foreach(var item in initializers)
            {
                item.Initialize(builder);
            }
        }
    }
}