using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Represent a tag
    /// </summary>
    public class Tag : Entity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public virtual ICollection<Post> Posts { get; set; }
    }
}
