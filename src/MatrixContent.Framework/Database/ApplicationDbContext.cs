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
        //public ApplicationDbContext()
        //{

        //}

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (mServiceProvider != null)
            {
                var initializers = mServiceProvider.GetServices<IDatabaseModelInitializer>();
                foreach (var item in initializers)
                {
                    item.Initialize(builder);
                }
            }
        }
        /// <summary>
        /// Called when [configuring].
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"data source=(local);Initial Catalog=MatrixContentTest;Integrated Security=SSPI;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}