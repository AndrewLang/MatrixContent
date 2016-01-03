using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Framework;
using Microsoft.Data.Entity;
using BlogModel = MatrixContent.Blog.Models;

namespace MatrixContent.Blog
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MatrixContent.Framework.IDatabaseModelInitializer" />
    public class BlogDatabaseInitializer : IDatabaseModelInitializer
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Initialize(ModelBuilder builder)
        {
            // This works for db migration command
            builder.Entity<BlogModel.Blog>().HasKey(x => x.ID);
        }
    }
}
