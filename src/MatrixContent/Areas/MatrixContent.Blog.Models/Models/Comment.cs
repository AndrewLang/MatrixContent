using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Represent a comment
    /// </summary>
    public class Comment : Entity
    {
        /// <summary>
        /// Gets or sets the post ID that this commoent put on
        /// </summary>
        /// <value>The target ID.</value>
        public int PostID { get; set; }
        /// <summary>
        /// Gets or sets the details of the comment.
        /// </summary>
        /// <value>The details.</value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the address who put the comment.
        /// </summary>
        /// <value>The address.</value>
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The publish date.</value>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is ignore.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ignore; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserID { get; set; }
    }
}
