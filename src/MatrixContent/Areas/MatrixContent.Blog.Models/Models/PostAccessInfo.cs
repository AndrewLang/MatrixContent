using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatrixContent.Models;

namespace MatrixContent.Blog.Models
{
    /// <summary>
    /// Access info for a <see cref="Post"/>
    /// </summary>
    public class PostAccessInfo : Entity
    {
        /// <summary>
        /// Gets or sets the post ID.
        /// </summary>
        /// <value>
        /// The post ID.
        /// </value>
        public int PostID { get; set; }
        /// <summary>
        /// Gets or sets the access time.
        /// </summary>
        /// <value>
        /// The access time.
        /// </value>
        public DateTime? AccessDate { get; set; }
        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        /// <value>
        /// The IP address.
        /// </value>
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public string Client { get; set; }
    }
}
