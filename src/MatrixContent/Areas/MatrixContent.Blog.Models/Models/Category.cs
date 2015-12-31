using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Represent a category
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Constructor of <see cref="Category"/>
        /// </summary>
        public Category( )
        {
            DateCreated = DateTime.Now;
            Posts = new List<Post>( );
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>The date modified.</value>
        public DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets the posts in this category.
        /// </summary>
        /// <value>The posts.</value>
        public virtual ICollection<Post> Posts { get; set; }
    }
}
