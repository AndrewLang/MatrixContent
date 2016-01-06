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
    public class BlogDatabaseInitializer:IDatabaseModelInitializer
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Initialize(ModelBuilder builder)
        {
            // This works for db migration command
            builder.Entity<BlogModel.Blog>().HasKey(x => x.ID);
            builder.Entity<BlogModel.Category>().HasKey(x => x.ID);
            builder.Entity<BlogModel.Comment>().HasKey(x => x.ID);
            builder.Entity<BlogModel.Tag>().HasKey(x => x.ID);
            builder.Entity<BlogModel.Post>().HasKey(x => x.ID);
            builder.Entity<BlogModel.PostAccessInfo>().HasKey(x => x.ID);
            builder.Entity<BlogModel.PostRating>().HasKey(x => x.ID);
            builder.Entity<BlogModel.PostCategory>().HasKey(x => new { x.PostID,x.CategoryID });
            builder.Entity<BlogModel.PostTag>().HasKey(x => new { x.PostID,x.TagID });
        }
    }
}
