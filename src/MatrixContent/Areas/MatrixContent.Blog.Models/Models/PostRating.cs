using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Rating for a <see cref="Post"/>
    /// </summary>
    public class PostRating : Entity
    {
        /// <summary>
        /// Gets or sets the post ID.
        /// </summary>
        /// <value>
        /// The post ID.
        /// </value>
        public int PostID { get; set; }
        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        /// <value>
        /// The IP address.
        /// </value>
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the rate date.
        /// </summary>
        /// <value>
        /// The rate date.
        /// </value>
        public DateTime? RateDate { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public float Rating { get; set; }
    }
}
