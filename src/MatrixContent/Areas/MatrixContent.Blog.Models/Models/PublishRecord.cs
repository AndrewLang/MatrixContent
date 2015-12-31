using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PublishRecord :Entity
    {
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>
        /// The post identifier.
        /// </value>
        public int PostId { get; set; }
        /// <summary>
        /// Gets or sets the name of the social.
        /// </summary>
        /// <value>
        /// The name of the social.
        /// </value>
        public string SocialName { get; set; }
        /// <summary>
        /// Gets or sets the social post identifier.
        /// </summary>
        /// <value>
        /// The social post identifier.
        /// </value>
        public string SocialPostId { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }
    }
}
